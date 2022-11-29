using LogixTest.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace LogixTest.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTransaction> MovieTransactions { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

        }
    }
}
