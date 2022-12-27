using Algorithms.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DeepFirstSearch
{
    public class DeepFirstSearchWithQueue
    {
        public void Run()
        {
            var graph = Graph<int>.CreateGraph();

            var root = 1;

            var path = Find(graph, root, 10);

            foreach (var item in path)
            {
                Console.Write(item + "->");
            }
        }

        private HashSet<int> Find(Graph<int> graph,
                                  int startingPoint,
                                  int toFind)
        {
            var stack = new Stack<int>();
            var set = new HashSet<int>();
            var visited = new List<int>();

            stack.Push(startingPoint);
            set.Add(startingPoint);
            visited.Add(startingPoint);

            while (stack.Count != 0)
            {
                var item = stack.Pop();
                set.Add(item);

                if (item == toFind)
                    break;

                var adjacencies = Reverse(graph.Neighbors[item].ToArray<int>());

                foreach (var adj in adjacencies)
                {
                    if(visited.Contains(adj))
                        continue;

                    stack.Push(adj);
                    visited.Add(adj);
                }
            }

            return set;
        }

        private HashSet<int> Reverse(int[] hashSet)
        {
            var reversedHashSet = new HashSet<int>();

            for (int i = hashSet.Length -1; i >= 0; i--)
            {
                var value = hashSet[i];
                reversedHashSet.Add(value);
            }

            return reversedHashSet;
        }
    }
}