using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class BlockedChatUserProfile : Profile
    {
        public BlockedChatUserProfile()
        {
            CreateMap<BlockedChatUserReadModel, BlockedChatUserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
