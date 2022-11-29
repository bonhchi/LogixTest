using LogixTest.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogixTest.Infrastructure.Repository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> Get(string userName);
        Task CreateTransaction(MovieTransaction transaction);
        Task<MovieTransaction> GetById(Guid id);
        void UpdateStatus(MovieTransaction transaction);
        Task Save();
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

        public void UpdateStatus(MovieTransaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task<MovieTransaction> GetById(Guid id)
        {
            var query = _context.MovieTransactions.FirstOrDefaultAsync(x => x.Id == id);
            return query ?? null;
        }

        public Task CreateTransaction(MovieTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
