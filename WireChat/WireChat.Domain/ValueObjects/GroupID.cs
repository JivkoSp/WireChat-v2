using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record GroupID
    {
        public Guid Value { get; }

        public GroupID(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyGuidIdException();
            }

            Value = value;
        }

        //Conversion from ValueObject to Guid.
        public static implicit operator Guid(GroupID groupId)
            => groupId.Value;

        //Conversion from Guid to ValueObject.
        public static implicit operator GroupID(Guid groupId)
            => new GroupID(groupId);
    }
}
