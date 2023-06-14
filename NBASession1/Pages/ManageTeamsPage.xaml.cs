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
    /// Логика взаимодействия для ManageTeamsPage.xaml
    /// </summary>
    public partial class ManageTeamsPage : Page
    {
        public ManageTeamsPage()
        {
            InitializeComponent();

            ComboConference.ItemsSource = AppData.GetContext().Conference.ToList();
            var conf = ComboConference.SelectedItem as Conference;
            var list = AppData.GetContext().Team.ToList().Where(p => p.Conference == conf.Name).ToList();
            GridPlayers.ItemsSource = list;

            TextTotal.Text = "Total Teams: " + list.Count;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var conf = ComboConference.SelectedItem as Conference;
            var list = AppData.GetContext().Team.ToList().Where(p => p.Conference == conf.Name).ToList();

            if (ComboDivision.SelectedItem != null)
            {
                var division = ComboDivision.SelectedItem as Division;
                list = list.Where(p => p.DivisionId == division.DivisionId).ToList();
            }
            if (!string.IsNullOrEmpty(TextName.Text))
                list = list.Where(p => p.TeamName.ToLower().Contains(TextName.Text.ToLower())).ToList();

            GridPlayers.ItemsSource = list;

            TextTotal.Text = "Total Teams: " + list.Count;
        }

        private void BtnAddNewTeam_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The  feature would be a future add-on to the current system.", "Add a new team – Future Add-on");
        }

        private void ComboConference_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var conf = ComboConference.SelectedItem as Conference;
            ComboDivision.ItemsSource = AppData.GetContext().Division.ToList().Where(p => p.ConferenceId == conf.ConferenceId).ToList();
        }
    }
}
