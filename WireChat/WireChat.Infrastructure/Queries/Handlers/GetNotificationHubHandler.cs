using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WireChat.Application.Dtos;
using WireChat.Application.Queries;
using WireChat.Application.Queries.Handlers;
using WireChat.Infrastructure.EntityFramework.Contexts;

namespace WireChat.Infrastructure.Queries.Handlers
{
    internal sealed class GetNotificationHubHandler : IQueryHandler<GetNotificationHubQuery, NotificationHubDto>
    {
        private readonly ReadDbContext _readDbContext;
        private readonly IMapper _mapper;

        public GetNotificationHubHandler(ReadDbContext readDbContext, IMapper mapper)
        {
            _readDbContext = readDbContext;
            _mapper = mapper;
        }

        public async Task<NotificationHubDto> HandleAsync(GetNotificationHubQuery query)
        {
            var notificationHubReadModel = await _readDbContext.NotificationHubReadModels
                .Include(x => x.IssuedContactRequestNotifications)
                .Include(x => x.ReceivedContactRequestNotifications)
                .Include(x => x.AcceptedContactRequestNotifications)
                .Include(x => x.DeclinedContactRequestNotifications)
                .Include(x => x.ActiveGroupNotifications)
                .Include(x => x.AddedGroupMemberNotifications)
                .Include(x => x.RemovedGroupMemberNotifications)
                .Include(x => x.BannedContactNotifications)
                .Include(x => x.BannedGroupMemberNotifications)
                .Include(x => x.CreatedGroupNotifications)
                .Include(x => x.RemovedChatMessageNotifications)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.NotificationHubId == query.NotificationHubId);

            return _mapper.Map<NotificationHubDto>(notificationHubReadModel);
        }
    }
}
