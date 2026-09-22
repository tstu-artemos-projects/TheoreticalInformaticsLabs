using System.Collections;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Contracts.AvaloniaUI.Infrastructure;

namespace Contracts.AvaloniaUI.Controls;

public partial class OptionListControl : UserControl
{
  public static readonly StyledProperty<IEnumerable?> OperationsProperty =
    AvaloniaProperty.Register<OptionListControl, IEnumerable?>(nameof(Operations));

  public static readonly StyledProperty<IOperation?> SelectedOptionProperty =
    AvaloniaProperty.Register<OptionListControl, IOperation?>(
      nameof(SelectedOption),
      defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

  public IEnumerable? Operations
  {
    get => GetValue(OperationsProperty);
    set => SetValue(OperationsProperty, value);
  }

  public IOperation? SelectedOption
  {
    get => GetValue(SelectedOptionProperty);
    set => SetValue(SelectedOptionProperty, value);
  }

  public OptionListControl()
  {
    InitializeComponent();
  }
}

