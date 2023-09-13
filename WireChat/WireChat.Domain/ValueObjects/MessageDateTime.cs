using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record MessageDateTime
    {
        internal DateTimeOffset DateTime { get; }

        public MessageDateTime(DateTimeOffset dateTime)
        {
            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidMessageDateTimeException();
            }

            DateTime = dateTime;
        }

        //Conversion from ValueObject to DateTimeOffset.
        public static implicit operator DateTimeOffset(MessageDateTime messageDateTime)
            => messageDateTime.DateTime;

        //Conversion from DateTimeOffset to ValueObject.
        public static implicit operator MessageDateTime(DateTimeOffset messageDateTime)
            => new MessageDateTime(messageDateTime);
    }
}
