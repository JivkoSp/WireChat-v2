using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetReceivedContactRequestsHandler 
        : IQueryHandler<GetReceivedContactRequestsQuery, List<UserContactRequestDto>>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetReceivedContactRequestsHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<List<UserContactRequestDto>> HandleAsync(GetReceivedContactRequestsQuery query)
        {
            var userContactRequestReadModels = await _readDbContext.UserContactRequestReadModels
                .Where(x => x.ReceiverUserId == query.UserId)
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<UserContactRequestDto>>(userContactRequestReadModels);
        }
    }
}
