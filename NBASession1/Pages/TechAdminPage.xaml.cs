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
    /// <summary>
    /// Логика взаимодействия для TechAdminPage.xaml
    /// </summary>
    public partial class TechAdminPage : Page
    {
        public TechAdminPage()
        {
            InitializeComponent();
        }

        private void BtnExec_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The feature would be a future add-on to the current system.", "Manage Exections - Future Add-on");
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new TeamReportPage());
        }
    }
}
