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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            ListImages.ItemsSource = AppData.GetContext().Pictures.ToList();
        }

        private void BtnVisitor_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new VisitorPage());
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new AdminPage());
        }
    }
}
