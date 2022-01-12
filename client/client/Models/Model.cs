using client.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace client.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class Model
    {
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; set; }

        public abstract string InternalName { get; }

        public Task<RestResponse<string>> Save()
        {
            return Id is null
                ? Rest.Post<string>(InternalName, this)
                : Rest.Patch<string>($"{InternalName}/${Id}", this);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}