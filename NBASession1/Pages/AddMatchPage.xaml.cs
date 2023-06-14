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
    /// Логика взаимодействия для AddMatchPage.xaml
    /// </summary>
    public partial class AddMatchPage : Page
    {
        public AddMatchPage()
        {
            InitializeComponent();

            var season = AppData.GetContext().Season.ToList().LastOrDefault();
            TextSeason.Text = "Season: " + season.Name + "\t Mathcup Type: Resular Season";
            ComboTeam.ItemsSource = ComboTeam1.ItemsSource = AppData.GetContext().Team.ToList();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var team = ComboTeam.SelectedItem as Team;
            var team2 = ComboTeam1.SelectedItem as Team;

            if (team.TeamId == team2.TeamId)
            {
                MessageBox.Show("Teams must be different");
                return;
            }

            var season = AppData.GetContext().Season.ToList().LastOrDefault();
            Matchup matchup = new Matchup()
            {
                SeasonId = season.SeasonId,
                MatchupTypeId = 1,
                Team_Away = (ComboTeam.SelectedItem as Team).TeamId,
                Team_Home = (ComboTeam1.SelectedItem as Team).TeamId,
                Team_Away_Score = 0,
                Team_Home_Score = 0,
                Starttime = Convert.ToDateTime(DateDate.SelectedDate),
                Location = TextLocation.Text,
                Status = 1
            };

            try
            {
                AppData.GetContext().Matchup.Add(matchup);
                AppData.GetContext().SaveChanges();

                MessageBox.Show("Success!");
                Navigation.MainFrame.Navigate(new ManageMatchupsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
