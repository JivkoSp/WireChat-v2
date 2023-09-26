using System.Collections.ObjectModel;
using WireChat.Domain.Events;
using WireChat.Domain.Exceptions;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Entities
{
    public class User : AggregateRoot<UserID>
    {
        private UserFirstName _firstName;
        private UserLastName _lastName;
        private UserName _userName;
        private UserEmail _email;
        private List<UserContactRequest> _sendedContactRequests = new List<UserContactRequest>();
        private List<UserContactRequest> _receivedContactRequests = new List<UserContactRequest>();

        public IReadOnlyCollection<UserContactRequest> SendedContactRequests => 
                new ReadOnlyCollection<UserContactRequest>(_sendedContactRequests);

        public IReadOnlyCollection<UserContactRequest> ReceivedContactRequests => 
                new ReadOnlyCollection<UserContactRequest>(_receivedContactRequests);

        private User() {}

        internal User(UserID userId, UserFirstName userFirstName, UserLastName userLastName, UserName userName, UserEmail userEmail)
        {
            ValidateConstructorParameters<NullUserParametersException>([userId, userFirstName, userLastName, userName, userEmail]);

            Id = userId;
            _firstName = userFirstName;
            _lastName = userLastName;
            _userName = userName;
            _email = userEmail;
        }

        public void AddContactRequest(UserContactRequest contactRequest)
        {
            var alreadyExists = _sendedContactRequests.Any(x => x.ReceiverUserId == contactRequest.ReceiverUserId);

            if (alreadyExists)
            {
                throw new UserContactRequestAlreadyExistsException(contactRequest.ReceiverUserId);
            }

            _sendedContactRequests.Add(contactRequest);

            AddEvent(new UserContactRequestAdded(this, contactRequest));
        }

        public void RemoveIssuedContactRequest(UserID receiverUserId)
        {
            var contactRequest = _sendedContactRequests.SingleOrDefault(x => x.ReceiverUserId == receiverUserId);

            if (contactRequest is null)
            {
                throw new UserContactRequestNotFoundException(receiverUserId);
            }

            _sendedContactRequests.Remove(contactRequest);

            AddEvent(new UserContactRequestRemoved(this, contactRequest));
        }

        public void RemoveReceivedContactRequest(UserID senderUserId)
        {
            var contactRequest = _receivedContactRequests.SingleOrDefault(x => x.SenderUserId == senderUserId);
            
            if (contactRequest is null)
            {
                throw new UserContactRequestNotFoundException(senderUserId);
            }

            _receivedContactRequests.Remove(contactRequest);

            AddEvent(new UserContactRequestRemoved(this, contactRequest));
        }
    }
}
