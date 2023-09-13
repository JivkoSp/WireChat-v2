using WireChat.Domain.Exceptions;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Entities
{
    public enum ChatType
    {
        OneToOne,
        Group
    };

    public class Chat : AggregateRoot<ChatID>
    {
        private ChatType _chatType;
        private List<User> _users;

        private Chat() {}

        public Chat(ChatID chatId, ChatType chatType)
        {
            ValidateConstructorParameters<NullChatParametersException>([chatId, chatType]);

            Id = chatId;
            _chatType = chatType;
        }
    }
}
