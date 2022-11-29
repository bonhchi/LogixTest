using LogixTest.Domain.Dto.Movie;

namespace LogixTest.Domain.Dto.MovieTransaction
{
    public class MovieTransactionDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool Status { get; set; }
        public MovieDto Movie { get; set; } = new MovieDto();
    }
}
