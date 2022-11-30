using Newtonsoft.Json;

namespace LogixTest.Domain.Dto.Movie.Request
{
    public class AddMovieInputDto
    {
        [JsonProperty("movie_id")]
        public Guid MovieId { get; set; }
    }
}
