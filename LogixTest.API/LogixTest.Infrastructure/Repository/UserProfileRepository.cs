using LogixTest.Domain.Domain;

namespace LogixTest.Infrastructure.Repository
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> Get(string userName, string email, string passwordHash);
        Task Add(UserProfile user);
    }
    public class UserProfileRepository : IUserProfileRepository
    {
        public Task Add(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfile> Get(string userName, string email, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}
