using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Core
{
    class Navigator
    {
        public static void To(string target)
        {
            var w = MainWindow.instance;
            w.frm_content.Source = new Uri($"Pages/{target}.page.xaml", UriKind.Relative);
            w.btn_authors.IsEnabled = true;
            w.btn_books.IsEnabled = true;
            w.btn_users.IsEnabled = true;
            switch (target)
            {
                case "Books":
                    w.btn_books.IsEnabled = false;
                    break;
                case "users":
                    w.btn_users.IsEnabled = false;
                    break;
                case "authors":
                    w.btn_authors.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }
    }
}
