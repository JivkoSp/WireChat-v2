using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record UserName
    {
        internal string Value { get; }

        public UserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserNameException();
            }

            Value = value;
        }

        //Conversion from ValueObject to String.
        public static implicit operator string(UserName userName)
            => userName.Value;

        //Conversion from String to ValueObject.
        public static implicit operator UserName(string userName)
            => new UserName(userName);
    }
}
