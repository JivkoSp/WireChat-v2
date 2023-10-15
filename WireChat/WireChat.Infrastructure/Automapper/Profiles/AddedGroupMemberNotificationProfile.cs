using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class AddedGroupMemberNotificationProfile : Profile
    {
        public AddedGroupMemberNotificationProfile()
        {
            CreateMap<AddedGroupMemberNotificationReadModel, AddedGroupMemberNotificationDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.GroupName))
                .ForMember(dest => dest.GroupAdminUserName, opt => opt.MapFrom(src => src.GroupAdmin.UserName))
                .ForMember(dest => dest.GroupMemberUserName, opt => opt.MapFrom(src => src.GroupMember.UserName));
        }
    }
}
