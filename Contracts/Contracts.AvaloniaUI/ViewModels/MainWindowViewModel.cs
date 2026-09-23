using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contracts.AvaloniaUI.Infrastructure;
using Contracts.AvaloniaUI.ViewModels.Operations;

namespace Contracts.AvaloniaUI.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
  public ObservableCollection<IOperation> Operations { get; } = new();

  [ObservableProperty]
  private IOperation? _selectedOption;

  public MainWindowViewModel()
  {
    Operations.Add(new SortOperationViewModel());
    Operations.Add(new FindMinMaxOperationViewModel());
    Operations.Add(new SumOperationViewModel());

    SelectedOption = Operations.FirstOrDefault();
  }

  [RelayCommand]
  private async Task ShowContractAsync(IOperation? operation)
  {
    if (operation == null) return;

    var dialog = new Windows.ContractWindow { DataContext = operation };

    if (Avalonia.Application.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
    {
      await dialog.ShowDialog(desktop?.MainWindow);
    }
  }
}
