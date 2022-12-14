namespace AdventOfCode
{
  public class Day3 : ProblemSolver
  {
    private IDataProvider _dataProvider;
    private string? _input;
    public Day3(IDataProvider dataProvider) => _dataProvider = dataProvider;

    public int RunPart1()
    {
      // Goal: find the item type which appears in both compartments of each rucksack.
      // What is the sum of the priorities of those item types?
      _input = _input ?? _dataProvider.GetInputData();

      // 1 rucksack per line, each has 2 compartments: the first half and second half of the line
      string[][] rucksacks = _input
        .Split(Environment.NewLine)
        .Select(r => new string[] {
            r.Substring(0, r.Length / 2),
            r.Substring(r.Length / 2, r.Length / 2),
          })
        .ToArray();

      int sumOfCommonLetterPriorities = 0;
      foreach (var rucksack in rucksacks)
      {
        var firstCompartment = rucksack[0];
        var secondCompartment = rucksack[1];

        // Find which letter appears in both compartments
        // Find the priority of that letter
        char commonLetter = firstCompartment
          .Where(c => secondCompartment.Contains(c))
          .Distinct()
          .ToArray()[0];

        var priority = GetPriority(commonLetter);
        sumOfCommonLetterPriorities += priority;
      }

      return sumOfCommonLetterPriorities;
    }

    private int GetPriority(char letter)
    {
      // priority of items is a-z = 1-26, A-Z = 27-52

      if (letter >= 'a' && letter <= 'z')
      {
        return letter - 'a' + 1;
      }
      else if (letter >= 'A' && letter <= 'Z')
      {
        return letter - 'A' + 27;
      }
      else
      {
        throw new ArgumentException($"Invalid letter '{letter}'");
      }
    }

    public int RunPart2()
    {
      throw new NotImplementedException();
    }
  }
}