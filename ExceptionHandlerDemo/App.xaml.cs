using ExceptionHandler.Common;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Windows;
using System.Windows.Threading;

namespace ExceptionHandlerDemo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        Services = ConfigureServices();

        // 注册全局异常处理器
        DispatcherUnhandledException += OnDispatcherUnhandledException;
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        //APP 中没有处理的异常会在这里被捕获
        //这里用了！。因为我们在 ConfigureServices() 方法中已经注册了 IExceptionDispatcher 服务，所以肯定不为 null
        var isHandled = Services.GetService<IExceptionDispatcher>()!.Dispatch(e.Exception);
        e.Handled = isHandled;
        // 如果异常被处理了，则设置 e.Handled 为 true，否则为 false
        // 如果没有处理，则会导致应用程序崩溃
        // e.Handled 为 true 的话说明被处理了，应用程序不会崩溃！！！
    }

    public IServiceProvider Services { get; }

    public new static App Current => (App)Application.Current;

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();


        // 这里IExceptionDispatcher 会被注册为单例，因为它需要在整个应用程序生命周期内使用同一个实例
        // 其他的异常处理器会被注册为瞬态（Transient），因为它们不需要在整个应用程序生命周期内保持状态
        // 全部都会在这里方法里面被注册。
        // 这是一个扩展方法!!!!
        services.RegisterHandlers();


        //// 1. 配置 Serilog
        //Log.Logger = new LoggerConfiguration()
        //    .MinimumLevel.Debug()
        //    .WriteTo.Console()
        //    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
        //    .CreateLogger();

        services.AddLogging(builder =>
        {
            builder.AddSerilog(dispose: true); // 注入 Serilog 到 Microsoft.Extensions.Logging
        });

        return services.BuildServiceProvider();
    }
}