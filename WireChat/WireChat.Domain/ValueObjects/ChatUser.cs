using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record ChatUser
    {
        public UserID UserID { get; }
        public ChatID ChatID { get; }

        public ChatUser(UserID userId, ChatID chatId)
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
