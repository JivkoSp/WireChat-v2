using System.Collections.ObjectModel;
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
        private List<User> _contacts;
        private List<UserContactRequest> _contactRequests;
        
        public IReadOnlyCollection<User> Contacts
        {
            get { return new ReadOnlyCollection<User>(_contacts); }
        }

        public IReadOnlyCollection<UserContactRequest> ContactRequests
        {
            get { return new ReadOnlyCollection<UserContactRequest>(_contactRequests); }
        }

        private User() {}

        public User(UserID userId, UserFirstName userFirstName, UserLastName userLastName, UserName userName, UserEmail userEmail)
        {
            ValidateConstructorParameters<NullUserParametersException>([userId, userFirstName, userLastName, userName, userEmail]);

            Id = userId;
            _firstName = userFirstName;
            _lastName = userLastName;
            _userName = userName;
            _email = userEmail;
        }
    }
}
