namespace AdventOfCode.Tests;
using Moq;

public class Day1Test
{
  public static IEnumerable<object[]> TestData => new List<object[]>
  {
    new object[] { @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000", 24000 },
    new object[] {
        File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"./inputs/day1.txt")),
        69795
    }
  };


  [Theory]
  [MemberData(nameof(TestData))]
  public void TestCalorieCounter(string inputString, int expectedCaloriesOfElfCarryingTheMostCalories)
  {
    var mockDataProvider = new Mock<IDataProvider>();
    mockDataProvider.Setup(x => x.GetInputData()).Returns(inputString);
    var day1 = new Day1(mockDataProvider.Object);
    var maxElfCalories = day1.Run();

    Assert.Equal(expectedCaloriesOfElfCarryingTheMostCalories, maxElfCalories);
  }
}