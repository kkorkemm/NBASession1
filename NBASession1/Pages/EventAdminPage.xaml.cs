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
    /// Логика взаимодействия для EventAdminPage.xaml
    /// </summary>
    public partial class EventAdminPage : Page
    {
        public EventAdminPage()
        {
            InitializeComponent();
        }

        private void BtnMatch_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new ManageMatchupsPage());
        }

        private void BtnSeasons_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new ManageSeasonsPage());
        }

        private void BtnTeams_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new ManageTeamsPage());
        }

        private void BtnPlayers_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new ManagePlayersPage());
        }
    }
}
