namespace AdventOfCode;
public class Day1 : ProblemSolver
{
  private IDataProvider _dataProvider;
  public Day1(IDataProvider dataProvider)
  {
    _dataProvider = dataProvider;
  }

  public int Run()
  {
    var input = _dataProvider.GetInputData();
    var elves = CalculateCaloriesPerElf(input);

    foreach (var elf in elves)
    {
      Console.WriteLine(elf);
    }

    return GetTotalCaloriesOfElfCarryTheMostCalories(elves);
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