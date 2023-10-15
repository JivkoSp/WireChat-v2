using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class ActiveGroupNotificationProfile : Profile
    {
        public ActiveGroupNotificationProfile()
        {
            CreateMap<ActiveGroupNotificationReadModel, ActiveGroupNotificationDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.GroupName));
        }
    }
}
