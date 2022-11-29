using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace LogixTest.Domain.Domain
{
    public class UserProfile
    {
        [Required]
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
    }
}
