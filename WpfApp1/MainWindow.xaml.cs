using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModels;
using WpfApp1.Views;
using System.Globalization;
using System.Reflection;
using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
namespace WpfApp1;
    
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool _isMenuOpen = false;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<MainWindow> _logger;
    private readonly ObservableCollection<FrameworkElement> _openViews = new ObservableCollection<FrameworkElement>();
    public MainWindow(IServiceProvider serviceProvider, ILogger<MainWindow> logger)
    {
        InitializeComponent();
        DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
        _serviceProvider = serviceProvider;
        _logger = logger;

        var homePage = serviceProvider.GetRequiredService<HomePage>();
        ContentFrame.Navigate(homePage);
        NavigationMenu.SelectedIndex = 0;

        _openViews.Add(homePage);

        _logger.LogInformation("MainWindow initialized.");
    }

    // メニューの開閉を切り替える
    private void ToggleMenu()
    {
        if (_isMenuOpen)
        {
            // メニューを閉じるアニメーション
            Storyboard slideOut = (Storyboard)Resources["SlideOut"];
            slideOut.Begin();
        }
        else
        {
            // メニューを開くアニメーション
            Storyboard slideIn = (Storyboard)Resources["SlideIn"];
            slideIn.Begin();
        }

        _isMenuOpen = !_isMenuOpen;
        _logger.LogInformation("Menu toggled. IsMenuOpen: {IsMenuOpen}", _isMenuOpen);
    }

    private void MenuButton_Click(object sender, RoutedEventArgs e)
    {
        ToggleMenu();
    }

    private void NavigationMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _logger.LogInformation("NavigationMenu selection changed.");
        if (NavigationMenu.SelectedItem is NavigationItem selectedItem)
        {
            if(_openViews.Any(v => v.GetType() == selectedItem.View))
            {
                var existingView = _openViews.First(v => v.GetType() == selectedItem.View) as FrameworkElement;
                ContentFrame.Navigate(existingView);
                _logger.LogInformation("Navigated to existing {View}.", selectedItem.View.Name);
                return;
            }
            var view = _serviceProvider.GetService(selectedItem.View) as FrameworkElement;
            if (view != null)
            {
                ContentFrame.Navigate(view);
                _openViews.Add(view);
                _logger.LogInformation("Navigated to {View}.", selectedItem.View.Name);
                return;
            }

        }
    }
}
public class WidthToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double width)
        {
            return width > 100 ? Visibility.Visible : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}