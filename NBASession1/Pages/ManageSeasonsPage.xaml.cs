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
    /// Логика взаимодействия для ManageSeasonsPage.xaml
    /// </summary>
    public partial class ManageSeasonsPage : Page
    {
        public ManageSeasonsPage()
        {
            InitializeComponent();

            ComboSeasons.ItemsSource = AppData.GetContext().Season.ToList();
            ComboSeasons.SelectedIndex = 0;

            var types = AppData.GetContext().MatchupType.ToList();
            types.Insert(0, new MatchupType { Name = "All" });
            ComboTypes.SelectedIndex = 0;
            ComboTypes.ItemsSource = types;

            GripMatch.ItemsSource = AppData.GetContext().Matchup.ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
