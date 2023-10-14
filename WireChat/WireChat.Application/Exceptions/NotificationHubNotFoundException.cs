
namespace WireChat.Application.Exceptions
{
    public sealed class NotificationHubNotFoundException : ApplicationException
    {
        internal NotificationHubNotFoundException(Guid notificationHubId) 
            : base(message: $"NotificationHub with ID #{notificationHubId} was NOT found!")
        {
        }
    }
}
