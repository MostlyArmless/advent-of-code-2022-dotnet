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

      // Need to find the first place where 4 unique characters appear in a row
      var q = new Queue<char>(4);
      int numCharsProcessed = 0;
      for (int i = 0; i < _input.Length; i++)
      {
        q.Enqueue(_input[i]);
        if (q.Count == 5)
          q.Dequeue();

        numCharsProcessed++;
        if (numCharsProcessed >= 4 && AllCharactersInQueueAreUnique(q))
          break;
      }
      return new ProblemResult() { ResultAsInt = numCharsProcessed };
    }

    private bool AllCharactersInQueueAreUnique(Queue<char> q)
    {
      return q.Count == q.Distinct().Count();
    }

    public ProblemResult RunPart2()
    {
      throw new NotImplementedException();
    }
  }
}