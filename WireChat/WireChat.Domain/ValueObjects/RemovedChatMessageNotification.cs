﻿using WireChat.Domain.Exceptions;

namespace WireChat.Domain.ValueObjects
{
    public record RemovedChatMessageNotification
    {
        public ChatID ChatId { get; }
        public ChatMessageID ChatMessageId { get; }
        public UserID UserId { get; }
        internal DateTimeOffset DateTime { get; }

        public RemovedChatMessageNotification(ChatID chatId, ChatMessageID chatMessageId, UserID userId, DateTimeOffset dateTime)
        {
            if (chatId == null)
            {
                throw new NullChatIdException();
            }

            if (chatMessageId == null)
            {
                throw new NullChatMessageIdException();
            }

            if(userId == null)
            {
                throw new NullUserIdException();
            }

            if (dateTime == default || dateTime > DateTimeOffset.Now)
            {
                throw new InvalidRemovedChatMessageDateTimeException();
            }

            ChatId = chatId;
            ChatMessageId = chatMessageId;
            UserId = userId;
            DateTime = dateTime;
        }
    }
}
