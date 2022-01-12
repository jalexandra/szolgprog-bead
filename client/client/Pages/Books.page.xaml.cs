using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using client.Core;
using client.Models;
using client.Responses;

namespace client.Pages
{
    /// <summary>
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : Page
    {
        private readonly List<Book> _books = new();
        public Books()
        {
            InitializeComponent();
        }

        private void Books_OnLoaded(object sender, RoutedEventArgs e)
        {
            InitBooks();
        }

        private async Task InitBooks()
        {
            _books.Clear();
            _books.AddRange(await BookService.Browse());
            Dispatcher.Invoke(() => lst_books.Items.Clear());
            foreach (var book in _books) 
                Dispatcher.Invoke(() => lst_books.Items.Add(book.ToString()));
        }

        private void Lst_books_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lst_books.SelectedIndex < 0 || lst_books.SelectedIndex >= _books.Count) return;
            
            var selectedBook = _books[lst_books.SelectedIndex];
            Inspect(selectedBook ?? new(string.Empty, string.Empty, 0, null, new(), null));
        }

        private void Inspect(Book book)
        {
            lbl_bookTitle.Text = book.Title;
            lbl_bookAuthors.Text = string.Join(", ", book.Authors);
            lbl_releaseYear.Text = book.ReleaseYear.ToString();
            lbl_isRented.Text = book.RentedBy is null ? "Available" : "Rented";
            lbl_createdAt.Text = book.CreatedAt.ToString(CultureInfo.CurrentCulture);
        }

        private void Btn_DeleteBookButton(object sender, RoutedEventArgs e)
        {
            if (lst_books.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a book to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if(Config.CurrentUser is null || !Config.CurrentUser.IsAdmin)
            {
                MessageBox.Show("You are not authorized to delete books", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            var selectedBook = _books[lst_books.SelectedIndex];
            if (MessageBox.Show($"Are you sure you want to delete {selectedBook.Title}?", "Delete Book", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                BookService.Delete(selectedBook.Id).ContinueWith(res =>
                {
                    if (res.Result.IsSuccess)
                    {
                        MessageBox.Show("Book deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        InitBooks();
                        return;
                    }

                    MessageBox.Show(res.Result.ErrorResponse.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
        }

        private void btn_EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (lst_books.SelectedIndex == -1 || lst_books.SelectedIndex >= _books.Count)
            {
                MessageBox.Show("Please select a book to edit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Config.CurrentUser is null || !Config.CurrentUser.IsAdmin)
            {
                MessageBox.Show("You are not authorized to edit books", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedBook = _books[lst_books.SelectedIndex];
            EditBooks.Edit(selectedBook);
            InitBooks();
        }

        private void Btn_NewBook_Click(object sender, RoutedEventArgs e)
        {
            if (Config.CurrentUser is null || !Config.CurrentUser.IsAdmin)
            {
                MessageBox.Show("You are not authorized to add books", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            EditBooks.Add();
            InitBooks();
        }
    }
}
