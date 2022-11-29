using Newtonsoft.Json;

namespace LogixTest.Domain.Dto.Error
{
    public class ErrorDto
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; } = new List<object>();
        [JsonProperty("massage")]
        public string Message { get; set; }
    }
}
