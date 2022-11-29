using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LogixTest.Domain.Dto.Movie
{
    public class MovieDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;
        [JsonProperty("image")]
        public string Image { get; set; } = string.Empty;
        [JsonProperty("number_likes")]
        public int NumberLikes { get; set; }
    }
}
