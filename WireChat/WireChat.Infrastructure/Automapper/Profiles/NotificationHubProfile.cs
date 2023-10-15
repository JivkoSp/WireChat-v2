using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class NotificationHubProfile : Profile
    {
        public NotificationHubProfile()
        {
            CreateMap<NotificationHubReadModel, NotificationHubDto>()
                .ForMember(dest => dest.IssuedContactRequestNotificationDtos, opt => 
                    opt.MapFrom(src => src.IssuedContactRequestNotifications))
                .ForMember(dest => dest.ReceivedContactRequestNotificationDtos, opt => 
                    opt.MapFrom(src => src.ReceivedContactRequestNotifications))
                .ForMember(dest => dest.AcceptedContactRequestNotificationDtos, opt => 
                    opt.MapFrom(src => src.AcceptedContactRequestNotifications))
                .ForMember(dest => dest.DeclinedContactRequestNotificationDtos, opt => 
                    opt.MapFrom(src => src.DeclinedContactRequestNotifications))
                .ForMember(dest => dest.ActiveGroupNotificationDtos, opt => 
                    opt.MapFrom(src => src.ActiveGroupNotifications))
                .ForMember(dest => dest.AddedGroupMemberNotificationDtos, opt => 
                    opt.MapFrom(src => src.AddedGroupMemberNotifications))
                .ForMember(dest => dest.RemovedGroupMemberNotificationDtos, opt => 
                    opt.MapFrom(src => src.RemovedGroupMemberNotifications))
                .ForMember(dest => dest.BannedContactNotificationDtos, opt =>
                    opt.MapFrom(src => src.BannedContactNotifications))
                .ForMember(dest => dest.BannedGroupMemberNotificationDtos, opt => 
                    opt.MapFrom(src => src.BannedGroupMemberNotifications))
                .ForMember(dest => dest.CreatedGroupNotificationDtos, opt => 
                    opt.MapFrom(src => src.CreatedGroupNotifications))
                .ForMember(dest => dest.RemovedChatMessageNotificationDtos, opt => 
                    opt.MapFrom(src => src.RemovedChatMessageNotifications));
        }
    }
}
