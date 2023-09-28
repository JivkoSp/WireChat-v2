
namespace WireChat.Application.Exceptions
{
    public sealed class GroupNotFoundException : ApplicationException
    {
        public GroupNotFoundException(Guid chatId) 
            : base(message: $"Group with ID #{chatId} was NOT found!")
        {
        }
    }
}
