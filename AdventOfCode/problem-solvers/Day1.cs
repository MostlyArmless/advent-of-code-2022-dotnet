namespace AdventOfCode;
public class Day1 : ProblemSolver
{
  private IDataProvider _dataProvider;
  private string? _input;
  private int[]? _elves;

  public Day1(IDataProvider dataProvider) => _dataProvider = dataProvider;

  public ProblemResult RunPart1()
  {
    _input = _input ?? _dataProvider.GetInputData();
    _elves = _elves ?? CalculateCaloriesPerElf(_input);

    return new ProblemResult() { ResultAsInt = GetTotalCaloriesOfElfCarryTheMostCalories(_elves) };
  }

  public ProblemResult RunPart2()
  {
    _input = _input ?? _dataProvider.GetInputData();
    _elves = _elves ?? CalculateCaloriesPerElf(_input);

    // return the sum of the top numElves elves
    return new ProblemResult() { ResultAsInt = _elves.OrderByDescending(x => x).Take(3).Sum() };
  }

  private int[] CalculateCaloriesPerElf(string inputData)
  {
    var lines = inputData.Split(Environment.NewLine);
    var elves = new List<int>() { 0 };

    int i = 0;
    foreach (var line in lines)
    {
      if (line == "")
      {
        i++;
        elves.Add(0);
      }
      else
        elves[i] += int.Parse(line);
    }

    return elves.ToArray();
  }

  private int GetTotalCaloriesOfElfCarryTheMostCalories(int[] elves)
  {
    return elves.Max();
  }
}