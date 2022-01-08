using client.Core;
using client.Windows;
using System;
using System.Collections.Generic;
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

namespace client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow instance;

        public MainWindow()
        {
            InitializeComponent();
            instance = this;
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
            this.Dispatcher.Invoke(() => this.lbl_userName.Text = $"Logged in: {Config.CurrentUser.Name}");
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
            this.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config.Load();
            Navigator.To("Books");
        }
    }
}
