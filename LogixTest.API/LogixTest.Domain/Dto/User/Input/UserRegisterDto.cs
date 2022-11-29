using Newtonsoft.Json;

namespace LogixTest.Domain.Dto.User.Input
{
    public class UserRegisterDto
    {
        [JsonProperty("user_name")]
        public string UserName { get; set; } = string.Empty;
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;
    }
}
