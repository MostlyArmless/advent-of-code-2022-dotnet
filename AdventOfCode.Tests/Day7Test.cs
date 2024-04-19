using Moq;

namespace AdventOfCode.Tests
{
  public class Day7Tests
  {
    private const string sampleInput = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";
    private Mock<IDataProvider> _mockDataProvider;
    public Day7Tests()
    {
      _mockDataProvider = new Mock<IDataProvider>();
      _mockDataProvider.Setup(x => x.GetInputData()).Returns(sampleInput);
    }

    [Fact]
    public void TestDay7Part1()
    {
      var solver = new Day7(_mockDataProvider.Object);
      var result = solver.RunPart1().ResultAsString;
      Assert.Equal("95437", result);
    }

    [Fact]
    public void TestDay7Part2()
    {
      var solver = new Day7(_mockDataProvider.Object);
      var result = solver.RunPart2().ResultAsString;
      Assert.Equal("stuff", result);
    }
  }
}