using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetChatUsersHandler : IQueryHandler<GetChatUsersQuery, List<ChatUserDto>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetChatUsersHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<List<ChatUserDto>> HandleAsync(GetChatUsersQuery query)
        {
            var chatUserReadModels = await _readDbContext.ChatUserReadModels
                    .Where(x => x.ChatId == query.ChatId)
                    .Include(x => x.User)
                    .AsNoTracking()
                    .ToListAsync();

            return _mapper.Map<List<ChatUserDto>>(chatUserReadModels);
        }
    }
}
