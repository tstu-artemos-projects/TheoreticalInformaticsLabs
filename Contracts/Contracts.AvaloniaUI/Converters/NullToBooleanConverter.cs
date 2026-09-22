using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Contracts.AvaloniaUI.Converters;

/// <summary>
/// Определяет булево значение в зависимости от
/// того, содержит ли значение нулевой указатель
/// </summary>
public class NullToBooleanConverter : IValueConverter
{
  public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    => value != null;

  public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    => throw new NotImplementedException();
}
