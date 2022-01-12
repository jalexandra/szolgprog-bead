using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace client.Responses
{
    public class ErrorResponse : EmptyResponse
    {
        public ErrorResponse(string message) => Message = message;

        public string Message { get; set; }
    }
}
