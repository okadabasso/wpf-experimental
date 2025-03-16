using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    
    public partial class NavigationItem : ObservableObject
    {
        [ObservableProperty]
        public partial string Text { get; set; } = "Name";
        [ObservableProperty]
        public partial string Icon { get; set; } = "Icon";

        public NavigationItem()
        {
         
        }
        public NavigationItem(string text, string icon)
        {
            Text = text;
            Icon = icon;
        }

    }
}
