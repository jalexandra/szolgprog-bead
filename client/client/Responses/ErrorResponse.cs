using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace client.Responses
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    class ErrorResponse
    {
        public string Message { get; set; }
    }
}
