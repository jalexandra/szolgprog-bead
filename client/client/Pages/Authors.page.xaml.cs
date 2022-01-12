using client.Models;
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

namespace client.Pages
{
    /// <summary>
    /// Interaction logic for Authors.xaml
    /// </summary>
    public partial class Authors : Page
    {
        private readonly List<Author> _authors = new();
        public Authors()
        {
            InitializeComponent();
        }

        private void Authors_Loaded(object sender, RoutedEventArgs e)
        {
            InitAuthors();
        }

        private async Task InitAuthors()
        {
            _authors.Clear();
            //_authors.AddRange();
        }
    }
}
