using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using client.Core;
using client.Models;
using client.Requests;

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

        public static async Task Add(string title, string releaseYear, string authors)
        {
            var res = await Rest.Post<EmptyResponse>(
                "books",
                new BookRequest(title, releaseYear, authors)
            );
            if (res.IsSuccess)
            {
                MessageBox.Show("Book created", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigator.To("Books");
                return;
            }
            
            MessageBox.Show($"Book creation failed \n {res.ErrorResponse.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static async Task<bool> Edit(string id, string title, string releaseYear, string authors)
        {
            var res = await Rest.Patch<EmptyResponse>(
                $"books/{id}",
                new BookRequest(title, releaseYear, authors)
            );
            if (res.IsSuccess)
            {
                MessageBox.Show("Book edited successfully",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                Navigator.To("Books");
                return true;
            }

            MessageBox.Show($"Something went wrong \n {res.ErrorResponse.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return false;
        }
    }
}