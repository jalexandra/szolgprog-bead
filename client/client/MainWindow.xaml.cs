using System.Windows;
using System.Windows.Input;
using client.Core;
using client.Windows;

namespace client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void BooksButton_Clicked(object sender, RoutedEventArgs e)
        {
            Navigator.To("Books");
        }

        private void AuthorsButton_Clicked(object sender, RoutedEventArgs e)
        {
            Navigator.To("Authors");
        }

        internal void RefreshUser()
        {
            Dispatcher.Invoke(() =>
            {
                if(Config.CurrentUser is not null)
                    lbl_userName.Text = $"Logged in: {Config.CurrentUser.Name}";
                Navigator.To("Books");
            });
        }

        private void UsersButton_Clicked(object sender, RoutedEventArgs e)
        {
            Navigator.To("Users");
        }

        private void UserNameLabel_Clicked(object sender, MouseButtonEventArgs e)
        {
            var child = new LoginWindow(this);
            child.Show();
            child.Focus();
            IsEnabled = false;
            child.Closing += (_, _) => IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config.Load();
            Navigator.To("Books");
        }
    }
}
