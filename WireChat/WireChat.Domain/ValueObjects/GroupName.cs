using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record GroupName
    {
        internal string Value { get; }

        public GroupName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyGroupNameException();
            }

            Value = value;
        }

        //Conversion from ValueObject to String.
        public static implicit operator string(GroupName groupName)
            => groupName.Value;

        //Conversion from String to ValueObject.
        public static implicit operator GroupName(string groupName)
            => new GroupName(groupName);
    }
}
