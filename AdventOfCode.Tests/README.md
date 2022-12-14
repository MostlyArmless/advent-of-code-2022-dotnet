# Advent of Code 2022
I'm using this as an opportunity to practice C# using .NET 7.0 to solve the AOC 2022 problems

# Dev Instructions
`dotnet run --project ./AdventOfCode/` to run, enter the problem number and part number when prompted, or to run programmatically you can just `dotnet run --project ./AdventOfCode 1 2` e.g. to run Day 1 part 2

`dotnet watch test --project ./AdventOfCode.Tests/` while developing to run the tests with a watch

# Things I've learned during this project
* `dotnet package add moq` to install a package, kind of the equivalent to `npm install somePackageName`
* My work machine had a global nuget source defined which I wasn't authenticated against, so I wasn't able to install any packages until I went `dotnet nuget list source` to discover the sources, then `dotnet nuget disable source TheBadSourceName`, then I could successfully run `dotnet package add moq`
* The C# syntax `@"blah blah blah"` denotes a literal string, where escaping inside the string is not respected.