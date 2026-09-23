using CommunityToolkit.Mvvm.ComponentModel;
using Contracts.BusinessLogic;

namespace Contracts.AvaloniaUI.ViewModels.Operations;

public partial class SortOperationViewModel : OperationViewModelBase
{
  public override string Title => "1. Сортировка вектора";
  public override string Description => "Сортирует элементы вектора по возрастанию.";
  public override string PreConditionDescription => "1. vec != null\n2. vec.Length > 0";
  public override string PostConditionDescription => "1. IsSorted(result) == true\n2. result.Length == vec.Length";
  public override string SideEffectsDescription => "Возвращает новый отсортированный массив. Исходный массив не изменяется.";
  public override string ValidExample => "Вход: \"5, -2, 8, 1\"\nРезультат: \"-2, 1, 5, 8\"";
  public override string InvalidExample => "Вход: \"\" (пусто)\nPre = false";

  [ObservableProperty]
  private string _resultText = string.Empty;

  protected override void ExecuteCore(int[] vector)
  {
    var result = VectorOperations.Sort(vector);
    ResultText = string.Join(", ", result);
  }
}
