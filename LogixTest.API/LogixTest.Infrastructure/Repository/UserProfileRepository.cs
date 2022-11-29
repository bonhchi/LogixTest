using LogixTest.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogixTest.Infrastructure.Repository
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> Get(string userName, string email);
        Task Register(UserProfile user);
    }
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly DataContext _context;

        public UserProfileRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Register(UserProfile user)
        {
            _context.UserProfiles.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserProfile> Get(string userName, string email)
        {
            var query = await _context.UserProfiles.
                FirstOrDefaultAsync(p => 
                p.UserName == userName || p.Email == email);

            return query;
        }
    }
}
