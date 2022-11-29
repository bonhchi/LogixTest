using AutoMapper;
using LogixTest.Domain.Domain;
using LogixTest.Domain.Dto.User;

namespace LogixTest.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserProfileDto, UserProfile>().ReverseMap();
        }
    }
}
