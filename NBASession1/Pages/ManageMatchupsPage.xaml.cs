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
    /// Логика взаимодействия для ManageMatchupsPage.xaml
    /// </summary>
    public partial class ManageMatchupsPage : Page
    {
        public ManageMatchupsPage()
        {
            InitializeComponent();

            ComboSeasons.ItemsSource = AppData.GetContext().Season.ToList();
            ComboSeasons.SelectedIndex = 0;

            GridMatch.ItemsSource = AppData.GetContext().Matchup.ToList().Where(p => p.MatchupTypeId == 0 && p.SeasonId == (ComboSeasons.SelectedItem as Season).SeasonId).ToList();
        }

        private void BtnPre_Click(object sender, RoutedEventArgs e)
        {
            BtnAdd.Visibility = Visibility.Collapsed;
            GridMatch.ItemsSource = AppData.GetContext().Matchup.ToList().Where(p => p.MatchupTypeId == 0 && p.SeasonId == (ComboSeasons.SelectedItem as Season).SeasonId).ToList();
        }

        private void BtnRegular_Click(object sender, RoutedEventArgs e)
        {
            BtnAdd.Visibility = Visibility.Visible;
            GridMatch.ItemsSource = AppData.GetContext().Matchup.ToList().Where(p => p.MatchupTypeId == 1 && p.SeasonId == (ComboSeasons.SelectedItem as Season).SeasonId).ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (BtnAdd.Visibility == Visibility.Visible)
            {

                var list  = AppData.GetContext().Matchup.ToList().Where(p => p.MatchupTypeId == 1 && p.SeasonId == (ComboSeasons.SelectedItem as Season).SeasonId).ToList();

                if (CheckDate.IsChecked == true)
                {
                    list = list.Where(p => p.Starttime.Date == DateDate.SelectedDate).ToList();
                }

                GridMatch.ItemsSource = list;
            }
            else
            {
                var list  = AppData.GetContext().Matchup.ToList().Where(p => p.MatchupTypeId == 0 && p.SeasonId == (ComboSeasons.SelectedItem as Season).SeasonId).ToList();

                if (CheckDate.IsChecked == true)
                {
                    list = list.Where(p => p.Starttime.Date == DateDate.SelectedDate).ToList();
                }

                GridMatch.ItemsSource = list;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new AddMatchPage());
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The  feature would be a future add-on to the current system.", "Update Matchup – Future Add-on");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Do you actually want to delete item?", "Attention!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
                return;

            var item = (sender as Button).DataContext as Matchup;

            try
            {
                AppData.GetContext().Matchup.Remove(item);
                AppData.GetContext().SaveChanges();

                if (BtnAdd.Visibility == Visibility.Visible)
                {
                    GridMatch.ItemsSource = AppData.GetContext().Matchup.ToList().Where(p => p.MatchupTypeId == 1 && p.SeasonId == (ComboSeasons.SelectedItem as Season).SeasonId).ToList();
                }
                else
                {
                    GridMatch.ItemsSource = AppData.GetContext().Matchup.ToList().Where(p => p.MatchupTypeId == 0 && p.SeasonId == (ComboSeasons.SelectedItem as Season).SeasonId).ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
