using Moq;

namespace AdventOfCode.Tests
{
  public class Day3Tests : IDisposable
  {
    public Day3Tests()
    {
      _mockDataProvider.Setup(x => x.GetInputData()).Returns(sampleInput);
    }

    public void Dispose()
    {
      _mockDataProvider.Reset();
    }

    private const string sampleInput = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
    private Mock<IDataProvider> _mockDataProvider = new Mock<IDataProvider>();

    [Fact]
    public void TestDay3Part1()
    {
      var solver = new Day3(_mockDataProvider.Object);
      var result = solver.RunPart1();
      Assert.Equal(157, result);
    }

    [Fact]
    public void TestDay3Part2()
    {
      var solver = new Day3(_mockDataProvider.Object);
      var result = solver.RunPart1();
      Assert.Equal(42, result);
    }
  }
}