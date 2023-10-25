using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetGroupByNameHandler : IQueryHandler<GetGroupByNameQuery, GroupDto>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetGroupByNameHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<GroupDto> HandleAsync(GetGroupByNameQuery query)
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

            var group = groupReadModels.SingleOrDefault(x => x.GroupName == query.GroupName);

            return _mapper.Map<GroupDto>(group);
        }
    }
}
