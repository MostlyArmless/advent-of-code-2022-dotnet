namespace AdventOfCode
{
  public class AOC2022
  {
    // Main entry point for CLI
    public static void Main(string[] args)
    {
      // See if there was a day number passed in
      int dayNumber = 0;
      if (args.Length > 0)
      {
        dayNumber = Convert.ToInt32(args[0]);
      }
      else
      {
        Console.WriteLine("Enter a number to run the corresponding day's code");
        dayNumber = Convert.ToInt32(Console.ReadLine());
      }

      var dataProvider = new RealProblemDataProvider(dayNumber);
      var problemSolver = Activator.CreateInstance(Type.GetType($"AdventOfCode.Day{dayNumber}")!, dataProvider);
      var result = problemSolver?.GetType()?.GetMethod("Run")?.Invoke(problemSolver, null);
      Console.WriteLine($"The answer to day {dayNumber} is: {result}");
    }
  }
}