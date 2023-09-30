
namespace WireChat.Application.Exceptions
{
    public sealed class ContactNotFoundException : ApplicationException
    {
        internal ContactNotFoundException(Guid userId, Guid newChatUserId) 
            : base(message: $"User with ID #{userId} does not have contact with ID {newChatUserId}!")
        {
        }
    }
}
