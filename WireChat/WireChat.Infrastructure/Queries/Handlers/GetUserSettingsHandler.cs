using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetUserSettingsHandler : IQueryHandler<GetUserSettingsQuery, UserDto>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetUserSettingsHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> HandleAsync(GetUserSettingsQuery query)
        {
            var userReadModel = await _readDbContext.UserReadModels
               .Include(x => x.BlockedChatUsers)
               .AsNoTracking()
               .SingleOrDefaultAsync(x => x.Id == query.UserId);

            return _mapper.Map<UserDto>(userReadModel);
        }
    }
}
