using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using WireChat.Application.Commands;
using WireChat.Application.Commands.Dispatcher;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Dispatcher;

namespace WireChat.Infrastructure.Schedulers
{
    internal class DeleteChatMessagesJob : IJob
    {
        private readonly ILogger<DeleteChatMessagesJob> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DeleteChatMessagesJob(ILogger<DeleteChatMessagesJob> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Wirechat --> Retention job started.");

            using (var scope = _serviceScopeFactory.CreateScope())
            {
               var commandDispatcher  = scope.ServiceProvider.GetRequiredService<ICommandDispatcher>();

                var queryDispatcher = scope.ServiceProvider.GetRequiredService<IQueryDispatcher>();

                var getAllUsersChatMessagesQuery = new GetAllUsersChatMessagesQuery();

                var chatMessages = await queryDispatcher.DispatchAsync(getAllUsersChatMessagesQuery);

                var oldChatMessages = chatMessages
                    .Where(x => x.MessageDateTime < DateTime.Now.AddHours(-24))
                    .ToList();

                foreach (var oldChatMessage in oldChatMessages)
                {
                    var removeChatMessageCommand 
                        = new RemoveChatMessageCommand(oldChatMessage.ChatId, oldChatMessage.ChatMessageId);

                    await commandDispatcher.DispatchAsync(removeChatMessageCommand);
                }
            }

            _logger.LogInformation("Wirechat --> Retention job completed.");
        }
    }
}
