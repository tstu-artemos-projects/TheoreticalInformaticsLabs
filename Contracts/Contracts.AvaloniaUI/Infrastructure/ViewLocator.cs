using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Contracts.AvaloniaUI.Infrastructure;

/// <summary>
/// Сопоставление View и ViewModel внутри приложения
/// </summary>
public class ViewLocator : IDataTemplate
{
  public Control? Build(object? data)
  {
    if (data is null)
      return null;

    var name = data.GetType().FullName!
        .Replace("ViewModels", "Views")
        .Replace("ViewModel", "View");

    var type = Type.GetType(name);

    if (type != null)
    {
      return (Control)Activator.CreateInstance(type)!;
    }

    return new TextBlock
    {
      Text = $"[ViewLocator] Не найдено представление:\n{name}",
      Foreground = Avalonia.Media.Brushes.Red,
      Margin = new Avalonia.Thickness(10)
    };
  }

  public bool Match(object? data)
  {
    return data is ObservableObject;
  }
}
