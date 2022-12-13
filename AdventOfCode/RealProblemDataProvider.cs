using AdventOfCode;

public class RealProblemDataProvider : IDataProvider
{
  private int DayNumber { get; set; }
  public RealProblemDataProvider(int dayNumber)
  {
    DayNumber = dayNumber;
  }

  public string GetInputData()
  {
    var dllPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
    var dllDir = System.IO.Path.GetDirectoryName(dllPath);
    return File.ReadAllText($"{dllDir}/inputs/day{DayNumber}.txt");
  }
}