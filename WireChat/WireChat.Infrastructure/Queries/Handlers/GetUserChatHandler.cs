using Microsoft.EntityFrameworkCore;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetUserChatHandler : IQueryHandler<GetUserChatQuery, Guid>
    {
        private readonly ReadDbContext _readDbContext;

        public GetUserChatHandler(ReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task<Guid> HandleAsync(GetUserChatQuery query)
        {
            var chatReadModels = await _readDbContext.ChatUserReadModels
                .Include(x => x.Chat)
                .ThenInclude(x => x.ChatUsers)
                .ThenInclude(x => x.User)
                .Where(x => x.UserId == query.IssuerUserId)
                .Select(x => x.Chat)
                .AsNoTracking()
                .ToListAsync();

            var chatUserReadModels = chatReadModels.Where(x => x.ChatType == "OneToOne")
                .Select(x => x.ChatUsers)
                .FirstOrDefault();

            var chatUserReadModel = chatUserReadModels.SingleOrDefault(x => x.UserId == query.ReceiverUserId);

            return chatUserReadModel.ChatId;
        }
    }
}
