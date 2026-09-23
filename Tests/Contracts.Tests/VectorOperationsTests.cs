using Contracts.BusinessLogic;
using FluentAssertions;

namespace Contracts.Tests;

public class VectorOperationsTests
{
  #region Sort Tests

  [Fact]
  public void Sort_UnsortedArray_ReturnsSortedArray()
  {
    // Arrange
    int[] input = [5, 2, 8, 1, 9, 3];
    int[] expected = [1, 2, 3, 5, 8, 9];

    // Act
    int[] result = VectorOperations.Sort(input);

    // Assert
    result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
  }

  [Fact]
  public void Sort_ArrayWithDuplicatesAndNegatives_SortsCorrectly()
  {
    // Arrange
    int[] input = [-3, 0, 5, -3, 2, -10];
    int[] expected = [-10, -3, -3, 0, 2, 5];

    // Act
    int[] result = VectorOperations.Sort(input);

    // Assert
    result.Should().BeInAscendingOrder();
  }

  [Fact]
  public void Sort_SingleElementArray_ReturnsSameElement()
  {
    // Arrange
    int[] input = [42];

    // Act
    int[] result = VectorOperations.Sort(input);

    // Assert
    result.Should().Equal(42);
  }

  [Fact]
  public void Sort_AlreadySortedArray_ReturnsSameSequence()
  {
    // Arrange
    int[] input = [1, 2, 3, 4, 5];

    // Act
    int[] result = VectorOperations.Sort(input);

    // Assert
    result.Should().BeInAscendingOrder();
  }

  [Fact]
  public void Sort_NullInput_ThrowsArgumentExceptionOrPreconditionException()
  {
    // Act
    Action act = () => VectorOperations.Sort(null!);

    // Assert
    act.Should().Throw<Exception>()
       .WithMessage("*Предусловие: был передан нулевой указатель*");
  }

  [Fact]
  public void Sort_EmptyArray_ThrowsArgumentExceptionOrPreconditionException()
  {
    // Act
    Action act = () => VectorOperations.Sort([]);

    // Assert
    act.Should().Throw<Exception>()
       .WithMessage("*Предусловие: вектор не содержит в себе элементов*");
  }

  #endregion

  #region FindMinMax Tests

  [Theory]
  [InlineData(new[] { 1, 5, 3, 9, 2 }, 1, 9)]
  [InlineData(new[] { -10, -5, -20, -1 }, -20, -1)]
  [InlineData(new[] { 7, 7, 7, 7 }, 7, 7)]
  [InlineData(new[] { 100 }, 100, 100)]
  public void FindMinMax_ValidArrays_ReturnsCorrectMinAndMax(int[] input, int expectedMin, int expectedMax)
  {
    // Act
    var (min, max) = VectorOperations.FindMinMax(input);

    // Assert
    min.Should().Be(expectedMin);
    max.Should().Be(expectedMax);
  }

  [Fact]
  public void FindMinMax_ArrayWithExtremeValues_HandlesIntMinAndMax()
  {
    // Arrange
    int[] input = [int.MinValue, 0, int.MaxValue];

    // Act
    var (min, max) = VectorOperations.FindMinMax(input);

    // Assert
    min.Should().Be(int.MinValue);
    max.Should().Be(int.MaxValue);
  }

  [Fact]
  public void FindMinMax_NullInput_ThrowsPreconditionException()
  {
    // Act
    Action act = () => VectorOperations.FindMinMax(null!);

    // Assert
    act.Should().Throw<Exception>()
       .WithMessage("*Предусловие: был передан нулевой указатель*");
  }

  [Fact]
  public void FindMinMax_EmptyArray_ThrowsPreconditionException()
  {
    // Act
    Action act = () => VectorOperations.FindMinMax([]);

    // Assert
    act.Should().Throw<Exception>()
       .WithMessage("*Предусловие: вектор не содержит в себе элементов*");
  }

  #endregion

  #region Sum Tests

  [Theory]
  [InlineData(new[] { 1, 2, 3, 4, 5 }, 15L)]
  [InlineData(new[] { -5, 5, -10, 10 }, 0L)]
  [InlineData(new[] { 100 }, 100L)]
  public void Sum_StandardArrays_CalculatesCorrectSum(int[] input, long expectedSum)
  {
    // Act
    long sum = VectorOperations.Sum(input);

    // Assert
    sum.Should().Be(expectedSum);
  }

  [Fact]
  public void Sum_LargeValuesThatWouldOverflowInt_CalculatesCorrectLongSum()
  {
    // Arrange
    // Двукратное сложение int.MaxValue превысит диапазон System.Int32
    int[] input = [int.MaxValue, int.MaxValue];
    long expectedSum = (long)int.MaxValue * 2;

    // Act
    long sum = VectorOperations.Sum(input);

    // Assert
    sum.Should().Be(expectedSum);
  }

  [Fact]
  public void Sum_NullInput_ThrowsPreconditionException()
  {
    // Act
    Action act = () => VectorOperations.Sum(null!);

    // Assert
    act.Should().Throw<Exception>()
       .WithMessage("*Предусловие: был передан нулевой указатель*");
  }

  [Fact]
  public void Sum_EmptyArray_ThrowsPreconditionException()
  {
    // Act
    Action act = () => VectorOperations.Sum([]);

    // Assert
    act.Should().Throw<Exception>()
       .WithMessage("*Предусловие: вектор не содержит в себе элементов*");
  }

  #endregion
}
