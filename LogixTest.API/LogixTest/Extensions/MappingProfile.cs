using AutoMapper;
using LogixTest.Domain.Domain;
using LogixTest.Domain.Dto.Movie;
using LogixTest.Domain.Dto.MovieTransaction;
using LogixTest.Domain.Dto.MovieTransaction.Request;
using LogixTest.Domain.Dto.User;

namespace LogixTest.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserProfileDto, UserProfile>().ReverseMap();

            CreateMap<Movie, MovieDto>().ReverseMap();

            CreateMap<MovieTransaction, MovieTransactionDto>();

            CreateMap<AddMovieTransactionDto, MovieTransaction>()
                .ForMember(x => x.Id, opt => opt.Ignore());

        }
    }
}
