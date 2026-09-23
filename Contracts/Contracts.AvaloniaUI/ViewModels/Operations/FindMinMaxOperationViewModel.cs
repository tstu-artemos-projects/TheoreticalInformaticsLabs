using CommunityToolkit.Mvvm.ComponentModel;
using Contracts.BusinessLogic;

namespace Contracts.AvaloniaUI.ViewModels.Operations;

public partial class FindMinMaxOperationViewModel : OperationViewModelBase
{
  public override string Title => "2. Мин/Макс в векторе";
  public override string Description => "Находит минимальный и максимальный элементы в векторе.";
  public override string PreConditionDescription => "1. vec != null\n2. vec.Length > 0";
  public override string PostConditionDescription => "1. Min <= Max\n2. Min и Max содержатся в исходном векторе";
  public override string SideEffectsDescription => "Чистая функция, без побочных эффектов.";
  public override string ValidExample => "Вход: \"10, -5, 42, 0\"\nРезультат: Мин = -5, Макс = 42";
  public override string InvalidExample => "Вход: \"abc\"\nPre = false";

  [ObservableProperty] private int? _minValue;
  [ObservableProperty] private int? _maxValue;

  protected override void ExecuteCore(int[] vector)
  {
    var (min, max) = VectorOperations.FindMinMax(vector);
    MinValue = min;
    MaxValue = max;
  }
}
