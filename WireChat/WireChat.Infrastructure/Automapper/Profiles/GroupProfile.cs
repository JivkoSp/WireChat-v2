using AutoMapper;
using WireChat.Application.Dtos;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.Automapper.Profiles
{
    internal sealed class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupReadModel, GroupDto>()
                .ForMember(dest => dest.ChatDto, opt => opt.MapFrom(src => src.Chat));   
        }
    }
}
