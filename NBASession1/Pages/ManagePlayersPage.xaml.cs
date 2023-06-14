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
    /// Логика взаимодействия для ManagePlayersPage.xaml
    /// </summary>
    public partial class ManagePlayersPage : Page
    {
        public ManagePlayersPage()
        {
            InitializeComponent();

            var positions = AppData.GetContext().Position.ToList();
            positions.Insert(0, new Position { Name = "All" });
            ComboPositions.ItemsSource = positions;
            ComboPositions.SelectedIndex = 0;

            var countries = AppData.GetContext().Country.ToList();
            countries.Insert(0, new Country { CountryName = "All" });
            ComboCountry.ItemsSource = countries;
            ComboCountry.SelectedIndex = 0;

            var list = AppData.GetContext().Player.ToList();
            GridPlayers.ItemsSource = list;
            TextTotal.Text = "Total players: "+ list.Count;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var list = AppData.GetContext().Player.ToList();

            if (!string.IsNullOrEmpty(TextName.Text))
                list = list.Where(p => p.Name.ToLower().Contains(TextName.Text.ToLower())).ToList();
            if (ComboCountry.SelectedIndex != 0)
                list = list.Where(p => p.CountryCode == (ComboCountry.SelectedItem as Country).CountryCode).ToList();
            if (ComboPositions.SelectedIndex != 0)
                list = list.Where(p => p.PositionId == (ComboPositions.SelectedItem as Position).PositionId).ToList();

            GridPlayers.ItemsSource = list;
            TextTotal.Text = "Total players: " + list.Count;
        }
    }
}
