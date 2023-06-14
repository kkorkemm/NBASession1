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
    /// Логика взаимодействия для TeamPage.xaml
    /// </summary>
    public partial class TeamPage : Page
    {
        public TeamPage()
        {
            InitializeComponent();

            Text1.Text = "Atlantic";
            Text2.Text = "Central";
            Text3.Text = "Southeast Divisions";

            List1.ItemsSource = AppData.GetContext().Team.ToList().Where(p => p.DivisionId == 3).ToList();
            List2.ItemsSource = AppData.GetContext().Team.ToList().Where(p => p.DivisionId == 2).ToList();
            List3.ItemsSource = AppData.GetContext().Team.ToList().Where(p => p.DivisionId == 1).ToList();
        }

        private void BtnRoster_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new TeamDetailPage((sender as Button).DataContext as Team, 1));
        }

        private void List1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = List1.SelectedItem as Team;
            Navigation.MainFrame.Navigate(new TeamDetailPage(item, 1));
        }

        private void BtnMatch_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new TeamDetailPage((sender as Button).DataContext as Team, 2));
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new TeamDetailPage((sender as Button).DataContext as Team, 3));
        }

        private void List2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = List2.SelectedItem as Team;
            Navigation.MainFrame.Navigate(new TeamDetailPage(item, 1));
        }

        private void List3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = List3.SelectedItem as Team;
            Navigation.MainFrame.Navigate(new TeamDetailPage(item, 1));
        }

        private void BtnEast_Click(object sender, RoutedEventArgs e)
        {
            Text1.Text = "Atlantic";
            Text2.Text = "Central";
            Text3.Text = "Southeast Divisions";

            List1.ItemsSource = AppData.GetContext().Team.ToList().Where(p => p.DivisionId == 3).ToList();
            List2.ItemsSource = AppData.GetContext().Team.ToList().Where(p => p.DivisionId == 2).ToList();
            List3.ItemsSource = AppData.GetContext().Team.ToList().Where(p => p.DivisionId == 1).ToList();
        }

        private void BtnWest_Click(object sender, RoutedEventArgs e)
        {
            Text1.Text = "Northwest";
            Text2.Text = "Pacific";
            Text3.Text = "Southwest";

            List1.ItemsSource = AppData.GetContext().Team.ToList().Where(p => p.DivisionId == 5).ToList();
            List2.ItemsSource = AppData.GetContext().Team.ToList().Where(p => p.DivisionId == 6).ToList();
            List3.ItemsSource = AppData.GetContext().Team.ToList().Where(p => p.DivisionId == 4).ToList();
        }
    }
}
