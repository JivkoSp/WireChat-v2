using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetBlockedChatMembersHandler : IQueryHandler<GetBlockedChatMembersQuery, List<BlockedChatUserDto>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetBlockedChatMembersHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<List<BlockedChatUserDto>> HandleAsync(GetBlockedChatMembersQuery query)
        {
            var chatReadModel = await _readDbContext.ChatReadModels
                   .Include(x => x.BlockedChatUsers)
                   .ThenInclude(x => x.User)
                   .AsNoTracking()
                   .SingleOrDefaultAsync(x => x.ChatId == query.ChatId);

            var blockedChatUsers = chatReadModel.BlockedChatUsers;

            return _mapper.Map<List<BlockedChatUserDto>>(blockedChatUsers);
        }
    }
}
