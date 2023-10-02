using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<ChatReadModel, ChatDto>()
                .ForMember(dest => dest.ChatMessageDtos, opt => opt.MapFrom(src => src.ChatMessages))
                .ForMember(dest => dest.ChatUserDtos, opt => opt.MapFrom(src => src.ChatUsers))
                .ForMember(dest => dest.BlockedChatUserDtos, opt => opt.MapFrom(src => src.BlockedChatUsers));
        }
    }
}
