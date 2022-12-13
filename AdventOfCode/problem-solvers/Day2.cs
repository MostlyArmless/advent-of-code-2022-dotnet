namespace AdventOfCode
{
  public class Day2 : ProblemSolver
  {
    public enum Shape { Rock, Paper, Scissors };
    private IDataProvider _dataProvider;
    private string? _input;
    public Day2(IDataProvider dataProvider) => _dataProvider = dataProvider;

    public int RunPart1()
    {
      _input = _input ?? _dataProvider.GetInputData();

      var rounds = _input
        .Split(Environment.NewLine)
        .Select(x => x.Split(" "))
        .ToArray();

      int score = 0;
      foreach (var round in rounds)
      {
        Shape theirMove = ParseMove(round[0]);
        Shape myMove = ParseMove(round[1]);
        score += GetScoreFromShape(myMove) + GetScoreFromLoseDrawWin(theirMove, myMove);
      }

      return score;
    }

    public int RunPart2()
    {
      throw new NotImplementedException();
    }

    public bool DoIWin(Shape theirMove, Shape myMove)
    {
      return (theirMove, myMove) switch
      {
        (Shape.Rock, Shape.Paper) => true,
        (Shape.Paper, Shape.Scissors) => true,
        (Shape.Scissors, Shape.Rock) => true,
        _ => false
      };
    }

    private Shape ParseMove(string move)
    {
      return (move) switch
      {
        "X" => Shape.Rock,
        "A" => Shape.Rock,
        "Y" => Shape.Paper,
        "B" => Shape.Paper,
        "Z" => Shape.Scissors,
        "C" => Shape.Scissors,
        _ => throw new Exception($"Invalid move '{move}'")
      };
    }

    private int GetScoreFromShape(Shape move)
    {
      return (move) switch
      {
        Shape.Rock => 1,
        Shape.Paper => 2,
        Shape.Scissors => 3,
        _ => throw new Exception($"Invalid move '{move}'")
      };
    }

    private int GetScoreFromLoseDrawWin(Shape theirMove, Shape myMove)
    {
      return (theirMove.Equals(myMove)
        ? 3 // Draw is worth 3 points
        : (DoIWin(theirMove, myMove)
          ? 6 // Wins are worth 6 points
          : 0)); // Losses are worth 0 points
    }
  }
}