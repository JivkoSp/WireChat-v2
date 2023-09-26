using WireChat.Domain.Exceptions;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Entities
{
    public class Group : AggregateRoot<GroupID>
    {
        private GroupName _groupName;
        private Chat _chat;

        private Group() {}

        public Group(GroupID groupId, GroupName groupName, Chat chat)
        {
            ValidateConstructorParameters<NullGroupParametersException>([groupId, groupName, chat]);

            Id = groupId;
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
