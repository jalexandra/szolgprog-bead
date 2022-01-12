using System;
using System.Collections.Generic;

namespace client.Models
{
    public class Book : Model
    {
        public override string InternalName => "books";
        
        public string Title { get; set; }
        public ushort ReleaseYear { get; set; }
        public User RentedBy { get; set; }
        public List<Author> Authors { get; set; }

        public Book(string id, string title, ushort releaseYear, User rentedBy, List<Author> authors, DateTime? created_at)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            ReleaseYear = releaseYear;
            RentedBy = rentedBy;
            Authors = authors ?? new();
            CreatedAt = created_at ?? DateTime.Now;
        }

        public static Book FromJson(string json) => Newtonsoft.Json.JsonConvert.DeserializeObject<Book>(json);

        public override string ToString() => $"{Title} by {string.Join(", ", Authors)} ({ReleaseYear})";
    }
}