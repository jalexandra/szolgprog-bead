using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace client.Models
{
    public class User : Model
    {
        public override string InternalName => "users";
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }

        public User(string id, string name, string email, string phone = null, DateTime? created_at = null, bool is_admin = false)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? "";
            CreatedAt = created_at ?? DateTime.Now;
            IsAdmin = is_admin;
        }

        public static User FromJson(string json) => JsonConvert.DeserializeObject<User>(json);

        public static User Find(int? rentedBy)
        {
            if (rentedBy is null)
                return null;

            return null; // TODO: Implement
        }
    }
}
