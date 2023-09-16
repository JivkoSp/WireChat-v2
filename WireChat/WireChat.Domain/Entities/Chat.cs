using WireChat.Domain.Events;
using WireChat.Domain.Exceptions;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Entities
{
    public class Chat : AggregateRoot<ChatID>
    {
        private ChatType _chatType;
        private HashSet<ChatUser> _users =new HashSet<ChatUser>();
        private List<ChatMessage> _messages = new List<ChatMessage>();

        private Chat() {}

        internal Chat(ChatID chatId, ChatType chatType)
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
        public void RemoveChatUser(UserID userId)
        {
            var chatUserToRemove = _users.SingleOrDefault(x => x.UserID == userId);

            if (chatUserToRemove is null)
            {
                throw new ChatUserNotFoundException(userId, Id);
            }

            _users.Remove(chatUserToRemove);

            AddEvent(new ChatUserRemoved(this, chatUserToRemove));
        }

        public void AddMessage(ChatMessage chatMessage)
        {
            var alreadyExists = _messages.Any(x => x.Id == chatMessage.Id);

            if (alreadyExists)
            {
                throw new ChatMessageAlreadyExistsException(chatMessage.Id);
            }

            _messages.Add(chatMessage);

            AddEvent(new ChatMessageAdded(this, chatMessage));
        }

        public void RemoveMessage(ChatMessageID chatMessageId)
        {
            var chatMessage = _messages.SingleOrDefault(x => x.Id == chatMessageId);

            if (chatMessage is null)
            {
                throw new ChatMessageNotFoundException(chatMessageId);
            }

            _messages.Remove(chatMessage);

            AddEvent(new ChatMessageRemoved(this, chatMessage));
        }
    }
}
