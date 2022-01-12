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

        private void DoCreate()
        {
            BookService.Add(txt_bookTitle.Text, txt_bookReleaseYear.Text, txt_bookAuthors.Text);
        }

        private async Task DoPatch()
        {
            if(await BookService.Edit(currentBook.Id, txt_bookTitle.Text, txt_bookReleaseYear.Text, txt_bookAuthors.Text))
                currentBook = null;
        }

        public static void Add()
        {
            Navigator.To("EditBooks");
            currentBook = null;
        }
    }
}
