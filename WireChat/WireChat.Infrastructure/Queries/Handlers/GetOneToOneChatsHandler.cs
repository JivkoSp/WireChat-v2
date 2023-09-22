using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetOneToOneChatsHandler : IQueryHandler<GetOneToOneChatsQuery, List<ChatDto>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetOneToOneChatsHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<List<ChatDto>> HandleAsync(GetOneToOneChatsQuery query)
        {
            var chatReadModels = await _readDbContext.ChatUserReadModels
                    .Include(x => x.Chat)
                    .ThenInclude(x => x.ChatUsers)
                    .Include(x => x.Chat)
                    .ThenInclude(x => x.ChatMessages)
                    .Where(x => x.UserId == query.UserId && x.Chat.ChatType == "OneToOne")
                    .Select(x => x.Chat)
                    .AsNoTracking()
                    .ToListAsync();

            return _mapper.Map<List<ChatDto>>(chatReadModels);
        }
    }
}
