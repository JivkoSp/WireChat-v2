using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetChatHandler : IQueryHandler<GetChatQuery, ChatDto>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetChatHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<ChatDto> HandleAsync(GetChatQuery query)
        {
            var chatReadModel = await _readDbContext.ChatReadModels
                    .Include(x => x.ChatUsers)
                    .ThenInclude(x => x.User)
                    .Include(x => x.ChatMessages.OrderBy(x => x.MessageDateTime))
                    .ThenInclude(x => x.User)
                    .Include(x => x.BlockedChatUsers)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.ChatId == query.ChatId);

            if (chatReadModel is not null)
            {
                chatReadModel.ChatMessages = chatReadModel.ChatMessages
                .OrderBy(x => x.MessageDateTime)
                .ToList();
            }

            return _mapper.Map<ChatDto>(chatReadModel);
        }
    }
}
