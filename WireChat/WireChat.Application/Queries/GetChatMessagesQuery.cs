using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetChatMessagesQuery : IQuery<List<ChatMessageDto>>;
}