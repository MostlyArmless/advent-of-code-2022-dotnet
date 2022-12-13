namespace AdventOfCode
{
  public class AOC2022
  {
    // Main entry point for CLI
    public static void Main(string[] args)
    {
      // See if there was a day number passed in
      int dayNumber = 0;
      int partNumber = 0;
      if (args.Length == 2)
      {
        dayNumber = Convert.ToInt32(args[0]);
        partNumber = Convert.ToInt32(args[1]);
      }
      else
      {
        Console.WriteLine("Enter a number to run the corresponding day's code");
        dayNumber = Convert.ToInt32(Console.ReadLine());
      }

      var dataProvider = new RealProblemDataProvider(dayNumber);
      var problemSolver = Activator.CreateInstance(Type.GetType($"AdventOfCode.Day{dayNumber}")!, dataProvider);
      var runner = problemSolver?.GetType()?.GetMethod($"RunPart{partNumber}");

      // Time the execution of the Invoke method
      var stopwatch = new System.Diagnostics.Stopwatch();
      stopwatch.Start();
      var result = runner?.Invoke(problemSolver, null);
      stopwatch.Stop();
      Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds}ms");

      Console.WriteLine($"The answer to day {dayNumber} is: {result}");
    }
  }
}