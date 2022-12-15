using System.Text.RegularExpressions;

namespace AdventOfCode
{
  public class Day5 : ProblemSolver
  {
    private IDataProvider _dataProvider;
    private string? _input;
    public Day5(IDataProvider dataProvider) => _dataProvider = dataProvider;

    public ProblemResult RunPart1()
    {
      // crates letters contained between square brackets e.g. [A]
      // they exist in columns
      // first need to parse the text to discover how many columns there are

      var lines = _dataProvider
        .GetInputData()
        .Split(Environment.NewLine);

      var numberOfColumns = (lines[0].Length + 1) / 4; // since each column is of the form "[A] ", except the last one
      // initialise a dictionary of stacks, one for each column
      var stacks = new Dictionary<int, Stack<char>>(numberOfColumns);
      for (var i = 0; i < numberOfColumns; i++)
      {
        stacks.Add(i, new Stack<char>());
      }

      int iBottomRow = 0;
      while (iBottomRow < lines.Length && lines[iBottomRow].Contains('['))
      {
        iBottomRow++;
      }
      iBottomRow--; // we want the index of the last row that contains a letter
      // the instructions start 3 lines after the bottom row
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
          for (var j = numberOfCratesToMove; j > 0; j--)
          {
            var crate = fromStack.Pop();
            toStack.Push(crate);
          }
        }
      }

      // Now that all the crate movements have been completed, identify the crate that is at the top of the stack in each column
      var topCrates = new List<char>(numberOfColumns);
      for (var i = 0; i < numberOfColumns; i++)
      {
        var thisStack = stacks[i];
        var topCrate = thisStack.Peek();
        topCrates.Add(topCrate);
      }
      // convert to a string and return it
      var result = new ProblemResult() { ResultAsString = new string(topCrates.ToArray()) };
      return result;
    }

    public ProblemResult RunPart2()
    {
      throw new NotImplementedException();
    }
  }
}