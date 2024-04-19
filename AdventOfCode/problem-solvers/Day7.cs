namespace AdventOfCode
{
  public class Day7 : ProblemSolver
  {
    private IDataProvider _dataProvider;
    private string? _input;
    private TreeNode currentDir;
    public Day7(IDataProvider dataProvider) => _dataProvider = dataProvider;

    // 34648596 is too high
    public ProblemResult RunPart1()
    {
      _input = _dataProvider.GetInputData();
      var lines = _input.Split(System.Environment.NewLine);
      var root = new TreeNode("/", 0, null);
      currentDir = root;

      foreach (var line in lines)
      {
        var parts = line.Split(" ");
        if (IsCommand(line))
        {
          if (parts[1] == "cd")
          {
            ChangeDir(root, parts);
          }
          else if (parts[1] == "ls")
            continue;
        }
        else
        {
          // This is the output of the most recent command (ls)
          currentDir.AddChild(new TreeNode(
            parts[1],
            parts[0] == "dir"
              ? 0 // directories have no size
              : ulong.Parse(parts[0]), // files have a size
            currentDir));
        }
      }
      // root.PrintTree();
      // traverse the entire tree and put all directories with size >= 100000 into a list
      List<TreeNode> smallDirs = root.GetDirectoriesWithSizeLessThan(1000000);
      ulong sumOfSizes = 0;
      foreach (var dir in smallDirs)
      {
        sumOfSizes += dir.size;
      }
      return new ProblemResult() { ResultAsString = sumOfSizes.ToString() };
    }

    private bool IsCommand(string line)
    {
      return line.StartsWith("$");
    }

    private void ChangeDir(TreeNode root, string[] parts)
    {
      var targetDir = parts[2];

      if (targetDir == "/")
      {
        currentDir = root;
      }
      else if (targetDir == "..")
      {
        // go to parent dir
        currentDir = currentDir?.parent;
      }
      else
      {
        // go to relative path
        currentDir = currentDir?.children.Find(x => x.name == targetDir);
      }
    }

    public ProblemResult RunPart2()
    {
      throw new NotImplementedException();
    }

    private void ParseLine(string line)
    {
      var parts = line.Split(" ");
      var name = parts[0];
      var size = int.Parse(parts[1].Replace("(", "").Replace(")", ""));
      var children = new List<string>();
      if (parts.Length > 2)
      {
        for (int i = 3; i < parts.Length; i++)
        {
          children.Add(parts[i].Replace(",", ""));
        }
      }
    }
  }
}