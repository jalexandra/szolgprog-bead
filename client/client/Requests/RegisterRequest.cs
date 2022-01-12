using System;

namespace client.Requests
{
    public class RegisterRequest : EmptyRequest
    {
        public string Email { get; }
        public string Password { get; }
        public string Name { get; }

        public RegisterRequest(string email, string password, string name)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}