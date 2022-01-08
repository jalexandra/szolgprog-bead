using client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace client.Responses
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    class LoginResponse
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
