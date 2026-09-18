using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts.Avalonia;

/// <summary>
/// Логика для App.axaml
/// </summary>
public partial class App : Application
{
  public static IServiceProvider ServiceProvider { get; private set; } = null!;

  /// <summary>
  /// Конфигурация и инъекция сервисов сервисов
  /// </summary>
  /// <param name="services">Объект `IServiceCollection`</param>
  private void _configureServices(IServiceCollection services)
  {
    services.AddTransient<MainWindow>();
  }

  public override void Initialize()
  {
    var services = new ServiceCollection();

    _configureServices(services);

    ServiceProvider = services.BuildServiceProvider();

    AvaloniaXamlLoader.Load(this);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
      desktop.MainWindow = mainWindow;
    }

    base.OnFrameworkInitializationCompleted();
  }
}
