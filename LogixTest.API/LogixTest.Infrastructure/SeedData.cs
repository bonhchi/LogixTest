using LogixTest.Domain.Domain;

namespace LogixTest.Infrastructure
{
    public class SeedData
    {
        public static async Task InitSeedData(DataContext context)
        {
            if(!context.Movies.Any())
            {
                var movies = new List<Movie>
                {
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Image = "test",
                        NumberLikes = 0,
                    }
                };
            }
        }
    }
}
