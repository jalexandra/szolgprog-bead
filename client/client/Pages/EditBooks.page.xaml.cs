using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using client.Core;
using client.Models;
using client.Requests;
using client.Responses;

namespace client.Pages
{
    /// <summary>
    /// Interaction logic for EditBooks.xaml
    /// </summary>
    public partial class EditBooks : Page
    {
        private static Book currentBook;

        public EditBooks()
        {
            InitializeComponent();
        }

        public static void Edit(Book selectedBook)
        {
            Navigator.To("EditBooks");
            currentBook = selectedBook;
        }

        private void EditBooks_OnLoaded(object sender, RoutedEventArgs e)
        {
            if(currentBook is null) return;
            
            txt_bookTitle.Text = currentBook.Title;
            txt_bookReleaseYear.Text = currentBook.ReleaseYear.ToString();
            txt_bookAuthors.Text = string.Join(", ", currentBook.Authors.Select(author => author.Id));
        }

        private void Btn_editCancel_OnClick(object sender, RoutedEventArgs e) => Navigator.To("Books");

        private void Btn_editSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_bookTitle.Text) || string.IsNullOrWhiteSpace(txt_bookReleaseYear.Text) || string.IsNullOrWhiteSpace(txt_bookAuthors.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (currentBook is null)
            {
                DoCreate();
                return;
            }
            DoPatch();
        }

        private async Task DoCreate()
        {
            var res = await Rest.Post<EmptyResponse>(
                "books",
                new BookRequest(txt_bookTitle.Text, txt_bookReleaseYear.Text, txt_bookAuthors.Text)
            );
            if (res.IsSuccess)
            {
                MessageBox.Show("Book created", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigator.To("Books");
                return;
            }
            
            MessageBox.Show($"Book creation failed \n {res.ErrorResponse.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async Task DoPatch()
        {
            var res = await Rest.Patch<EmptyResponse>(
                $"books/{currentBook.Id}",
                new BookRequest(txt_bookTitle.Text, txt_bookReleaseYear.Text, txt_bookAuthors.Text)
            );
            if (res.IsSuccess)
            {
                MessageBox.Show("Book edited successfully",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                Navigator.To("Books");
                currentBook = null;
                return;
            }

            MessageBox.Show($"Something went wrong \n {res.ErrorResponse.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void Add()
        {
            Navigator.To("EditBooks");
            currentBook = null;
        }
    }
}
