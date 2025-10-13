using System.Windows;
using Microsoft.Extensions.DependencyInjection;
namespace WpfApp1.ViewModels;

public class ComponentFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ComponentFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T Create<T>(params object[] args)
        where T : class
    {
        var component = ActivatorUtilities.CreateInstance<T>(_serviceProvider, args);
        return component;
    }
}