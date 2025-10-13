using System.Windows;
using Microsoft.Extensions.DependencyInjection;
namespace WpfApp1.ViewModels;

public class TabContentFactory
{
    private readonly IServiceProvider _serviceProvider;

    public TabContentFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public FrameworkElement CreateTab<T>(params object[] args)
        where T : FrameworkElement
    {
        var view = ActivatorUtilities.CreateInstance<T>(_serviceProvider, args);
        return view;
    }
}