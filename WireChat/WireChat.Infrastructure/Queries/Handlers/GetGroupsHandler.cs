using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetGroupsHandler : IQueryHandler<GetGroupsQuery, List<GroupDto>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetGroupsHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<List<GroupDto>> HandleAsync(GetGroupsQuery query)
        {
            var chatReadModels = await _readDbContext.ChatUserReadModels
                .Include(x => x.Chat)
                .Where(x => x.UserId == query.UserId)
                .Select(x => x.Chat)
                .AsNoTracking()
                .ToListAsync();

            var groupReadModels = await _readDbContext.Groups
                .Include(x => x.Chat)
                .Where(x => chatReadModels.Contains(x.Chat))
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<GroupDto>>(groupReadModels);
        }
    }
}
