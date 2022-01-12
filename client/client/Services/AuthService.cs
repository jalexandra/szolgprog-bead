using System.Threading.Tasks;
using client.Core;
using client.Responses;

namespace client.Services
{
    public static class AuthService
    {
        public static async Task<bool> Login(string email, string password)
        {
            var res = await Rest.Post<LoginResponse>("auth/login", new {email, password });
            
            if (!res.IsSuccess) return false;
            
            Config.Current._CurrentUser = res.Data.User;
            Config.Current._Token = res.Data.Token;
            return true;

        }   

        public static async Task<string> Register(string name, string email, string password)
        {
            var res = await Rest.Post<LoginResponse>("auth/register", new {name, email, password });
            return res.IsSuccess ? null : res.ErrorResponse.Message;
        }
    }
}