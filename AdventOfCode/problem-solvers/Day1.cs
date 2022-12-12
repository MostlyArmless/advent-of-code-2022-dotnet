namespace AdventOfCode;
public class Day1
{
  public static int Run()
  {
    var input = File.ReadAllText(@"./inputs/day1.txt");
    var elves = CalculateCaloriesPerElf(input);

    foreach (var elf in elves)
    {
      Console.WriteLine(elf);
    }

    return GetTotalCaloriesOfElfCarryTheMostCalories(elves);
  }

  public static int[] CalculateCaloriesPerElf(string inputData)
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

  public static int GetTotalCaloriesOfElfCarryTheMostCalories(int[] elves)
  {
    return elves.Max();
  }
}