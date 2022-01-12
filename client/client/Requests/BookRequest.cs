using System.Collections.Generic;
using System.Linq;
using client.Models;

namespace client.Requests
{
    public class BookRequest : EmptyRequest
    {
        public string Title { get; set; }
        public ushort ReleaseYear { get; set; }
        public List<uint> Authors { get; set; }
        
        public BookRequest(string title, string releaseYear, string authors)
        {
            Title = title;
            ReleaseYear = ushort.Parse(releaseYear);
            Authors = authors.Split(',').Select(uint.Parse).ToList();
        }
    }
}