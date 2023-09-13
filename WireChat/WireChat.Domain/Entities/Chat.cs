using WireChat.Domain.Events;
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
        private HashSet<ChatUser> _users =new HashSet<ChatUser>();

        private Chat() {}

        public Chat(ChatID chatId, ChatType chatType)
        {
            ValidateConstructorParameters<NullChatParametersException>([chatId, chatType]);

            Id = chatId;
            _chatType = chatType;
        }

        //Add ChatUser to OneToOne or Group chat
        public void AddChatUser(ChatUser chatUser)
        {
            var alreadyExists = _users.Contains(chatUser);  

            if (alreadyExists)
            {
                throw new ChatUserAlreadyExistsException(chatUser.UserID, chatUser.ChatID);
            }

            _users.Add(chatUser);

            AddEvent(new ChatUserAdded(this, chatUser));
        }

        //Remove ChatUser from Group chat.
        public void RemoveChatUser(ChatUser chatUser)
        {
            var chatUserToRemove = _users.SingleOrDefault(chatUser);

            if (chatUserToRemove is null)
            {
                throw new ChatUserNotFoundException(chatUser.UserID, chatUser.ChatID);
            }
        }
    }
}
