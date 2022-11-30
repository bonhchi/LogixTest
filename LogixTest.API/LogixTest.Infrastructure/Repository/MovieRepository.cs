using LogixTest.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogixTest.Infrastructure.Repository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> Get();
        Task<Movie> GetMovieById(Guid id);
        Task<MovieTransaction> GetTransactionById(Guid id);
        Task UpdateStatus(MovieTransaction transaction);
        Task AddStatus(MovieTransaction transaction);
    }
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> Get()
        {
            var query = await _context.Movies
                .OrderByDescending(x => x.Title).ToListAsync();
            return query;
        }

        public async Task UpdateStatus(MovieTransaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task<MovieTransaction> GetTransactionById(Guid id)
        {
            var query = _context.MovieTransactions.FirstOrDefaultAsync(x => x.Id == id);
            return query;
        }

        public async Task AddStatus(MovieTransaction transaction)
        {
            _context.MovieTransactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public Task<Movie> GetMovieById(Guid id)
        {
            var query = _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return query;
        }
    }
}
