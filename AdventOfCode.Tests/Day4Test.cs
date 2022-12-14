using Moq;

namespace AdventOfCode.Tests
{
  public class Day4Tests
  {
    private const string sampleInput = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";
    private Mock<IDataProvider> _mockDataProvider;
    public Day4Tests()
    {
      _mockDataProvider = new Mock<IDataProvider>();
      _mockDataProvider.Setup(x => x.GetInputData()).Returns(sampleInput);
    }

    [Fact]
    public void TestDay4Part1()
    {
      var solver = new Day4(_mockDataProvider.Object);
      var result = solver.RunPart1();
      Assert.Equal(2, result);
    }

    [Fact]
    public void TestDay4Part2()
    {
      var solver = new Day4(_mockDataProvider.Object);
      var result = solver.RunPart2();
      Assert.Equal(42, result);
    }
  }
}