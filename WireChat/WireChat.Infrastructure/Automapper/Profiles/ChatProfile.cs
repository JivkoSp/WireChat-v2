using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<ChatReadModel, ChatDto>();
        }
    }
}
