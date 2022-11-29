using AutoMapper;
using LogixTest.Domain.Domain;
using LogixTest.Domain.Dto.Movie;
using LogixTest.Domain.Dto.MovieTransaction;
using LogixTest.Domain.Dto.MovieTransaction.Request;
using LogixTest.Infrastructure.Repository;

namespace LogixTest.Services
{
    public interface IMovieService
    {
        Task<List<MovieDto>> Get();
        Task<MovieTransactionDto> GetById(Guid id);
        Task UpdateStatus(UpdateMovieTransactionDto transaction);
        Task AddStatus(AddMovieTransactionDto transaction);
    }
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task AddStatus(AddMovieTransactionDto transaction)
        {
            var mapping = _mapper.Map<AddMovieTransactionDto, MovieTransaction>(transaction);
            await _movieRepository.AddStatus(mapping);
        }

        public async Task<List<MovieDto>> Get()
        {
            var query = await _movieRepository.Get();

            var data = query.Select(s => _mapper.Map<Movie, MovieDto>(s)).ToList();

            return data;
        }

        public async Task<MovieTransactionDto> GetById(Guid id)
        {
            var query = await _movieRepository.GetById(id);

            var data = _mapper.Map<MovieTransaction, MovieTransactionDto>(query);

            return data;
        }

        public async Task UpdateStatus(UpdateMovieTransactionDto transaction)
        {
            var query = await _movieRepository.GetById(transaction.Id);

            var data = new MovieTransaction
            {
                Id = transaction.Id,
                Status = transaction.Status,
                UserName = query.UserName,
                Movie = query.Movie,
            };

            await _movieRepository.UpdateStatus(data);
        }
    }
}
