using Avalonia.Controls;
using Contracts.AvaloniaUI.ViewModels;

namespace Contracts.AvaloniaUI;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
    DataContext = new MainWindowViewModel();
  }
}
