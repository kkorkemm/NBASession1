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

namespace NBASession1
{
    using Base;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int year = DateTime.Now.Year - 1946;
            string season = AppData.GetContext().Season.ToList().LastOrDefault().Name;
            TextBottom.Text = $"The current season is {season} and the NBA already has a history of {year} years";

            MainFrame.Navigate(new Pages.MainPage());
            Navigation.MainFrame = MainFrame;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Navigation.MainFrame.CanGoBack)
            {
                Block.Visibility = Visibility.Visible;
            }
            else
            {
                Block.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.GoBack();
        }
    }
}
