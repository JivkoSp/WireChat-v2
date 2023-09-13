using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record UserLastName
    {
        internal string Value { get; }

        public UserLastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserLastNameException();
            }

            Value = value;
        }

        //Conversion from ValueObject to String.
        public static implicit operator string(UserLastName userLastName)
            => userLastName.Value;

        //Conversion from String to ValueObject.
        public static implicit operator UserLastName(string userLastName)
            => new UserLastName(userLastName);
    }
}
