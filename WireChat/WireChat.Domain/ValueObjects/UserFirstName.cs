using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record UserFirstName
    {
        internal string Value { get; }

        public UserFirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserFirstNameException();
            }

            Value = value;
        }

        //Conversion from ValueObject to String.
        public static implicit operator string(UserFirstName userFirstName)
            => userFirstName.Value; 

        //Conversion from String to ValueObject.
        public static implicit operator UserFirstName(string userFirstName)
            => new UserFirstName(userFirstName);
    }
}
