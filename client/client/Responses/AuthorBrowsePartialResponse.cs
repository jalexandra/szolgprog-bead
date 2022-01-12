using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Responses
{
    public class BookInAuthorBrowseResponse
    {
        [JsonConstructor]
        public BookInAuthorBrowseResponse(
            int id,
            string title,
            int releaseYear,
            int? rentedBy,
            DateTime createdAt,
            int authorId,
            int bookId
        )
        {
            this.Id = id;
            this.Title = title;
            this.ReleaseYear = releaseYear;
            this.RentedBy = rentedBy;
            this.CreatedAt = createdAt;
            this.AuthorId = authorId;
            this.BookId = bookId;
        }

        public int Id { get; }
        public string Title { get; }
        public int ReleaseYear { get; }
        public int? RentedBy { get; }
        public DateTime CreatedAt { get; }
        public int AuthorId { get; }
        public int BookId { get; }
    }

    public class AuthorBrowsePartialResponse
    {
        [JsonConstructor]
        public AuthorBrowsePartialResponse(
            int id,
            string name,
            DateTime createdAt,
            List<BookInAuthorBrowseResponse> books
        )
        {
            this.Id = id;
            this.Name = name;
            this.CreatedAt = createdAt;
            this.Books = books;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime CreatedAt { get; }
        public IReadOnlyList<BookInAuthorBrowseResponse> Books { get; }
    }
}
