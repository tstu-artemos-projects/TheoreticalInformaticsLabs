using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Contracts.AvaloniaUI.Infrastructure;

namespace Contracts.AvaloniaUI.Controls;

public partial class HeaderControl : UserControl
{
  public static readonly StyledProperty<IOperation?> OperationProperty =
    AvaloniaProperty.Register<HeaderControl, IOperation?>(nameof(Operation));

  public static readonly StyledProperty<ICommand?> ContractCommandProperty =
    AvaloniaProperty.Register<HeaderControl, ICommand?>(nameof(ContractCommand));

  public static readonly StyledProperty<object?> ContractCommandParameterProperty =
    AvaloniaProperty.Register<HeaderControl, object?>(nameof(ContractCommandParameter));

  public IOperation? Operation
  {
    get => GetValue(OperationProperty);
    set => SetValue(OperationProperty, value);
  }

  public ICommand? ContractCommand
  {
    get => GetValue(ContractCommandProperty);
    set => SetValue(ContractCommandProperty, value);
  }

  public object? ContractCommandParameter
  {
    get => GetValue(ContractCommandParameterProperty);
    set => SetValue(ContractCommandParameterProperty, value);
  }

  public HeaderControl()
  {
    InitializeComponent();
  }
}

