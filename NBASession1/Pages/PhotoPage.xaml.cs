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
    /// Логика взаимодействия для PhotoPage.xaml
    /// </summary>
    public partial class PhotoPage : Page
    {
        int pageIndex = 1;
        private int numberOfRecPerPage = 4;
        private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4 };
        List<Pictures> list;

        public PhotoPage()
        {
            InitializeComponent();

            list = AppData.GetContext().Pictures.ToList();
            ListPhoto.ItemsSource = list.Take(numberOfRecPerPage);
            int count = list.Take(numberOfRecPerPage).Count();
            TextNumber.Text = count.ToString();

            TextTotal.Text = "Total " + list.Count + " photos, 4 photos in one page";
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
                            ListPhoto.ItemsSource = null;
                            ListPhoto.ItemsSource = list.Skip((pageIndex *
                            numberOfRecPerPage) - numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = (pageIndex * numberOfRecPerPage) +
                            (list.Skip(pageIndex *
                            numberOfRecPerPage).Take(numberOfRecPerPage)).Count();
                        }
                        else
                        {
                            ListPhoto.ItemsSource = null;
                            ListPhoto.ItemsSource = list.Skip(pageIndex *
                            numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = (pageIndex * numberOfRecPerPage) +
                            (list.Skip(pageIndex *
                            numberOfRecPerPage).Take(numberOfRecPerPage)).Count();
                            pageIndex++;
                        }

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
                        ListPhoto.ItemsSource = null;
                        if (pageIndex == 1)
                        {
                            ListPhoto.ItemsSource = list.Take(numberOfRecPerPage);
                            count = list.Take(numberOfRecPerPage).Count();
                            TextNumber.Text = pageIndex.ToString();
                        }
                        else
                        {
                            ListPhoto.ItemsSource = list.Skip
                            (pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = Math.Min(pageIndex * numberOfRecPerPage, list.Count);
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDownload_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
