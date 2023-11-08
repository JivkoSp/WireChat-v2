using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetAllUsersChatMessagesHandler : IQueryHandler<GetAllUsersChatMessagesQuery, List<ChatMessageDto>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetAllUsersChatMessagesHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<List<ChatMessageDto>> HandleAsync(GetAllUsersChatMessagesQuery query)
        {
            var chatMessageReadModels = await _readDbContext.ChatMessageReadModels
                .Include(x => x.Chat)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<ChatMessageDto>>(chatMessageReadModels);
        }
    }
}
