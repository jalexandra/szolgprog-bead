using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using client.Core;
using client.Models;

namespace client.Responses
{
    public static class BookService
    {
        public static async Task<List<Book>> Browse()
        {
            var res = await Rest.Get<List<BookBrowsePartialResponse>>("books");
            return res.Data.Select(bookResponse => bookResponse.Model).ToList();
        }

        public static Task<RestResponse<EmptyResponse>> Delete(string selectedBookId)
        {
            return Rest.Delete<EmptyResponse>($"books/{selectedBookId}");
        }
    }
}