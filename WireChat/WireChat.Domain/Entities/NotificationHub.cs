using System.Collections.ObjectModel;
using WireChat.Domain.Events;
using WireChat.Domain.Exceptions;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Entities
{
    public class NotificationHub : AggregateRoot<NotificationHubID>
    {
        private List<IssuedContactRequestNotification> _issuedContactRequestNotifications = new List<IssuedContactRequestNotification>();
        private List<ReceivedContactRequestNotification> _receivedContactRequestNotifications = new List<ReceivedContactRequestNotification>();
        private List<AcceptedContactRequestNotification> _acceptedContactRequestNotifications = new List<AcceptedContactRequestNotification>();
        private List<DeclinedContactRequestNotification> _declinedContactRequestNotifications = new List<DeclinedContactRequestNotification>();
        private HashSet<ActiveGroupNotification> _activeGroupNotifications = new HashSet<ActiveGroupNotification>();   
        private List<AddedGroupMemberNotification> _addedGroupMemberNotifications = new List<AddedGroupMemberNotification>();
        private List<RemovedGroupMemberNotification> _removedGroupMemberNotifications = new List<RemovedGroupMemberNotification>();
        private List<BannedContactNotification> _bannedContactNotifications = new List<BannedContactNotification>(); 
        private List<BannedGroupMemberNotification> _bannedGroupMemberNotifications = new List<BannedGroupMemberNotification>(); 
        private List<CreatedGroupNotification> _createdGroupNotifications = new List<CreatedGroupNotification>();
        private List<RemovedChatMessageNotification> _removedChatMessageNotifications = new List<RemovedChatMessageNotification>();
        public IReadOnlyCollection<IssuedContactRequestNotification> IssuedContactRequestNotifications => 
            new ReadOnlyCollection<IssuedContactRequestNotification>(_issuedContactRequestNotifications);
        public IReadOnlyCollection<ReceivedContactRequestNotification> ReceivedContactRequestNotifications =>
            new ReadOnlyCollection<ReceivedContactRequestNotification>(_receivedContactRequestNotifications);
        public IReadOnlyCollection<AcceptedContactRequestNotification> AcceptedContactRequestNotifications =>
            new ReadOnlyCollection<AcceptedContactRequestNotification>(_acceptedContactRequestNotifications);
        public IReadOnlyCollection<DeclinedContactRequestNotification> DeclinedContactRequestNotifications =>
            new ReadOnlyCollection<DeclinedContactRequestNotification>(_declinedContactRequestNotifications);
        public IReadOnlyCollection<ActiveGroupNotification> ActiveGroupNotifications =>
            new ReadOnlyCollection<ActiveGroupNotification>(_activeGroupNotifications.ToList());
        public IReadOnlyCollection<AddedGroupMemberNotification> AddedGroupMemberNotifications =>
            new ReadOnlyCollection<AddedGroupMemberNotification>(_addedGroupMemberNotifications);
        public IReadOnlyCollection<RemovedGroupMemberNotification> RemovedGroupMemberNotifications =>
            new ReadOnlyCollection<RemovedGroupMemberNotification>(_removedGroupMemberNotifications);
        public IReadOnlyCollection<BannedContactNotification> BannedContactNotifications =>
            new ReadOnlyCollection<BannedContactNotification>(_bannedContactNotifications);
        public IReadOnlyCollection<BannedGroupMemberNotification> BannedGroupMemberNotifications =>
            new ReadOnlyCollection<BannedGroupMemberNotification>(_bannedGroupMemberNotifications);
        public IReadOnlyCollection<CreatedGroupNotification> CreatedGroupNotifications =>
            new ReadOnlyCollection<CreatedGroupNotification>(_createdGroupNotifications);
        public IReadOnlyCollection<RemovedChatMessageNotification> RemovedChatMessageNotifications =>
            new ReadOnlyCollection<RemovedChatMessageNotification>(_removedChatMessageNotifications);
        
        private NotificationHub() {}

        internal NotificationHub(NotificationHubID notificationId)
        {
            ValidateConstructorParameters<NullNotificationHubParametersException>([notificationId]);

            Id = notificationId;
        }

        public void AddIssuedContactRequestNotification(IssuedContactRequestNotification issuedContactRequestNotification)
        {
            var alreadyExists = _issuedContactRequestNotifications.Any(x => x.ReceiverUserId == issuedContactRequestNotification.ReceiverUserId);

            if (alreadyExists)
            {
                throw new IssuedContactRequestNotificationAlreadyExistsException(issuedContactRequestNotification.ReceiverUserId);
            }

            _issuedContactRequestNotifications.Add(issuedContactRequestNotification);

            AddEvent(new IssuedContactRequestNotificationAdded(this, issuedContactRequestNotification));
        }

        public void RemoveIssuedContactRequestNotification(UserID receiverUserId)
        {
            var issuedContactRequestNotification = _issuedContactRequestNotifications.SingleOrDefault(x => x.ReceiverUserId == receiverUserId);

            if (issuedContactRequestNotification is null)
            {
                throw new IssuedContactRequestNotificationNotFoundException(Id, receiverUserId);
            }

            _issuedContactRequestNotifications.Remove(issuedContactRequestNotification);

            AddEvent(new IssuedContactRequestNotificationRemoved(this, issuedContactRequestNotification));
        }

        public void AddReceivedContactRequestNotification(ReceivedContactRequestNotification receivedContactRequestNotification)
        {
            var alreadyExists = _receivedContactRequestNotifications.Any(x => x.SenderUserId == receivedContactRequestNotification.SenderUserId);

            if (alreadyExists)
            {
                throw new ReceivedContactRequestNotificationAlreadyExistsException(Id, receivedContactRequestNotification.SenderUserId);
            }

            _receivedContactRequestNotifications.Add(receivedContactRequestNotification);

            AddEvent(new ReceivedContactRequestNotificationAdded(this, receivedContactRequestNotification));
        }

        public void RemoveReceivedContactRequestNotification(UserID senderUserId)
        {
            var receivedContactRequestNotification = _receivedContactRequestNotifications.SingleOrDefault(x => x.SenderUserId == senderUserId);

            if (receivedContactRequestNotification is null)
            {
                throw new ReceivedContactRequestNotificationNotFoundException(Id, senderUserId);
            }

            _receivedContactRequestNotifications.Remove(receivedContactRequestNotification);

            AddEvent(new ReceivedContactRequestNotificationRemoved(this, receivedContactRequestNotification));
        }

        public void AddAcceptedContactRequestNotification(AcceptedContactRequestNotification acceptedContactRequestNotification)
        {
            var alreadyExists = _acceptedContactRequestNotifications.Any(x => x.SenderUserId == acceptedContactRequestNotification.SenderUserId);

            if (alreadyExists)
            {
                throw new AcceptedContactRequestNotificationAlreadyExistsException(acceptedContactRequestNotification.SenderUserId);
            }

            _acceptedContactRequestNotifications.Add(acceptedContactRequestNotification);

            AddEvent(new AcceptedContactRequestNotificationAdded(this, acceptedContactRequestNotification));
        }

        public void RemoveAcceptedContactRequestNotification(UserID senderUserId)
        {
            var acceptedContactRequestNotification = _acceptedContactRequestNotifications.SingleOrDefault(x => x.SenderUserId == senderUserId);

            if (acceptedContactRequestNotification is null)
            {
                throw new AcceptedContactRequestNotificationNotFoundException(Id, senderUserId);
            }

            _acceptedContactRequestNotifications.Remove(acceptedContactRequestNotification);

            AddEvent(new AcceptedContactRequestNotificationRemoved(this, acceptedContactRequestNotification));
        }

        public void AddDeclinedContactRequestNotification(DeclinedContactRequestNotification declinedContactRequestNotification)
        {
            var alreadyExists = _declinedContactRequestNotifications.Any(x => x.SenderUserId == declinedContactRequestNotification.SenderUserId);

            if (alreadyExists)
            {
                throw new DeclinedContactRequestNotificationAlreadyExistsException(declinedContactRequestNotification.SenderUserId);
            }

            _declinedContactRequestNotifications.Add(declinedContactRequestNotification);

            AddEvent(new DeclinedContactRequestNotificationAdded(this, declinedContactRequestNotification));
        }

        public void RemoveDeclinedContactRequestNotification(UserID senderUserId)
        {
            var declinedContactRequestNotification = _declinedContactRequestNotifications.SingleOrDefault(x => x.SenderUserId == senderUserId);

            if (declinedContactRequestNotification is null)
            {
                throw new DeclinedContactRequestNotificationNotFoundException(Id, senderUserId);
            }

            _declinedContactRequestNotifications.Remove(declinedContactRequestNotification);

            AddEvent(new DeclinedContactRequestNotificationRemoved(this, declinedContactRequestNotification));
        }

        public void AddActiveGroupNotification(ActiveGroupNotification activeGroupNotification)
        {
            var alreadyExists = _activeGroupNotifications.Contains(activeGroupNotification);

            if (alreadyExists)
            {
                throw new ActiveGroupNotificationAlreadyExistsException(activeGroupNotification.GroupId);
            }

            _activeGroupNotifications.Add(activeGroupNotification);

            AddEvent(new ActiveGroupNotificationAdded(this, activeGroupNotification));
        }

        public void RemoveActiveGroupNotification(GroupID groupId)
        {
            var activeGroupNotification = _activeGroupNotifications.SingleOrDefault(x => x.GroupId == groupId);

            if (activeGroupNotification is null)
            {
                throw new ActiveGroupNotificationNotFoundException(Id, groupId);
            }

            _activeGroupNotifications.Remove(activeGroupNotification);

            AddEvent(new ActiveGroupNotificationRemoved(this, activeGroupNotification));
        }

        public void AddAddedGroupMemberNotification(AddedGroupMemberNotification addedGroupMemberNotification)
        {
            var alreadyExists = _addedGroupMemberNotifications.Any(x => x.GroupMemberUserId == addedGroupMemberNotification.GroupMemberUserId);

            if (alreadyExists)
            {
                throw new AddedGroupMemberNotificationAlreadyExistsException(addedGroupMemberNotification.GroupMemberUserId, 
                    addedGroupMemberNotification.GroupId);
            }

            _addedGroupMemberNotifications.Add(addedGroupMemberNotification);

            AddEvent(new AddedGroupMemberNotificationAdded(this, addedGroupMemberNotification));
        }

        public void RemoveAddedGroupMemberNotification(UserID groupMemberUserId)
        {
            var addedGroupMemberNotification = _addedGroupMemberNotifications.SingleOrDefault(x => x.GroupMemberUserId == groupMemberUserId);

            if (addedGroupMemberNotification is null)
            {
                throw new AddedGroupMemberNotificationNotFoundException(Id, groupMemberUserId);
            }

            _addedGroupMemberNotifications.Remove(addedGroupMemberNotification);

            AddEvent(new AddedGroupMemberNotificationRemoved(this, addedGroupMemberNotification));
        }

        public void AddRemovedGroupMemberNotification(RemovedGroupMemberNotification removedGroupMemberNotification)
        {
            var alreadyExists = _removedGroupMemberNotifications.Any(x => x.GroupMemberUserId == removedGroupMemberNotification.GroupMemberUserId);

            if (alreadyExists)
            {
                throw new RemovedGroupMemberNotificationAlreadyExistsException(removedGroupMemberNotification.GroupMemberUserId,
                    removedGroupMemberNotification.GroupId);
            }

            _removedGroupMemberNotifications.Add(removedGroupMemberNotification);

            AddEvent(new RemovedGroupMemberNotificationAdded(this, removedGroupMemberNotification));
        }

        public void RemoveRemovedGroupMemberNotification(UserID groupMemberUserId)
        {
            var removedGroupMemberNotification = _removedGroupMemberNotifications.SingleOrDefault(x => x.GroupMemberUserId == groupMemberUserId);

            if (removedGroupMemberNotification is null)
            {
                throw new RemovedGroupMemberNotificationNotFoundException(Id, groupMemberUserId);
            }

            _removedGroupMemberNotifications.Remove(removedGroupMemberNotification);

            AddEvent(new RemovedGroupMemberNotificationRemoved(this, removedGroupMemberNotification));
        }

        public void AddBannedContactNotification(BannedContactNotification bannedContactNotification)
        {
            var alreadyExists = _bannedContactNotifications.Any(x => x.UserId == bannedContactNotification.UserId);

            if (alreadyExists)
            {
                throw new BannedContactNotificationAlreadyExistsException(Id, bannedContactNotification.UserId);
            }

            _bannedContactNotifications.Add(bannedContactNotification);

            AddEvent(new BannedContactNotificationAdded(this, bannedContactNotification));
        }

        public void RemoveBannedContactNotification(UserID userId)
        {
            var bannedContactNotification = _bannedContactNotifications.SingleOrDefault(x => x.UserId == userId);

            if (bannedContactNotification is null)
            {
                throw new BannedContactNotificationNotFoundException(Id, userId);
            }

            _bannedContactNotifications.Remove(bannedContactNotification);

            AddEvent(new BannedContactNotificationRemoved(this, bannedContactNotification));
        }

        public void AddBannedGroupMemberNotification(BannedGroupMemberNotification bannedGroupMemberNotification)
        {
            var alreadyExists = _bannedGroupMemberNotifications.Any(x => x.GroupMemberUserId == bannedGroupMemberNotification.GroupMemberUserId);

            if (alreadyExists)
            {
                throw new BannedGroupMemberNotificationAlreadyExistsException(Id, bannedGroupMemberNotification.GroupMemberUserId);
            }

            _bannedGroupMemberNotifications.Add(bannedGroupMemberNotification);

            AddEvent(new BannedGroupMemberNotificationAdded(this, bannedGroupMemberNotification));
        }

        public void RemoveBannedGroupMemberNotification(UserID groupMemberUserId)
        {
            var bannedGroupMemberNotification = _bannedGroupMemberNotifications.SingleOrDefault(x => x.GroupMemberUserId == groupMemberUserId);

            if(bannedGroupMemberNotification is null)
            {
                throw new BannedGroupMemberNotificationNotFoundException(Id, groupMemberUserId);
            }

            _bannedGroupMemberNotifications.Remove(bannedGroupMemberNotification);

            AddEvent(new BannedGroupMemberNotificationRemoved(this, bannedGroupMemberNotification));
        }

        public void AddCreatedGroupNotification(CreatedGroupNotification createdGroupNotification)
        {
            var alreadyExists = _createdGroupNotifications.Any(x => x.GroupId == createdGroupNotification.GroupId);

            if (alreadyExists)
            {
                throw new CreatedGroupNotificationAlreadyExistsException(Id, createdGroupNotification.GroupId);
            }

            _createdGroupNotifications.Add(createdGroupNotification);

            AddEvent(new CreatedGroupNotificationAdded(this, createdGroupNotification));
        }

        public void RemoveCreatedGroupNotification(GroupID groupId)
        {
            var createdGroupNotification = _createdGroupNotifications.SingleOrDefault(x => x.GroupId == groupId);

            if (createdGroupNotification is null)
            {
                throw new CreatedGroupNotificationNotFoundException(Id, createdGroupNotification.GroupId);
            }

            _createdGroupNotifications.Remove(createdGroupNotification);

            AddEvent(new CreatedGroupNotificationRemoved(this, createdGroupNotification));
        }

        public void AddRemovedChatMessageNotification(RemovedChatMessageNotification removedChatMessageNotification)
        {
            var alreadyExists = _removedChatMessageNotifications.Any(x => x.ChatMessageId == removedChatMessageNotification.ChatMessageId);

            if (alreadyExists)
            {
                throw new RemovedChatMessageNotificationAlreadyExistsException(Id, removedChatMessageNotification.ChatMessageId);
            }

            _removedChatMessageNotifications.Add(removedChatMessageNotification);

            AddEvent(new RemovedChatMessageNotificationAdded(this, removedChatMessageNotification));
        }

        public void RemoveRemovedChatMessageNotification(ChatMessageID chatMessageId)
        {
            var removedChatMessageNotification = _removedChatMessageNotifications.SingleOrDefault(x => x.ChatMessageId == chatMessageId);

            if(removedChatMessageNotification is null)
            {
                throw new RemovedChatMessageNotificationNotFoundException(Id, chatMessageId);
            }

            _removedChatMessageNotifications.Remove(removedChatMessageNotification);

            AddEvent(new RemovedChatMessageNotificationRemoved(this, removedChatMessageNotification));
        }
    }
}
