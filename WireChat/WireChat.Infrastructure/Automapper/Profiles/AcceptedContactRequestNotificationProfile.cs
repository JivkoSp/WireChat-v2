using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class AcceptedContactRequestNotificationProfile : Profile
    {
        public AcceptedContactRequestNotificationProfile()
        {
            CreateMap<AcceptedContactRequestNotificationReadModel, AcceptedContactRequestNotificationDto>()
                .ForMember(dest => dest.SenderUserName, src => src.MapFrom(dest => dest.Sender.UserName))
                .ForMember(dest => dest.ReceiverUserName, src => src.MapFrom(dest => dest.Receiver.UserName));
        }
    }
}