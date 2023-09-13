using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record UserEmail
    {
        internal string Value { get; }

        public UserEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserEmailException();
            }

            Value = value;
        }

        //Conversion from ValueObject to String.
        public static implicit operator string(UserEmail userEmail)
            => userEmail.Value;

        //Conversion from String to ValueObject.
        public static implicit operator UserEmail(string userEmail)
            => new UserEmail(userEmail);
    }
}
