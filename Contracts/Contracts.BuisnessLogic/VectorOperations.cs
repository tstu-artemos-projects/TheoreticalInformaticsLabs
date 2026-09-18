using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Contracts.BuisnessLogic;

public class VectorOperations
{
  /// <summary>
  /// Сортировка вектора по возрастанию
  /// </summary>
  /// <param name="vec">вектор, подлеащий сортировке</param>
  /// <returns>отсортированный вектор</returns>
  [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
  [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
  public static int[] Sort(int[] vec)
  {
    Guard.Requires(vec != null, "Предусловие: был передан нулевой указатель");
#pragma warning disable CS8602 // Dereference of a possibly null reference. Мы это раннее проверили
    Guard.Requires(vec.Length > 0, "Предусловие: вектор не содержит в себе элементов");
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    var res = vec.OrderBy(x => x);

    Debug.Assert(
      res.SequenceEqual(vec.OrderBy(x => x)),
      "Постусловие: вектор не был упорядочен по возрастан и/или он не содержит всех тех элементов," +
      "что были в вводе");

    return [.. res];
  }

  /// <summary>
  /// Ищет в векторе максимальный и минимальный элементы
  /// </summary>
  /// <param name="vec">вектор</param>
  /// <returns>кортеж, состоящий из минимального и максимального значения внутри вектора</returns>
  [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
  public static (int Min, int Max) FindMinMax(int[] vec)
  {
    Guard.Requires(vec != null, "Предусловие: был передан нулевой указатель");
#pragma warning disable CS8602 // Dereference of a possibly null reference. Мы это раннее проверили
    Guard.Requires(vec.Length > 0, "Предусловие: вектор не содержит в себе элементов");
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    int min = vec.Min();
    int max = vec.Max();

    Debug.Assert(min <= max, "Постусловие: минимальное значение каким-то неведомым образом больше максимального");
    Debug.Assert(vec.Contains(min) && vec.Contains(max),
      "Нарушено постусловие: минимальное или максимальное значение вне вектора");

    return (min, max);
  }

  /// <summary>
  /// Суммирует вектор
  /// </summary>
  /// <param name="vec">вектор</param>
  /// <returns>сумма всех элементов, что находились в векторе</returns>
  [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
  public static long Sum(int[] vec)
  {
    Guard.Requires(vec != null, "Предусловие: был передан нулевой указатель");
#pragma warning disable CS8602 // Dereference of a possibly null reference. Мы это раннее проверили
    Guard.Requires(vec.Length > 0, "Предусловие: вектор не содержит в себе элементов");
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    long sum = vec.Sum();

    var (min, max) = FindMinMax(vec);
    Debug.Assert(sum >= (long)min * vec.Length,
      "Постусловие: сумма меньше возможного минимума");
    Debug.Assert(sum <= (long)max * vec.Length,
      "Постусловие: сумма больше возможного максимума");

    return sum;
  }
}
