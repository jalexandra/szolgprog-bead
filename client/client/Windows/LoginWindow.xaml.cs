using client.Core;
using client.Responses;
using System.Windows;

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
            this._mainWindow = mainWindow;
        }

        private async void LoginButton_Clicked(object sender, RoutedEventArgs e)
        {
            var res = await Rest.Post("auth/login", new { email = txt_email.Text, password = txt_password.Password });

            if(res.IsSuccessStatusCode)
            {
                var resObj = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(await res.Content.ReadAsStringAsync());
                Rest.token = resObj.Token;
                Config.Current._CurrentUser = resObj.User;
                _mainWindow.RefreshUser();
                MessageBox.Show("Successfully logged in");
                this.Close();
            }
            else
            {
                MessageBox.Show($"Log in was unsuccesfull: {res.Content}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
