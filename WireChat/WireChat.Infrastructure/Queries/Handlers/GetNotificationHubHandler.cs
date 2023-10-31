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
                .ThenInclude(x => x.Sender)
                .Include(x => x.IssuedContactRequestNotifications)
                .ThenInclude(x => x.Receiver)
                .Include(x => x.ReceivedContactRequestNotifications)
                .ThenInclude(x => x.Sender)
                .Include(x => x.ReceivedContactRequestNotifications)
                .ThenInclude(x => x.Receiver)
                .Include(x => x.AcceptedContactRequestNotifications)
                .ThenInclude(x => x.Sender)
                .Include(x => x.AcceptedContactRequestNotifications)
                .ThenInclude(x => x.Receiver)
                .Include(x => x.DeclinedContactRequestNotifications)
                .ThenInclude(x => x.Sender)
                .Include(x => x.DeclinedContactRequestNotifications)
                .ThenInclude(x => x.Receiver)
                .Include(x => x.ActiveGroupNotifications)
                .ThenInclude(x => x.Group)
                .Include(x => x.AddedGroupMemberNotifications)
                .ThenInclude(x => x.Group)
                .Include(x => x.AddedGroupMemberNotifications)
                .ThenInclude(x => x.GroupAdmin)
                .Include(x => x.AddedGroupMemberNotifications)
                .ThenInclude(x => x.GroupMember)
                .Include(x => x.RemovedGroupMemberNotifications)
                .ThenInclude(x => x.Group)
                .Include(x => x.RemovedGroupMemberNotifications)
                .ThenInclude(x => x.GroupAdmin)
                .Include(x => x.RemovedGroupMemberNotifications)
                .ThenInclude(x => x.GroupMember)
                .Include(x => x.BannedContactNotifications)
                .ThenInclude(x => x.User)
                .Include(x => x.BannedGroupMemberNotifications)
                .ThenInclude(x => x.Group)
                .Include(x => x.BannedGroupMemberNotifications)
                .ThenInclude(x => x.GroupAdmin)
                .Include(x => x.BannedGroupMemberNotifications)
                .ThenInclude(x => x.GroupMember)
                .Include(x => x.CreatedGroupNotifications)
                .ThenInclude(x => x.User)
                .Include(x => x.CreatedGroupNotifications)
                .ThenInclude(x => x.Group)
                .Include(x => x.RemovedChatMessageNotifications)
                .ThenInclude(x => x.User)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.NotificationHubId == query.NotificationHubId);

            return _mapper.Map<NotificationHubDto>(notificationHubReadModel);
        }
    }
}
