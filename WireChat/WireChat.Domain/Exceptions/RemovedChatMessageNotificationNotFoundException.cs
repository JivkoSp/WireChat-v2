
namespace WireChat.Domain.Exceptions
{
    public sealed class RemovedChatMessageNotificationNotFoundException : DomainException
    {
        internal RemovedChatMessageNotificationNotFoundException(Guid notificationHubID, Guid chatMessageId) 
            : base(message: $"Removed chat message notification for chat message with ID #{chatMessageId} was not found in NotificationHub with ID #{notificationHubID}!")
        {
        }
    }
}
