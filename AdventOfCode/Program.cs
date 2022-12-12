namespace AdventOfCode
{
  public class AOC2022
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Enter a number to run the corresponding day's code");
      int day = Convert.ToInt32(Console.ReadLine());
      switch (day)
      {
        case 1:
          var result = Day1.Run();
          Console.WriteLine($"The answer is {result}");
          break;
        default:
          Console.WriteLine("Invalid day");
          break;
      }
    }
  }
}