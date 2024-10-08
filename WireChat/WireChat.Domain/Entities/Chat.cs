﻿using System.Collections.ObjectModel;
using WireChat.Domain.Events;
using WireChat.Domain.Exceptions;
using WireChat.Domain.ValueObjects;

namespace WireChat.Domain.Entities
{
    public class Chat : AggregateRoot<ChatID>
    {
        private ChatType _chatType;
        private HashSet<ChatUser> _users = new HashSet<ChatUser>();
        private HashSet<BlockedChatUser> _blockedUsers = new HashSet<BlockedChatUser>();
        private List<ChatMessage> _messages = new List<ChatMessage>();
        public IReadOnlyCollection<ChatUser> Users => new ReadOnlyCollection<ChatUser>(_users.ToList());
        public IReadOnlyCollection<BlockedChatUser> BlockedUsers => new ReadOnlyCollection<BlockedChatUser>(_blockedUsers.ToList());
        public IReadOnlyCollection<ChatMessage> Messages => new ReadOnlyCollection<ChatMessage>(_messages);

        private Chat() {}

        internal Chat(ChatID chatId, ChatType chatType)
        {
            ValidateConstructorParameters<NullChatParametersException>([chatId, chatType]);

            Id = chatId;
            _chatType = chatType;
        }

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

        public void BlockChatUser(BlockedChatUser blockedChatUser)
        {
            var alreadyExists = _blockedUsers.Contains(blockedChatUser);

            if (alreadyExists)
            {
                throw new BlockedChatUserAlreadyExistsException(blockedChatUser.UserID, blockedChatUser.ChatID);
            }

            _blockedUsers.Add(blockedChatUser);

            AddEvent(new BlockedChatUserAdded(this, blockedChatUser));
        }

        public void UnblockChatUser(UserID userId)
        {
            var chatUserToUnblock = _blockedUsers.SingleOrDefault(x => x.UserID == userId);

            if (chatUserToUnblock is null)
            {
                throw new BlockedChatUserNotFoundException(userId, Id);
            }

            _blockedUsers.Remove(chatUserToUnblock);

            AddEvent(new BlockedChatUserRemoved(this, chatUserToUnblock));
        }

        public void AddMessage(ChatMessage chatMessage)
        {
            var alreadyExists = _messages.Any(x => x.ChatMessageID == chatMessage.ChatMessageID);

            if (alreadyExists)
            {
                throw new ChatMessageAlreadyExistsException(chatMessage.ChatMessageID);
            }

            _messages.Add(chatMessage);

            AddEvent(new ChatMessageAdded(this, chatMessage));
        }

        public void RemoveMessage(ChatMessageID chatMessageId)
        {
            var chatMessage = _messages.SingleOrDefault(x => x.ChatMessageID == chatMessageId);

            if (chatMessage is null)
            {
                throw new ChatMessageNotFoundException(chatMessageId);
            }

            _messages.Remove(chatMessage);

            AddEvent(new ChatMessageRemoved(this, chatMessage));
        }
    }
}
