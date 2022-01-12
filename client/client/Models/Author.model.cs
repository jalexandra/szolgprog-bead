using System;

namespace client.Models
{
    public class Author : Model
    {
        public override string InternalName => "authors";

        public string Name { get; set; }

        public Author(string id, string name, DateTime? created_at = null)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CreatedAt = created_at ?? DateTime.Now;
        }
        public static Author FromJson(string json) => Newtonsoft.Json.JsonConvert.DeserializeObject<Author>(json);

        public override string ToString() => Name;
    }
    
}