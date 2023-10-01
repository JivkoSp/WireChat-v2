using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetGroupHandler : IQueryHandler<GetGroupQuery, GroupDto>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetGroupHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<GroupDto> HandleAsync(GetGroupQuery query)
        {
            var groupReadModel = await _readDbContext.Groups
                   .Include(x => x.Chat)
                   .ThenInclude(x => x.ChatUsers)
                   .ThenInclude(x => x.User)
                   .Include(x => x.Chat)
                   .ThenInclude(x => x.ChatMessages)
                   .ThenInclude(x => x.User)
                   .AsNoTracking()
                   .SingleOrDefaultAsync(x => x.Chat.ChatId == query.ChatId);

            return _mapper.Map<GroupDto>(groupReadModel);
        }
    }
}
