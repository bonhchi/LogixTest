using System.ComponentModel.DataAnnotations;

namespace LogixTest.Domain.Domain
{
    public class Movie
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image{ get; set; } = string.Empty;
        public int NumberLikes { get; set; }
    }
}
