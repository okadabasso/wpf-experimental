using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new NavigationItem("Home", "\uf105"),
                new NavigationItem("Page 1", "\uf106"),
                new NavigationItem("Page 2", "\uf107"),
            };
            Items = new ObservableCollection<NavigationItem>(items);

        }
    }
}
