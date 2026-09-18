using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Contracts.BusinessLogic;

public class VectorOperations
{
  /// <summary>
  /// Проверка сортировки
  /// </summary>
  /// <param name="vec">вектор</param>
  /// <returns>результат</returns>
  private static bool IsSorted(int[] vec)
  {
    for (int i = 0; i < vec.Length - 1; i++)
      if (vec[i] > vec[i + 1]) return false;
    return true;
  }

  /// <summary>
  /// Сортировка вектора по возрастанию
  /// </summary>
  /// <param name="vec">вектор, подлеащий сортировке</param>
  /// <returns>отсортированный вектор</returns>
  [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
  public static int[] Sort(int[] vec)
  {
    Guard.Requires(vec != null, "Предусловие: был передан нулевой указатель");
    Guard.Requires(vec.Length > 0, "Предусловие: вектор не содержит в себе элементов");

    var res = vec.OrderBy(x => x).ToArray();

    Debug.Assert(IsSorted(res), "Постусловие: вектор не был упорядочен по возрастанию");
    Debug.Assert(res.Length == vec.Length, "Постусловие: вектор имеет длину, отличную от того, что было" +
                                           "передано на вход");

    return [.. res];
  }

  /// <summary>
  /// Ищет в векторе максимальный и минимальный элементы
  /// </summary>
  /// <param name="vec">вектор</param>
  /// <returns>кортеж, состоящий из минимального и максимального значения внутри вектора</returns>
  public static (int Min, int Max) FindMinMax(int[] vec)
  {
    Guard.Requires(vec != null, "Предусловие: был передан нулевой указатель");
    Guard.Requires(vec.Length > 0, "Предусловие: вектор не содержит в себе элементов");

    var targets = vec.Aggregate(
      (Min: vec[0], Max: vec[0]),
      (acc, val) => (
        Math.Min(acc.Min, val),
        Math.Max(acc.Max, val)
      )
    );

    int[] tarVec = [targets.Min, targets.Max];

    Debug.Assert(targets.Min <= targets.Max, "Постусловие: минимальное значение каким-то неведомым образом больше максимального");
    Debug.Assert(tarVec.All(vec.Contains),
      "Постусловие: минимальное или максимальное значение вне вектора");

    return targets;
  }

  /// <summary>
  /// Суммирует вектор
  /// </summary>
  /// <param name="vec">вектор</param>
  /// <returns>сумма всех элементов, что находились в векторе</returns>
  public static long Sum(int[] vec)
  {
    Guard.Requires(vec != null, "Предусловие: был передан нулевой указатель");
    Guard.Requires(vec.Length > 0, "Предусловие: вектор не содержит в себе элементов");

    long sum = vec.Sum(x => (long)x);

    var (min, max) = FindMinMax(vec);
    Debug.Assert(sum >= (long)min * vec.Length,
      "Постусловие: сумма меньше возможного минимума");
    Debug.Assert(sum <= (long)max * vec.Length,
      "Постусловие: сумма больше возможного максимума");

    return sum;
  }
}
