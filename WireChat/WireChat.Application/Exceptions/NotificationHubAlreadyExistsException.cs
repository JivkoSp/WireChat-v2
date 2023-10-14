
namespace WireChat.Application.Exceptions
{
    public sealed class NotificationHubAlreadyExistsException : ApplicationException
    {
        internal NotificationHubAlreadyExistsException(Guid notificationHubId) 
            : base(message: $"NotificationHub with ID #{notificationHubId} already exists!")
        {
        }
    }
}
