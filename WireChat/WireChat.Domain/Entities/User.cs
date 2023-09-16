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
        private List<UserContactRequest> _contactRequests = new List<UserContactRequest>();
        
        public IReadOnlyCollection<UserContactRequest> ContactRequests
        {
            get { return new ReadOnlyCollection<UserContactRequest>(_contactRequests); }
        }

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

        // Add contact request to the receiver side.
        public void AddContactRequest(UserContactRequest contactRequest)
        {
            var alreadyExists = _contactRequests.Any(x => x.SenderUserId == contactRequest.SenderUserId);

            if (alreadyExists)
            {
                throw new UserContactRequestAlreadyExistsException(contactRequest.SenderUserId);
            }

            _contactRequests.Add(contactRequest);

            AddEvent(new UserContactRequestAdded(this, contactRequest));
        }

        public void RemoveReceivedContactRequest(UserID senderUserId)
        {
            var contactRequest = _contactRequests.SingleOrDefault(x => x.SenderUserId == senderUserId);
            
            if (contactRequest is null)
            {
                throw new UserContactRequestNotFoundException(senderUserId);
            }

            _contactRequests.Remove(contactRequest);

            AddEvent(new UserContactRequestRemoved(this, contactRequest));
        }

        public void RemoveIssuedContactRequest(UserID receiverUserId)
        {
            var contactRequest = _contactRequests.SingleOrDefault(x => x.ReceiverUserId == receiverUserId);
            
            if (contactRequest is null)
            {
                throw new UserContactRequestNotFoundException(receiverUserId);
            }

            _contactRequests.Remove(contactRequest);

            AddEvent(new UserContactRequestRemoved(this, contactRequest));
        }
    }
}
