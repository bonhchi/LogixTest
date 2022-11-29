using LogixTest.Domain.Dto.Movie;

namespace LogixTest.Domain.Dto.MovieTransaction.Request
{
    public class AddMovieTransactionDto
    {
        public string UserName { get; set; } = string.Empty;
        public bool Status { get; set; }
        public MovieDto Movie { get; set; } = new MovieDto();
    }
}
