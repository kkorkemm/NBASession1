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
    /// Логика взаимодействия для MatchPage.xaml
    /// </summary>
    public partial class MatchPage : Page
    {
        public MatchPage()
        {
            InitializeComponent();

            var time = AppData.GetContext().Matchup.ToList().LastOrDefault().Starttime;
            DateDate.SelectedDate = time;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            DateDate.SelectedDate = Convert.ToDateTime(DateDate.SelectedDate).AddDays(-1);
        }

        private void DateDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var matches = AppData.GetContext().Matchup.ToList().Where(p => p.Starttime.Date == DateDate.SelectedDate).ToList();
            GridMatch.ItemsSource = matches.OrderBy(p => p.Starttime).ToList();

            var match = matches.OrderBy(p => p.Starttime).ToList().Where(p => p.Status == -1).FirstOrDefault();

            StackMatch.DataContext = match;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            DateDate.SelectedDate = Convert.ToDateTime(DateDate.SelectedDate).AddDays(1);
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
