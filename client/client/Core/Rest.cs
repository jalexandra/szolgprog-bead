using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace client.Core
{
    internal static class Rest
    {
        private static readonly HttpClient client;
        static Rest()
        {
            client = new()
            {
                BaseAddress = new($"{Config.ApiUrl}:{Config.Port}")
            };
            client.DefaultRequestHeaders.Accept.Add(new("application/json"));
        }

        public static Task<RestResponse<T>> Get<T>(string uri)
        {
            return RestResponse<T>.Create(Send(uri, HttpMethod.Get));
        }


        public static Task<RestResponse<T>> Post<T>(string uri, object body)
        {
            return RestResponse<T>.Create(Send(uri, HttpMethod.Post, body));
        }

        public static Task<RestResponse<T>> Patch<T>(string uri, object body)
        {
            return RestResponse<T>.Create(Send(uri, HttpMethod.Patch, body));
        }

        public static Task<RestResponse<T>> Delete<T>(string uri)
        {
            return RestResponse<T>.Create(Send(uri, HttpMethod.Delete));
        }

        public static Task<HttpResponseMessage> Send(string uri, HttpMethod requestMethod, object body = null, bool tryAuth = true)
        {
            var requestMessage = new HttpRequestMessage(requestMethod, uri);
            
            if (tryAuth && !string.IsNullOrWhiteSpace(Config.Token))
                requestMessage.Headers.Add("X-API-KEY", Config.Token);

            if(body is not null)
                requestMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");

            return client.SendAsync(requestMessage);
        }
    }
}
