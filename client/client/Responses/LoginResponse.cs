using client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace client.Responses
{
    public class LoginResponse : EmptyResponse
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
