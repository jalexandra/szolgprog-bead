using client.Core;
using client.Responses;
using System.Windows;
using client.Services;

namespace client.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly MainWindow _mainWindow;

        public LoginWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private async void LoginButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (!await AuthService.Login(txt_email.Text, txt_password.Password))
            {
                MessageBox.Show("Login failed", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Login successful", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
            _mainWindow.RefreshUser();
            Close();
        }

        private async void RegisterButton_Clicked(object sender, RoutedEventArgs e)
        {
            if(txt_regPassword.Password != txt_regPasswordConfirm.Password)
            {
                MessageBox.Show("Passwords do not match", "Register", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            var res = await AuthService.Register(txt_regName.Text, txt_regEmail.Text, txt_regPassword.Password);
            if(res is not null)
            {
                MessageBox.Show($"Registration failed: {res}", "Registration", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            MessageBox.Show("Registration successful", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
            txt_email.Text = txt_regEmail.Text;
            txt_password.Password = txt_regPassword.Password;
            LoginButton_Clicked(sender, e);
        }
    }
}
