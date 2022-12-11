using System;

namespace AdventOfCode
{
  class AOC2022
  {
    static void Main(string[] args)
    {
      // read the lines of /inputs/day1.txt into a list
      var lines = System.IO.File.ReadAllLines(@"/inputs/day1.txt");

      // initialize an empty list
      var elves = new List<int>();

      int i = 0;
      foreach (var line in lines)
      {
        if (line == "")
          i++;
        else
          elves[i] += int.Parse(line);
      }

      foreach (var elf in elves)
      {
        Console.WriteLine(elf);
      }
    }
  }
}