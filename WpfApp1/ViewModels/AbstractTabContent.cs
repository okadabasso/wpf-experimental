using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace WpfApp1.ViewModels;


public partial class AbstractTabContent : ObservableObject
{
    [RelayCommand]
    public virtual void CloseTab()
    {
        TabClosed?.Invoke(this, this);
    }
    public event EventHandler<object>? TabClosed;

}
 