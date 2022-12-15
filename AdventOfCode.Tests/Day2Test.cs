using Moq;

namespace AdventOfCode.Tests
{
  public class Day2Tests
  {
    private const string sampleInput = @"A Y
B X
C Z";

    [Fact]
    public void TestDay2Part1()
    {
      var mockDataProvider = new Mock<IDataProvider>();
      mockDataProvider.Setup(x => x.GetInputData()).Returns(sampleInput);
      var solver = new Day2(mockDataProvider.Object);
      var result = solver.RunPart1().ResultAsInt;
      Assert.Equal(15, result);
    }

    [Fact]
    public void TestDay2Part2()
    {
      var mockDataProvider = new Mock<IDataProvider>();
      mockDataProvider.Setup(x => x.GetInputData()).Returns(sampleInput);
      var solver = new Day2(mockDataProvider.Object);
      var result = solver.RunPart2().ResultAsInt;
      Assert.Equal(12, result);
    }
  }
}