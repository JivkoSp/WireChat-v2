using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetContactsHandler : IQueryHandler<GetContactsQuery, List<ChatUserDto>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetContactsHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<List<ChatUserDto>> HandleAsync(GetContactsQuery query)
        {
            var chatReadModels = await _readDbContext.ChatUserReadModels
                .Include(x => x.Chat)
                .Where(x => x.UserId == query.UserId)
                .Select(x => x.Chat)
                .ToListAsync();

            chatReadModels = chatReadModels.Where(x => x.ChatType == "OneToOne").ToList();

            var chatUserReadModels = await _readDbContext.ChatUserReadModels
               .Join(_readDbContext.ChatReadModels, left_side => left_side.ChatId, right_side => right_side.ChatId,
                     (left_side, right_side) => new { Chat = right_side, ChatUsers = right_side.ChatUsers })
               .Where(x => chatReadModels.Contains(x.Chat))
               .Select(x => x.ChatUsers.Where(x => x.UserId != query.UserId).AsQueryable().Include(x => x.User).ToList())
               .AsNoTracking()
               .FirstOrDefaultAsync();

            return _mapper.Map<List<ChatUserDto>>(chatUserReadModels);
        }
    }
}