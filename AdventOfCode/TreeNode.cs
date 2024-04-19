public class TreeNode
{
  public ulong size { get; set; } = 0;
  public HashSet<TreeNode>? children { get; set; } = null;
  public TreeNode? parent { get; set; } = null;
  public string name { get; set; } = "";
  public TreeNode(string name, ulong ownSize = 0, TreeNode? parent = null)
  {
    this.name = name;
    this.size = ownSize;
    this.parent = parent;
  }

  public void AddChild(TreeNode child)
  {
    children = children ?? new HashSet<TreeNode>();

    child.parent = this;
    children.Add(child);
    if (child.size == 0)
      return;
    // Recursively increment the size of all parents all the way up to the root
    var current = child;
    while (current.parent != null)
    {
      current.parent.size = current?.parent.size == null
        ? current.size
        : current.parent.size + current.size;
      current = current.parent;
    }
  }

  public List<TreeNode> GetDirectoriesWithSizeLessThan(ulong size)
  {
    // visit every node in the tree
    var matchingNodes = new List<TreeNode>();
    var stack = new Stack<TreeNode>();
    stack.Push(this);
    while (stack.Count > 0)
    {
      var current = stack.Pop();
      if (current.children != null)
      {
        foreach (var child in current.children)
        {
          stack.Push(child);
        }
        if (current.size <= size)
        {
          matchingNodes.Add(current);
        }
      }
    }
    return matchingNodes;
  }

  public override string ToString()
  {
    string dirOrFile = children?.Count > 0 ? "dir" : "file";
    return $"{name} ({dirOrFile}), size={size})";
  }

  private class NodeWithIndent
  {
    public TreeNode node { get; set; }
    public int indent { get; set; }
    public override string ToString()
    {
      return $"{new string(' ', indent)}- {node.ToString()}";
    }
  }
  public void PrintTree()
  {
    // recursively print the tree
    var stack = new Stack<NodeWithIndent>();
    stack.Push(new NodeWithIndent() { node = this, indent = 0 });
    int numNodesVisited = 0;
    while (stack.Count > 0)
    {
      var current = stack.Pop();
      numNodesVisited++;
      Console.WriteLine(current.ToString());
      if (current.node.children != null)
      {
        foreach (var child in current.node.children)
        {
          stack.Push(new NodeWithIndent() { node = child, indent = current.indent + 2 });
        }
      }
    }
  }

  public bool Equals(TreeNode other)
  {
    return other != null && other.name == name;
  }
}