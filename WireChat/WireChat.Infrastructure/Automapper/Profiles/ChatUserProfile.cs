using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class ChatUserProfile : Profile
    {
        public ChatUserProfile()
        {
            CreateMap<ChatUserReadModel, ChatUserDto>();
        }
    }
}
