using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetChatUserHandler : IQueryHandler<GetChatUserQuery, ChatUserDto>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetChatUserHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<ChatUserDto> HandleAsync(GetChatUserQuery query)
        {
            var chatUserReadModel = await _readDbContext.ChatUserReadModels
                    .Include(x => x.User)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.UserId == query.UserId);

            return _mapper.Map<ChatUserDto>(chatUserReadModel);
        }
    }
}
