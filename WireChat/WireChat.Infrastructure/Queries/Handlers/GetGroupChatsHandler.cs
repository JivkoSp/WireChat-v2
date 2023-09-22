using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetGroupChatsHandler : IQueryHandler<GetGroupChatsQuery, List<ChatDto>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetGroupChatsHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<List<ChatDto>> HandleAsync(GetGroupChatsQuery query)
        {
            var chatReadModels = await _readDbContext.ChatUserReadModels
                    .Include(x => x.Chat)
                    .ThenInclude(x => x.ChatUsers)
                    .Include(x => x.Chat)
                    .ThenInclude(x => x.ChatMessages)
                    .Where(x => x.UserId == query.UserId && x.Chat.ChatType == "Group")
                    .Select(x => x.Chat)
                    .AsNoTracking()
                    .ToListAsync();

            return _mapper.Map<List<ChatDto>>(chatReadModels);
        }
    }
}
