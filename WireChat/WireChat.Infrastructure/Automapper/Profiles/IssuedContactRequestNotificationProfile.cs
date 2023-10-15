﻿using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class IssuedContactRequestNotificationProfile : Profile
    {
        public IssuedContactRequestNotificationProfile()
        {
            CreateMap<IssuedContactRequestNotificationReadModel, IssuedContactRequestNotificationDto>()
                .ForMember(dest => dest.SenderUserName, opt => opt.MapFrom(src => src.Sender.UserName))
                .ForMember(dest => dest.ReceiverUserName, opt => opt.MapFrom(src => src.Receiver.UserName));
        }
    }
}
