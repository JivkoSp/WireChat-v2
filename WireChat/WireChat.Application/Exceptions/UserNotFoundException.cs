
namespace WireChat.Application.Exceptions
{
    public sealed class UserNotFoundException : ApplicationException
    {
        internal UserNotFoundException(Guid userId) 
            : base(message: $"User with ID {userId} was not found!")
        {
        }
    }
}
