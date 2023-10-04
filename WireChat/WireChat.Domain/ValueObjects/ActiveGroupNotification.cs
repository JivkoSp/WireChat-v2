using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record ActiveGroupNotification
    {
        public GroupID GroupId { get; }

        public ActiveGroupNotification(GroupID groupId)
        {
            if (groupId == null)
            {
                throw new NullGroupIdException();
            }

            GroupId = groupId;
        }
    }
}
