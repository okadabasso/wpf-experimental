using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using WpfApp1.ViewModels;
using WpfApp1.Views;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;

namespace WpfApp1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider _serviceProvider = null!;
    private IConfiguration _configuration = null!;

    public App()
    {
        // グローバル例外ハンドラーを設定
        this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
    }

    private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        var logger = _serviceProvider?.GetService<ILogger<App>>();
        logger?.LogError(e.Exception, "Unhandled exception occurred");
        string errorMessage = $"予期しないエラーが発生しました:\n{e.Exception.Message}\n\nアプリケーションを続行しますか？";

        var result = MessageBox.Show(errorMessage,
                                   "エラー",
                                   MessageBoxButton.YesNo,
                                   MessageBoxImage.Error);

        if (result == MessageBoxResult.Yes)
        {
            e.Handled = true; // 例外を処理済みとしてアプリケーションを続行
        }
        else
        {
            Current?.Shutdown(); // アプリケーションを終了
        }
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
           var logger = _serviceProvider?.GetService<ILogger<App>>();
        logger?.LogError($"Unhandled exception occurred\n{e.ExceptionObject}");
     string errorMessage = $"致命的なエラーが発生しました:\n{e.ExceptionObject}";

        MessageBox.Show(errorMessage,
                       "致命的エラー",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error);  
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        try
        {
            base.OnStartup(e);

            // 1. Configuration の構築
            _configuration = BuildConfiguration();

            // 2. DI Container の構築
            _serviceProvider = BuildServiceProvider();

            // 3. MainWindow の表示
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            if (mainWindow == null)
            {
                throw new InvalidOperationException("MainWindow の取得に失敗しました。");
            }
            mainWindow.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"アプリケーションの起動中にエラーが発生しました: {ex.Message}",
                          "エラー",
                          MessageBoxButton.OK,
                          MessageBoxImage.Error);

            // アプリケーションを終了
            Current?.Shutdown();
        }
    }

    private IConfiguration BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        // 環境変数があれば環境固有の設定ファイルも読み込み
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";
        builder.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

        return builder.Build();
    }

    private IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();

        // Configuration をサービスに登録
        services.AddSingleton<IConfiguration>(_configuration);

        // Logging の設定
        ConfigureLogging(services);

        // Settings の設定
        ConfigureSettings(services);

        // DryIocコンテナの設定
        var container = BuildContainer(services);

        return container.BuildServiceProvider();
    }
    private IContainer BuildContainer(IServiceCollection services)
    {
        // DryIocコンテナの設定
        var container = new Container(rules => rules.With(propertiesAndFields: PropertiesAndFields.Auto))
            .WithDependencyInjectionAdapter(services);

        // ViewModelsとViewsの登録
        container.Register<MainWindowViewModel>(Reuse.Singleton);
        container.Register<MainWindow>(Reuse.Transient);

        // View を登録する
        container.Register<ButtonSamplePage>(Reuse.Transient);
        container.Register<DataGridSample>(Reuse.Transient);
        container.Register<FormElementSample>(Reuse.Transient);
        container.Register<HomePage>(Reuse.Transient);
        container.Register<TabView1>(Reuse.Transient);
        container.Register<MenuView>(Reuse.Transient);
        // ViewModel を登録する
        container.Register<DataGridSampeViewModel>(Reuse.Transient);
        container.Register<HomePageViewModel>(Reuse.Transient);
        container.Register<TabContent>(Reuse.Transient);

        // tab factory
        container.Register<TabContentFactory>(Reuse.Singleton);
        return container;
    }

    private void ConfigureLogging(IServiceCollection services)
    {
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.SetMinimumLevel(LogLevel.Trace);
            builder.AddNLog();
        });
    }

    private void ConfigureSettings(IServiceCollection services)
    {
        // 設定クラスがある場合はここで登録
        // var sampleSettings = new SampleSettings();
        // _configuration.GetSection("SampleSettings").Bind(sampleSettings);
        // services.AddSingleton(sampleSettings);
    }

}

