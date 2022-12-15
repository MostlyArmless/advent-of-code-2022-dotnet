namespace AdventOfCode
{
  public class Day4 : ProblemSolver
  {
    private IDataProvider _dataProvider;
    private string? _input;
    public Day4(IDataProvider dataProvider) => _dataProvider = dataProvider;

    public ProblemResult RunPart1()
    {
      _input = _input ?? _dataProvider.GetInputData();
      var pairs = _input // string
        .Split(Environment.NewLine) // string[] (lines)
        .Select(line => line.Split(',')); // string[][] (pairs)

      int numFullyContained = 0;
      foreach (var pair in pairs)
      {
        // find cases where one elf's range is fully contained within the other's range
        int elfAMin = int.Parse(pair[0].Split('-')[0]);
        int elfAMax = int.Parse(pair[0].Split('-')[1]);
        int elfBMin = int.Parse(pair[1].Split('-')[0]);
        int elfBMax = int.Parse(pair[1].Split('-')[1]);
        bool isFullyContained = (elfAMin >= elfBMin && elfAMax <= elfBMax)
          || (elfBMin >= elfAMin && elfBMax <= elfAMax);

        if (isFullyContained)
          numFullyContained++;
      }

      return new ProblemResult() { ResultAsInt = numFullyContained };
    }

    public ProblemResult RunPart2()
    {
      // Find ranges that overlap AT ALL, rather than being fully contained
      _input = _input ?? _dataProvider.GetInputData();
      var pairs = _input // string
        .Split(Environment.NewLine) // string[] (lines)
        .Select(line => line.Split(',')); // string[][] (pairs)

      int numOverlapping = 0;
      foreach (var pair in pairs)
      {
        // find cases where each elf in the pair overlaps at all
        int elfAMin = int.Parse(pair[0].Split('-')[0]);
        int elfAMax = int.Parse(pair[0].Split('-')[1]);
        int elfBMin = int.Parse(pair[1].Split('-')[0]);
        int elfBMax = int.Parse(pair[1].Split('-')[1]);
        bool areRangesSeparate =
          elfAMax < elfBMin
          || elfBMax < elfAMin;

        if (!areRangesSeparate)
          numOverlapping++;
      }

      return new ProblemResult() { ResultAsInt = numOverlapping };
    }
  }
}