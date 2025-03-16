using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Resources;

namespace WpfApp1.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial ObservableCollection<NavigationItem> Items { get; set; } 
        public HomePageViewModel()
        {
            var items = new List<NavigationItem>
            {
                new NavigationItem("Home", FAIcons.ChevronUp),
                new NavigationItem("Page 1", FAIcons.ChevronDown),
                new NavigationItem("Page 2", FAIcons.ChevronLeft),
                new NavigationItem("Page 2", FAIcons.ChevronRight),
            };
            Items = new ObservableCollection<NavigationItem>(items);

        }
    }
}
