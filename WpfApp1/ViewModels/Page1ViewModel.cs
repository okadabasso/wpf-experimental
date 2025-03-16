using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.ViewModels
{
    public partial class Page1ViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial ObservableCollection<EditItem> Items { get; set; }

        public Page1ViewModel()
        {
            Items = new ObservableCollection<EditItem>() { 
                new EditItem(){ Name = "item 1", Value = "1001" },
                new EditItem(){ Name = "item 2", Value = "1002" },
                new EditItem(){ Name = "item 3", Value = "1003" },
                new EditItem(){ Name = "item 4", Value = "1004" },
                new EditItem(){ Name = "item 5", Value = "1005" },
            };
        }
    }
    public partial class EditItem : ObservableObject
    {
        [ObservableProperty]
        public partial string Name { get; set; } = String.Empty;
        [ObservableProperty]
        public partial string Value { get; set; } = String.Empty;

    }
}
