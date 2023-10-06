
namespace WireChat.Domain.Exceptions
{
    public sealed class RemovedChatMessageNotificationAlreadyExistsException : DomainException
    {
        internal RemovedChatMessageNotificationAlreadyExistsException(Guid notificationHubID, Guid chatMessageId) 
            : base(message: $"Removed chat message notification for chat message with ID #{chatMessageId} already exists in notification hub with ID #{notificationHubID}!")
        {
        }
    }
}
