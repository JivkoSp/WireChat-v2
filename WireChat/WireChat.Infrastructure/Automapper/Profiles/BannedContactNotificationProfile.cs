using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class BannedContactNotificationProfile : Profile
    {
        public BannedContactNotificationProfile()
        {
            CreateMap<BannedContactNotificationReadModel, BannedContactNotificationDto>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(opt => opt.User.UserName));
        }
    }
}
