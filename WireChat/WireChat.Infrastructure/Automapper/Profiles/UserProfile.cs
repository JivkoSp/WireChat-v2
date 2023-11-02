using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserReadModel, UserInfoDto>()
              .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserReadModel, UserDto>()
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.BlockedChatUserDtos, opt => opt.MapFrom(src => src.BlockedChatUsers));
        }
    }
}
