using System;
using System.Collections.Generic;
using System.Linq;
using client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace client.Responses
{
    public class AuthorInBookBrowseResponse : EmptyResponse
    {
        [JsonConstructor]
        public AuthorInBookBrowseResponse(
            int id,
            string name,
            DateTime createdAt,
            int authorId,
            int bookId
        )
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            AuthorId = authorId;
            BookId = bookId;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime CreatedAt { get; }
        public int AuthorId { get; }
        public int BookId { get; }

        public AuthorBrowsePartialResponse Model => new(Id.ToString(), Name, CreatedAt);
    }

    public class BookBrowsePartialResponse : EmptyResponse
    {
        [JsonConstructor]
        public BookBrowsePartialResponse(
            int id,
            string title,
            int releaseYear,
            int? rentedBy,
            DateTime createdAt,
            List<AuthorInBookBrowseResponse> authors
        )
        {
            Id = id;
            Title = title;
            ReleaseYear = releaseYear;
            RentedBy = rentedBy;
            CreatedAt = createdAt;
            Authors = authors;
        }

        public int Id { get; }
        public string Title { get; }
        public int ReleaseYear { get; }
        public int? RentedBy { get; }
        public DateTime CreatedAt { get; }
        public List<AuthorInBookBrowseResponse> Authors { get; }

        public BookInAuthorBrowseResponse Model => new(
                Id.ToString(),
                Title,
                (ushort) ReleaseYear,
                RentedBy is null ? null : new(string.Empty, string.Empty, string.Empty), // Don't need this for now 
                Authors.Select(authorResponse => authorResponse.Model).ToList(),
                CreatedAt
            );
    }
}