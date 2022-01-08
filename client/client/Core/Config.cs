using client.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace client.Core
{
    [JsonObject]
    class Config
    {
        private static readonly string configFile = "config.json";

        [JsonConstructor]
        public Config(string apiUrl, uint port)
        {
            _ApiUrl = apiUrl ?? throw new ArgumentNullException(nameof(apiUrl));
            _Port = port;
        }

        public static Config Current { get; private set; }
        public string _ApiUrl { get; private set; }
        public static string ApiUrl => Current._ApiUrl;
        public uint _Port { get; private set; }
        public static uint Port => Current._Port;

        public string _Token { get; set; }
        public static string Token => Current._Token;

        public User _CurrentUser { get; set; }
        public static User CurrentUser => Current._CurrentUser;

        public static Config Load()
        {
            var conf = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configFile));
            Current = conf;
            return Current;
        }

        public static void Save()
        {
            File.WriteAllText(configFile, JsonConvert.SerializeObject(Current));
        }
    }
}
