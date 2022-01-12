using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace client.Requests
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class LoginRequest
    {
        public string Email { get; }
        public string Password { get; }

        public LoginRequest(string email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
    }
}
