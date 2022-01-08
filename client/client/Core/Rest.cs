using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace client.Core
{
    static class Rest
    {
        private static readonly HttpClient client;
        public static string token = null;

        static Rest()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{Config.ApiUrl}:{Config.Port}")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static Task<HttpResponseMessage> Get(string uri)
        {
            return Send(uri, HttpMethod.Get);
        }


        public static Task<HttpResponseMessage> Post(string uri, object body)
        {
            return Send(uri, HttpMethod.Post, body);
        }

        public static Task<HttpResponseMessage> Patch(string uri, object body)
        {
            return Send(uri, HttpMethod.Patch, body);
        }

        public static Task<HttpResponseMessage> Delete(string uri)
        {
            return Send(uri, HttpMethod.Delete);
        }

        public static Task<HttpResponseMessage> Send(string uri, HttpMethod requestMethod, object body = null, bool tryAuth = true)
        {
            var requestMessage = new HttpRequestMessage(requestMethod, uri);
            
            if (tryAuth && !string.IsNullOrWhiteSpace(token))
                requestMessage.Headers.Add("X-API-KEY", token);

            if(body is not null)
                requestMessage.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");

            return client.SendAsync(requestMessage);
        }
    }
}
