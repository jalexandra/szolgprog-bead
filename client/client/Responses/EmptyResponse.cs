using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace client.Responses
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class EmptyResponse
    { }
}