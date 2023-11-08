using WireChat.Application.Dtos;

namespace WireChat.Application.Queries
{
    public record GetAllUsersChatMessagesQuery : IQuery<List<ChatMessageDto>>;
}
