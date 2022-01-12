using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace client.Requests
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class EmptyRequest
    {
        
    }
}