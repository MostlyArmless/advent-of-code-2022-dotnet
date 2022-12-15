namespace AdventOfCode
{
  public class Day6 : ProblemSolver
  {
    private IDataProvider _dataProvider;
    private string? _input;
    public Day6(IDataProvider dataProvider) => _dataProvider = dataProvider;

    public ProblemResult RunPart1()
    {
      _input = _input ?? _dataProvider.GetInputData();
      int numCharsProcessed = FindPositionOfUniqueNCharSubstring(4);
      return new ProblemResult() { ResultAsInt = numCharsProcessed };
    }

    public ProblemResult RunPart2()
    {
      _input = _input ?? _dataProvider.GetInputData();
      int numCharsProcessed = FindPositionOfUniqueNCharSubstring(14);
      return new ProblemResult() { ResultAsInt = numCharsProcessed };
    }

    private int FindPositionOfUniqueNCharSubstring(int numConsecutiveUniqueChars)
    {
      // Need to find the first place where numConsecutiveUniqueChars unique characters appear in a row
      var q = new Queue<char>(numConsecutiveUniqueChars);
      int numCharsProcessed = 0;
      for (int i = 0; i < _input?.Length; i++)
      {
        q.Enqueue(_input[i]);
        if (q.Count == numConsecutiveUniqueChars + 1)
          q.Dequeue();

        numCharsProcessed++;
        if (numCharsProcessed >= numConsecutiveUniqueChars && AllCharactersInQueueAreUnique(q))
          break;
      }

      return numCharsProcessed;
    }

    private bool AllCharactersInQueueAreUnique(Queue<char> q)
    {
      return q.Count == q.Distinct().Count();
    }
  }
}