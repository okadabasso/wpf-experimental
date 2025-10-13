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
        public partial string Header { get; set; }
        [ObservableProperty]
        public partial string Message { get; set; }

        [ObservableProperty]
        public partial bool IsSelected { get; set; }


        [ObservableProperty]
        public partial Type ContentType { get; set; }
        public TabContent()
        {
            Header = "";
            Message = "";
            IsSelected = false;
            ContentType = typeof(object);
        }
        public TabContent(string header, string message)
        {
            Header = header;
            Message = message;
            IsSelected = false;
            ContentType = typeof(object);
        }
        [RelayCommand]
        public void CloseTab()
        {
            TabClosed?.Invoke(this, this);
        }
        public event EventHandler<object>? TabClosed;
    }

    
}
