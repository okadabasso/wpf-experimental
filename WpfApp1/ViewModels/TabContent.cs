using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp1.ViewModels
{
    public partial class TabContent : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; }
        [ObservableProperty]
        public partial string Message { get; set; }
        public TabContent()
        {
            Title = "";
            Message = "";
        }
    }
}
