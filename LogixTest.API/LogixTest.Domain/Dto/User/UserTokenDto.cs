using Newtonsoft.Json;

namespace LogixTest.Domain.Dto.User
{
    public class UserTokenDto
    {
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
        [JsonProperty("user_name")]
        public string UserName { get; set; } = string.Empty;
        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;
    }
}
