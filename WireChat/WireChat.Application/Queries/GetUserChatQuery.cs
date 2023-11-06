
namespace WireChat.Application.Queries
{
    public record GetUserChatQuery(string IssuerUserId, string ReceiverUserId) : IQuery<Guid>;
}
