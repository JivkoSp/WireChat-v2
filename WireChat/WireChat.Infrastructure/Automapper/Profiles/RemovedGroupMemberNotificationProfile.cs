using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class RemovedGroupMemberNotificationProfile : Profile
    {
        public RemovedGroupMemberNotificationProfile()
        {
            CreateMap<RemovedGroupMemberNotificationReadModel, RemovedGroupMemberNotificationDto>()
                .ForMember(dest => dest.GroupName, src => src.MapFrom(src => src.Group.GroupName))
                .ForMember(dest => dest.GroupAdminUserName, src => src.MapFrom(src => src.GroupAdmin.UserName))
                .ForMember(dest => dest.GroupMemberUserName, src => src.MapFrom(src => src.GroupMember.UserName));
        }
    }
}
