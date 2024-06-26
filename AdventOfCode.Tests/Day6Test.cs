using Moq;

namespace AdventOfCode.Tests
{
  public class Day6Tests
  {
    private Mock<IDataProvider> _mockDataProvider;
    public Day6Tests()
    {
      _mockDataProvider = new Mock<IDataProvider>();
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void TestDay6Part1(string input, int expectedMarkerPosition)
    {
      _mockDataProvider.Setup(x => x.GetInputData()).Returns(input);
      var solver = new Day6(_mockDataProvider.Object);
      var result = solver.RunPart1().ResultAsInt;
      Assert.Equal(expectedMarkerPosition, result);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void TestDay6Part2(string input, int expectedMarkerPosition)
    {
      _mockDataProvider.Setup(x => x.GetInputData()).Returns(input);
      var solver = new Day6(_mockDataProvider.Object);
      var result = solver.RunPart2().ResultAsInt;
      Assert.Equal(expectedMarkerPosition, result);
    }
  }
}