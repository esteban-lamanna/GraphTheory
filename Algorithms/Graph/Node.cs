using System.Collections.Generic;

namespace Algorithms.Graph
{
    public class Node
    {
        public string Name { get; set; }
        public Node Parent { get; set; }
        public IList<Node> Children { get; set; } = new List<Node>();

        public Node(string name, Node parent = null)
        {
            Name = name;
            Parent = parent;
        }

        public Node(string name, IList<Node> children)
        {
            Name = name;

            foreach (var child in children)
            {
                child.Parent = this;
                Children.Add(child);
            }
        }
    }
}