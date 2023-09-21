using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetChatMessagesHandler : IQueryHandler<GetChatMessagesQuery, List<ChatMessageDto>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetChatMessagesHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<List<ChatMessageDto>> HandleAsync(GetChatMessagesQuery query)
        {
            var chatMessageReadModels = await _readDbContext.ChatMessageReadModels
                .Where(x => x.ChatMessageId == query.ChatId)
                .Include(x => x.User)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<ChatMessageDto>>(chatMessageReadModels);
        }
    }
}
