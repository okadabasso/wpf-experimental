using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; } = "WPF Sample";

        [ObservableProperty]
        public partial ObservableCollection<NavigationItem> NavigationItems { get; set; }
        public MainWindowViewModel()
        {
            NavigationItems = new ObservableCollection<NavigationItem>
            {
                new NavigationItem("Home", "\ue3af"),
                new NavigationItem("Page 1", "\uf15b"),
                new NavigationItem("Page 2", "\uf03a"),
            };
        }
    }
    
}
