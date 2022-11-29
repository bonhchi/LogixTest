using System.ComponentModel.DataAnnotations;

namespace LogixTest.Domain.Domain
{
    public class MovieTransaction
    {
        [Required]
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool Status { get; set; }
        public Movie Movie { get; set; }
    }
}
