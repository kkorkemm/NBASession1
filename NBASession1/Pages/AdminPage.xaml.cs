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

namespace NBASession1.Pages
{
    using Base;

    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(TextNumber.Text))
                errors.AppendLine("Entry a number");
            if (string.IsNullOrEmpty(TextPass.Password))
                errors.AppendLine("Entry a password");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            var admin = AppData.GetContext().Admin.ToList().Where(p => p.Jobnumber == TextNumber.Text && p.Passwords == TextPass.Password).FirstOrDefault();

            if (admin == null)
            {
                MessageBox.Show("No such admin in database");
                return;
            }

            // REMEMBER ME

            if (admin.RoleId == "1")
            {
                Navigation.MainFrame.Navigate(new EventAdminPage());
            }
            else
            {
                Navigation.MainFrame.Navigate(new TechAdminPage());
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TextNumber.Text = "";
            TextPass.Password = "";
        }
    }
}
