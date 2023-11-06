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
                .ThenInclude(x => x.ChatUsers)
                .ThenInclude(x => x.User)
                .Where(x => x.UserId == query.UserId)
                .Select(x => x.Chat)
                .AsNoTracking()
                .ToListAsync();

            var chatUserReadModels = chatReadModels
                .Where(x => x.ChatType == "OneToOne")
                .SelectMany(chat => chat.ChatUsers)
                .Where(cu => cu.UserId != query.UserId)
                .ToList();

            return _mapper.Map<List<ChatUserDto>>(chatUserReadModels);
        }
    }
}