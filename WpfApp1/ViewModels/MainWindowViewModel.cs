using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Resources;
using WpfApp1.Views;

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
                new NavigationItem("Home", FAIcons.Home, typeof(HomePage)),
                new NavigationItem("Page 1", FAIcons.Document, typeof(Page1)),
                new NavigationItem("Page 2", FAIcons.List, typeof(Page2)),
                new NavigationItem("Form Elements", FAIcons.List, typeof(FormElementSample)),
            };
        }
    }
    
}
