using System.Diagnostics.CodeAnalysis;

namespace Contracts.BusinessLogic;

public class Guard
{
  /// <summary>
  /// Проверяет условие, при невыполнении которого вызывает
  /// исключение <see cref="ArgumentException"/> с определённым <paramref name="message"/>
  /// </summary>
  /// <param name="condition">условие</param>
  /// <param name="message">сообщение при невыполнении</param>
  /// <exception cref="ArgumentException">невыполненное условние</exception>
  public static void Requires([DoesNotReturnIf(false)] bool condition, string message) {
    if (!condition)
      throw new ArgumentException(message);
  }
}
