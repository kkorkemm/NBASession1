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
    /// Логика взаимодействия для TeamDetailPage.xaml
    /// </summary>
    public partial class TeamDetailPage : Page
    {
        private Team CurrentTeam;

        public TeamDetailPage(Team team, int i)
        {
            InitializeComponent();
            CurrentTeam = team;
            DataContext = CurrentTeam;

            ComboSeasons.ItemsSource = AppData.GetContext().Season.ToList();
            GridRoster.ItemsSource = AppData.GetContext().PlayerInTeam.ToList().Where(p => p.TeamId == CurrentTeam.TeamId).ToList();
            GridMatch.ItemsSource = AppData.GetContext().Matchup.ToList().Where(p => p.Team_Home == CurrentTeam.TeamId).ToList();

            var users = AppData.GetContext().PlayerInTeam.ToList().Where(p => p.TeamId == CurrentTeam.TeamId).ToList();

            foreach (var user in users)
            {
                if (user.Player.PositionId == 1)
                    TextSF.Text += user.Player.Name + "\n";
                else if (user.Player.PositionId == 2)
                    TextPF.Text += user.Player.Name + "\n";
                else if (user.Player.PositionId == 3)
                    TextC.Text += user.Player.Name + "\n";
                else if (user.Player.PositionId == 4)
                    TextSG.Text += user.Player.Name + "\n";
                else
                    TextPG.Text += user.Player.Name + "\n";
            }

            if (i == 1)
            {
                GridRoster.Visibility = Visibility.Visible;
                GridMatch.Visibility = Visibility.Collapsed;
                Can.Visibility = Visibility.Collapsed;
            }
            else if (i == 2)
            {
                GridRoster.Visibility = Visibility.Collapsed;
                GridMatch.Visibility = Visibility.Visible;
                Can.Visibility = Visibility.Collapsed;
            }
            else
            {
                GridRoster.Visibility = Visibility.Collapsed;
                GridMatch.Visibility = Visibility.Collapsed;
                Can.Visibility = Visibility.Visible;
            }
        }

        private void BtnRoster_Click(object sender, RoutedEventArgs e)
        {
            GridRoster.Visibility = Visibility.Visible;
            GridMatch.Visibility = Visibility.Collapsed;
            Can.Visibility = Visibility.Collapsed;
        }

        private void BtnMatch_Click(object sender, RoutedEventArgs e)
        {
            GridRoster.Visibility = Visibility.Collapsed;
            GridMatch.Visibility = Visibility.Visible;
            Can.Visibility = Visibility.Collapsed;
        }

        private void BtnLine_Click(object sender, RoutedEventArgs e)
        {
            GridRoster.Visibility = Visibility.Collapsed;
            GridMatch.Visibility = Visibility.Collapsed;
            Can.Visibility = Visibility.Visible;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var season = ComboSeasons.SelectedItem as Season;

            if (season == null)
                return;

            GridRoster.ItemsSource = AppData.GetContext().PlayerInTeam.ToList().Where(p => p.TeamId == CurrentTeam.TeamId && p.SeasonId == season.SeasonId).ToList();
            GridMatch.ItemsSource = AppData.GetContext().Matchup.ToList().Where(p => p.Team_Home == CurrentTeam.TeamId && p.SeasonId == season.SeasonId).ToList();

            var users = AppData.GetContext().PlayerInTeam.ToList().Where(p => p.TeamId == CurrentTeam.TeamId && p.SeasonId == season.SeasonId).ToList();

            TextPG.Text = TextPF.Text = TextC.Text = TextSG.Text = TextSF.Text = "";

            foreach (var user in users)
            {
                if (user.Player.PositionId == 1)
                    TextSF.Text += user.Player.Name + "\n";
                else if (user.Player.PositionId == 2)
                    TextPF.Text += user.Player.Name + "\n";
                else if (user.Player.PositionId == 3)
                    TextC.Text += user.Player.Name + "\n";
                else if (user.Player.PositionId == 4)
                    TextSG.Text += user.Player.Name + "\n";
                else
                    TextPG.Text += user.Player.Name + "\n";
            }
        }
    }
}
