using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class CreatedGroupNotificationProfile : Profile
    {
        public CreatedGroupNotificationProfile()
        {
            CreateMap<CreatedGroupNotificationReadModel, CreatedGroupNotificationDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.GroupName));
        }
    }
}
