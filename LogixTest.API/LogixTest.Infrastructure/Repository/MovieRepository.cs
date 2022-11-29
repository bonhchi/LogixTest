using LogixTest.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogixTest.Infrastructure.Repository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> Get(string userName);
        Task<MovieTransaction> GetById(Guid id);
        Task UpdateStatus(MovieTransaction transaction);
    }
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> Get(string userName)
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

        public Task<MovieTransaction> GetById(Guid id)
        {
            var query = _context.MovieTransactions.FirstOrDefaultAsync(x => x.Id == id);
            return query ?? null;
        }

    }
}
