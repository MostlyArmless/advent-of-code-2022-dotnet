using Moq;

namespace AdventOfCode.Tests
{
  public class Day5Tests
  {
    private const string sampleInput = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";
    private Mock<IDataProvider> _mockDataProvider;
    public Day5Tests()
    {
      _mockDataProvider = new Mock<IDataProvider>();
      _mockDataProvider.Setup(x => x.GetInputData()).Returns(sampleInput);
    }

    [Fact]
    public void TestDay5Part1()
    {
      var solver = new Day5(_mockDataProvider.Object);
      var result = solver.RunPart1();
      Assert.Equal("CMZ", result.ResultAsString);
    }

    [Fact]
    public void TestDay5Part2()
    {
      var solver = new Day5(_mockDataProvider.Object);
      var result = solver.RunPart2().ResultAsString;
      Assert.Equal("stuff", result);
    }
  }
}