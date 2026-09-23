using CommunityToolkit.Mvvm.ComponentModel;
using Contracts.BusinessLogic;

namespace Contracts.AvaloniaUI.ViewModels.Operations;

public partial class SumOperationViewModel : OperationViewModelBase
{
  public override string Title => "3. Сумма вектора";
  public override string Description => "Вычисляет сумму всех элементов вектора.";
  public override string PreConditionDescription => "1. vec != null\n2. vec.Length > 0";
  public override string PostConditionDescription => "1. sum >= Min * Length\n2. sum <= Max * Length";
  public override string SideEffectsDescription => "Чистая функция, предотвращает переполнение за счет long.";
  public override string ValidExample => "Вход: \"10, 20, 30\"\nРезультат: 60";
  public override string InvalidExample => "Вход: \" \"\nPre = false";

  [ObservableProperty] private long? _sumValue;

  protected override void ExecuteCore(int[] vector)
  {
    SumValue = VectorOperations.Sum(vector);
  }
}
