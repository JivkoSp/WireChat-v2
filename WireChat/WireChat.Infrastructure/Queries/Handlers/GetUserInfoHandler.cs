using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetUserInfoHandler : IQueryHandler<GetUserInfoQuery, UserInfoDto>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetUserInfoHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<UserInfoDto> HandleAsync(GetUserInfoQuery query)
        {
            var userReadModel = await _readDbContext.UserReadModels
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == query.UserId);

            return _mapper.Map<UserInfoDto>(userReadModel);
        }
    }
}
