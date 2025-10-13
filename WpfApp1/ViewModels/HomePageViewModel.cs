using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Resources;
using WpfApp1.Views;
using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        IServiceProvider _serviceProvider;
        TabContentFactory _tabContentFactory;
        [ObservableProperty]
        public partial ObservableCollection<TabItem> TabItems { get; set; } = new ObservableCollection<TabItem>();
        [ObservableProperty]
        public partial TabItem? SelectedTab { get; set; } = null!;
        public HomePageViewModel(IServiceProvider serviceProvider, TabContentFactory tabContentFactory)
        {
            _serviceProvider = serviceProvider;
            _tabContentFactory = tabContentFactory;
            TabItems.Add(new TabItem() { Header = "Home", Content = _serviceProvider.GetRequiredService<MenuView>() });
            TabItems.Add(new TabItem() { Header = "About", Content = _serviceProvider.GetRequiredService<TabView1>() });


        }


        [RelayCommand]
        public void AddTab()
        {
        }
        [RelayCommand]
        public void MenuItem1()
        {

            OpenNewTab("MenuItem1");

        }
        public void CloseTab(object view)
        {
            var tabItem = TabItems.FirstOrDefault(t => t.Content == view);
            if (tabItem is TabItem item && TabItems.Contains(item))
            {
                TabItems.Remove(item);
                if (SelectedTab == item)
                {
                    SelectedTab = TabItems.FirstOrDefault();
                }
                if(view is IDisposable disposable)
                {
                    disposable.Dispose();
                }
                view = null!;
            }
        }

        public void OpenNewTab(string title)
        {
            // Check if a tab with the same title already exists
            if (TabItems.OfType<TabItem>().Any(ti => ti.Header.ToString() == title))
            {
                // Optionally, focus the existing tab
                var existingTab = TabItems.FirstOrDefault(ti => ti.Header.ToString() == title);
                if(existingTab != null)
                {
                    SelectedTab = existingTab;
                }
               return;
            }

            // Create a new tab with a unique title
            var view = _tabContentFactory.CreateTab<TabView1>("MenuItem1", "This is MenuItem1", new Action<object>(CloseTab));
            var tabItem = new TabItem()
            {
                Header = title,
                Content = view
            };
            TabItems.Add(tabItem);
            SelectedTab = tabItem;
        }
    }
}
