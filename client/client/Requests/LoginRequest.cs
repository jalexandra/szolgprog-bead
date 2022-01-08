using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Requests
{
    class LoginRequest
    {
        public string email { get; }
        public string password { get; }

        public LoginRequest(string email, string password)
        {
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
        }
    }
}
