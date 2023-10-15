using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class RemovedChatMessageNotificationProfile : Profile
    {
        public RemovedChatMessageNotificationProfile()
        {
            CreateMap<RemovedChatMessageNotificationReadModel, RemovedChatMessageNotificationDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
