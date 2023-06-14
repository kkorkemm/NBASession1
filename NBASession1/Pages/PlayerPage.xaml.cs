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
    /// Логика взаимодействия для PlayerPage.xaml
    /// </summary>
    public partial class PlayerPage : Page
    {
        int pageIndex = 1;
        private int numberOfRecPerPage = 10;
        private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4 };
        List<Player> list;

        public PlayerPage()
        {
            InitializeComponent();

            var seasons = AppData.GetContext().Season.ToList();
            seasons.Insert(0, new Season { Name = "All" });
            ComboSeasons.ItemsSource = seasons;
            ComboSeasons.SelectedIndex = 0;

            var teams = AppData.GetContext().Team.ToList();
            teams.Insert(0, new Team { TeamName = "All" });
            ComboTeams.ItemsSource = teams;
            ComboTeams.SelectedIndex = 0;

            list = AppData.GetContext().Player.ToList();
            GridPlayers.ItemsSource = list.Take(numberOfRecPerPage);
            int count = list.Take(numberOfRecPerPage).Count();
            TextNumberAll.Text = " of " + list.Count / 10;
            TextNumber.Text = (count / 10).ToString();

            TextTotal.Text = "Total " + list.Count + " records, 10 records in one page";


            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < alphabet.Length; i++)
            {
                Button button = new Button();
                button.Content = alphabet[i];
                button.Foreground = Brushes.White;
                button.Background = Brushes.Transparent;
                button.FontWeight = FontWeights.Bold;
                button.Width = 30;
                button.Height = 30;
                button.Click += Button_Click;

                StackAlphButtons.Children.Add(button);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = (sender as Button).Content.ToString();
            list = AppData.GetContext().Player.ToList().Where(p => p.Name.StartsWith(s)).ToList();
            GridPlayers.ItemsSource = list;
            Navigate((int)PagingMode.First);
        }

        private void BtnAll_Click(object sender, RoutedEventArgs e)
        {
            list = AppData.GetContext().Player.ToList();
            GridPlayers.ItemsSource = list;
            Navigate((int)PagingMode.First);
        }

        private void BtnFirst_Click(object sender, RoutedEventArgs e)
        {
            Navigate((int)PagingMode.First);
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            Navigate((int)PagingMode.Previous);
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Navigate((int)PagingMode.Next);
        }

        private void BtnLast_Click(object sender, RoutedEventArgs e)
        {
            Navigate((int)PagingMode.Last);
        }

        /// <summary>
        /// Пагинация страниц
        /// </summary>
        private void Navigate(int mode)
        {
            int count;
            switch (mode)
            {
                case (int)PagingMode.Next:
                    BtnPrev.IsEnabled = true;
                    BtnFirst.IsEnabled = true;
                    if (list.Count >= (pageIndex * numberOfRecPerPage))
                    {
                        if (list.Skip(pageIndex *
                        numberOfRecPerPage).Take(numberOfRecPerPage).Count() == 0)
                        {
                            GridPlayers.ItemsSource = null;
                            GridPlayers.ItemsSource = list.Skip((pageIndex *
                            numberOfRecPerPage) - numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = (pageIndex * numberOfRecPerPage) +
                            (list.Skip(pageIndex *
                            numberOfRecPerPage).Take(numberOfRecPerPage)).Count();
                        }
                        else
                        {
                            GridPlayers.ItemsSource = null;
                            GridPlayers.ItemsSource = list.Skip(pageIndex *
                            numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = (pageIndex * numberOfRecPerPage) +
                            (list.Skip(pageIndex *
                            numberOfRecPerPage).Take(numberOfRecPerPage)).Count();
                            pageIndex++;
                        }

                        TextNumberAll.Text = " of " + (list.Count / 10 + 1);
                        TextNumber.Text = pageIndex.ToString();
                    }

                    else
                    {
                        BtnNext.IsEnabled = false;
                        BtnLast.IsEnabled = false;
                    }

                    break;
                case (int)PagingMode.Previous:
                    BtnNext.IsEnabled = true;
                    BtnLast.IsEnabled = true;
                    if (pageIndex > 1)
                    {
                        pageIndex -= 1;
                        GridPlayers.ItemsSource = null;
                        if (pageIndex == 1)
                        {
                            GridPlayers.ItemsSource = list.Take(numberOfRecPerPage);
                            count = list.Take(numberOfRecPerPage).Count();
                            TextNumberAll.Text = " of " + (list.Count / 10 + 1);
                            TextNumber.Text = pageIndex.ToString();
                        }
                        else
                        {
                            GridPlayers.ItemsSource = list.Skip
                            (pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = Math.Min(pageIndex * numberOfRecPerPage, list.Count);
                            TextNumberAll.Text = " of " + (list.Count / 10 + 1);
                            TextNumber.Text = pageIndex.ToString();
                        }
                    }
                    else
                    {
                        BtnPrev.IsEnabled = false;
                        BtnFirst.IsEnabled = false;
                    }
                    break;

                case (int)PagingMode.First:
                    pageIndex = 2;
                    Navigate((int)PagingMode.Previous);
                    break;
                case (int)PagingMode.Last:
                    pageIndex = (list.Count / numberOfRecPerPage);
                    Navigate((int)PagingMode.Next);
                    break;
            }
        }

        private void ComboSeasons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboSeasons.SelectedIndex != 0)
            {
                list = AppData.GetContext().Player.ToList().Where(p => p.Season == (ComboSeasons.SelectedItem as Season).SeasonId).ToList();
                GridPlayers.ItemsSource = list;
                Navigate((int)PagingMode.First);
            }
        }

        private void ComboTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboTeams.SelectedIndex != 0)
            {
                list = AppData.GetContext().Player.ToList().Where(p => p.TeamID == (ComboTeams.SelectedItem as Team).TeamId).ToList();
                GridPlayers.ItemsSource = list;
                Navigate((int)PagingMode.First);
            }
        }

        private void TextName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextName.Text))
            {
                list = AppData.GetContext().Player.ToList().Where(p => p.Name.Contains(TextName.Text)).ToList();
                GridPlayers.ItemsSource = list;
                Navigate((int)PagingMode.First);
            }
        }

        private void GridPlayers_Selected(object sender, RoutedEventArgs e)
        {
            var item = GridPlayers.SelectedItem as Player;
            Navigation.MainFrame.Navigate(new PlayerDetailPage(item));
        }
    }
}
