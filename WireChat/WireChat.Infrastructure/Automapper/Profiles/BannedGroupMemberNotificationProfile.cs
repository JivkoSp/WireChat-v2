using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class BannedGroupMemberNotificationProfile : Profile
    {
        public BannedGroupMemberNotificationProfile()
        {
            CreateMap<BannedGroupMemberNotificationReadModel, BannedGroupMemberNotificationDto>()
                .ForMember(dest => dest.GroupAdminUserName, opt => opt.MapFrom(src => src.GroupAdmin.UserName))
                .ForMember(dest => dest.GroupMemberUserName, opt => opt.MapFrom(src => src.GroupMember.UserName))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Group.GroupName));
        }
    }
}
