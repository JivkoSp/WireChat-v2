using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public class BlockedChatUser
    {
        public UserID UserID { get; }
        public ChatID ChatID { get; }

        private BlockedChatUser() {}

        public BlockedChatUser(UserID userId, ChatID chatId)
        {
            if (userId == null)
            {
                throw new NullUserIdException();
            }

            if (chatId == null)
            {
                throw new NullChatIdException();
            }

            UserID = userId;
            ChatID = chatId;
        }
    }
}
