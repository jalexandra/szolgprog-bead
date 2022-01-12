using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using client.Responses;

namespace client.Core
{
    public class RestResponse<T>
    {
        public HttpStatusCode Status { get; }
        public string Raw { get; }
        public T Data { get; }
        public ErrorResponse ErrorResponse { get; }
        public bool IsSuccess => ErrorResponse is null;

        protected RestResponse(HttpStatusCode status, string raw, T data = default, ErrorResponse errorResponse = null)
        {
            Status = status;
            Raw = raw ?? throw new ArgumentNullException(nameof(raw));
            Data = data;
            ErrorResponse = errorResponse;
        }
        
        public static async Task<RestResponse<T>> Create(Task<HttpResponseMessage> responseTask)
        {
            var response = await responseTask;
            var status = response.StatusCode;
            var raw = await response.Content.ReadAsStringAsync() ?? "";
            var data = response.IsSuccessStatusCode ? Newtonsoft.Json.JsonConvert.DeserializeObject<T>(raw) : default;
            try
            {
                var errorResponse = response.IsSuccessStatusCode
                    ? null
                    : Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(raw);
                return new(status, raw, data, errorResponse);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                return new(status, raw, data, new(status.ToString()));
            }
        }
    }
}