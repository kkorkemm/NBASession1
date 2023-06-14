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
    /// Логика взаимодействия для VisitorPage.xaml
    /// </summary>
    public partial class VisitorPage : Page
    {
        public VisitorPage()
        {
            InitializeComponent();
        }

        private void BtnPlayers_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new PlayerPage());
        }

        private void BtnTeams_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new TeamPage());
        }

        private void BtnPhotos_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new PhotoPage());
        }

        private void BtnMatch_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new MatchPage());
        }
    }
}
