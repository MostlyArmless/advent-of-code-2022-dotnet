public interface ProblemSolver
{
  public ProblemResult RunPart1();
  public ProblemResult RunPart2();
}

public class ProblemResult
{
  private string resultAsString = string.Empty;

  public int ResultAsInt { get; set; }
  public string ResultAsString
  {
    get => resultAsString != string.Empty ? resultAsString : ResultAsInt.ToString();
    set => resultAsString = value;
  }
}