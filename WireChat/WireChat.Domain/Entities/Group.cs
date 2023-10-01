using WireChat.Domain.Exceptions;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Entities
{
    public class Group : AggregateRoot<ChatID>
    {
        private GroupName _groupName;
        private readonly Chat _chat;

        public Chat Chat => _chat;

        private Group() {}

        public Group(ChatID chatId, GroupName groupName, Chat chat)
        {
            ValidateConstructorParameters<NullGroupParametersException>([chatId, groupName, chat]);

            Id = chatId;
            _groupName = groupName;
            _chat = chat;
        }

        public void AddChatUser(ChatUser chatUser)
        {
            _chat.AddChatUser(chatUser);
        }

        public void RemoveChatUser(UserID userId)
        {
            _chat.RemoveChatUser(userId);
        }

        public void AddMessage(ChatMessage chatMessage)
        {
            _chat.AddMessage(chatMessage); 
        }

        public void RemoveMessage(ChatMessageID chatMessageId)
        {
            _chat.RemoveMessage(chatMessageId); 
        }
    }
}
