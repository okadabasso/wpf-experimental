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
using WpfApp1.Views;
using WpfApp1.ViewModels;
using System.Globalization;
namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool _isMenuOpen = false;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();

        ContentFrame.Navigate(new HomePage());
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
    }

    private void MenuButton_Click(object sender, RoutedEventArgs e)
    {
        ToggleMenu();
    }

    private void NavigationMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (NavigationMenu.SelectedItem is NavigationItem selectedItem)
        {
            switch (selectedItem.Text.ToString())
            {
                case "Home":
                    ContentFrame.Navigate(new HomePage());
                    break;
                case "Page 1":
                    ContentFrame.Navigate(new Page1());
                    break;
                case "Page 2":
                    ContentFrame.Navigate(new Page2());
                    break;
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