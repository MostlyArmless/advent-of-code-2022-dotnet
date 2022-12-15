using System.Text.RegularExpressions;

namespace AdventOfCode
{
  public class Day5 : ProblemSolver
  {
    private IDataProvider _dataProvider;
    public Day5(IDataProvider dataProvider) => _dataProvider = dataProvider;

    public ProblemResult RunPart1()
    {
      var lines = PopulateLines();
      var numberOfColumns = (lines[0].Length + 1) / 4; // since each column is of the form "[A] ", except the last one
      var stacks = InitializeStacks(numberOfColumns);
      var iBottomRow = DetermineBottomRow(lines);
      int iStartOfInstructions = StackTheCrates(lines, stacks, iBottomRow);
      ParseInstructionsAndMoveCrates(lines, stacks, iStartOfInstructions, MoveCratesOneByOne);
      return IdentifyTopCrateInEachStack(numberOfColumns, stacks);
    }

    public ProblemResult RunPart2()
    {
      var lines = PopulateLines();
      var numberOfColumns = (lines[0].Length + 1) / 4; // since each column is of the form "[A] ", except the last one
      var stacks = InitializeStacks(numberOfColumns);
      var iBottomRow = DetermineBottomRow(lines);
      int iStartOfInstructions = StackTheCrates(lines, stacks, iBottomRow);
      ParseInstructionsAndMoveCrates(lines, stacks, iStartOfInstructions, MoveNCratesAtATime);
      return IdentifyTopCrateInEachStack(numberOfColumns, stacks);
    }

    private static void ParseInstructionsAndMoveCrates(string[] lines, Dictionary<int, Stack<char>> stacks, int iStartOfInstructions, Action<int, Stack<char>, Stack<char>> MoveCratesSomehow)
    {
      // each line is of the form "move \d+ from \d+ to \d+",
      // so use a regex with capture groups to extract those numbers
      var regex = new Regex(@"move (\d+) from (\d+) to (\d+)");
      for (var i = iStartOfInstructions; i < lines.Length; i++)
      {
        var line = lines[i];
        var match = regex.Match(line);
        if (match.Success)
        {
          // Identify how many crates need to be moved from which column to which column
          var numberOfCratesToMove = int.Parse(match.Groups[1].Value);
          var fromCol = int.Parse(match.Groups[2].Value);
          var toCol = int.Parse(match.Groups[3].Value);
          var fromStack = stacks[fromCol - 1];
          var toStack = stacks[toCol - 1];

          // Actually move the crates
          MoveCratesSomehow(numberOfCratesToMove, fromStack, toStack);
        }
      }
    }

    private static void MoveCratesOneByOne(int numberOfCratesToMove, Stack<char> fromStack, Stack<char> toStack)
    {
      for (var j = numberOfCratesToMove; j > 0; j--)
      {
        var crate = fromStack.Pop();
        toStack.Push(crate);
      }
    }

    private static void MoveNCratesAtATime(int numberOfCratesToMove, Stack<char> fromStack, Stack<char> toStack)
    {
      var cratesToMove = new List<char>(numberOfCratesToMove);
      for (var j = numberOfCratesToMove; j > 0; j--)
      {
        var crate = fromStack.Pop();
        cratesToMove.Add(crate);
      }
      cratesToMove.Reverse();
      foreach (var crate in cratesToMove)
      {
        toStack.Push(crate);
      }
    }

    private static ProblemResult IdentifyTopCrateInEachStack(int numberOfColumns, Dictionary<int, Stack<char>> stacks)
    {
      // Now that all the crate movements have been completed, identify the crate that is at the top of the stack in each column
      var topCrates = new List<char>(numberOfColumns);
      for (var i = 0; i < numberOfColumns; i++)
      {
        var thisStack = stacks[i];
        var topCrate = thisStack.Peek();
        topCrates.Add(topCrate);
      }
      // convert to a string and return it
      return new ProblemResult() { ResultAsString = new string(topCrates.ToArray()) };
    }

    private static int StackTheCrates(string[] lines, Dictionary<int, Stack<char>> stacks, int iBottomRow)
    {
      // the instructions start 3 _lines after the bottom row
      int iStartOfInstructions = iBottomRow + 3;

      for (var i = iBottomRow; i >= 0; i--)
      {
        var line = lines[i];
        var characters = line.ToCharArray();
        // We're using 0-based indexing, the problem uses 1-based indexing
        int colIndex = 0;
        // the characters are at positions 1,5,9,... = 4n+1
        for (var j = 1; j < characters.Length; j += 4)
        {
          var thisCol = stacks[colIndex] ?? new Stack<char>();
          var thisCrate = characters[j];
          if (thisCrate != ' ')
            thisCol.Push(thisCrate);
          colIndex++;
        }
      }

      return iStartOfInstructions;
    }

    private string[] PopulateLines()
    {
      return _dataProvider
        .GetInputData()
        .Split(Environment.NewLine);
    }

    private Dictionary<int, Stack<char>> InitializeStacks(int numberOfColumns)
    {
      // initialise a dictionary of stacks, one for each column
      var stacks = new Dictionary<int, Stack<char>>(numberOfColumns);
      for (var i = 0; i < numberOfColumns; i++)
      {
        stacks.Add(i, new Stack<char>());
      }
      return stacks;
    }

    private int DetermineBottomRow(string[] lines)
    {
      int iBottomRow = 0;
      while (iBottomRow < lines.Length && lines[iBottomRow].Contains('['))
      {
        iBottomRow++;
      }
      iBottomRow--; // we want the index of the last row that contains a letter
      return iBottomRow;
    }
  }
}