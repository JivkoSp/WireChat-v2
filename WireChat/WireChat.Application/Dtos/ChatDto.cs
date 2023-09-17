namespace WireChat.Application.Dtos
{
    public class ChatDto
    {
        public Guid ChatId { get; set; }
        public string ChatType { get; set; }
        public List <ChatUserDto> ChatUserDtos { get; set; }
        public List <ChatMessageDto> ChatMessageDtos { get; set; }
    }
}