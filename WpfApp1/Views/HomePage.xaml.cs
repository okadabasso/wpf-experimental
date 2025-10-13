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
using WpfApp1.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace WpfApp1.Views
{
    /// <summary>
    /// HomePage.xaml の相互作用ロジック
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage(HomePageViewModel viewModel)
        
        {
            InitializeComponent();
            DataContext = viewModel;
        }


        private void tabScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            var tabScroll = GetScrollViewer(tab);
            if (tabScroll != null)
            {
                double newOffset = Math.Max(tabScroll.HorizontalOffset - 50, 0);
                tabScroll.ScrollToHorizontalOffset(newOffset);
            }

        }

        private void tabScrollRight_Click(object sender, RoutedEventArgs e)
        {

            var tabScroll = GetScrollViewer(tab);
            if (tabScroll != null)
            {
                double newOffset = Math.Min(tabScroll.HorizontalOffset + 50, tabScroll.ExtentWidth - tabScroll.ViewportWidth);
                tabScroll.ScrollToHorizontalOffset(newOffset);
            }

        }
        private ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer) return (ScrollViewer)depObj;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                ScrollViewer result = GetScrollViewer(child);
                if (result != null) return result;
            }
            return null!;
        }

    }
}
