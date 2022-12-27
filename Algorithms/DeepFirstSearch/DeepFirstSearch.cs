using Algorithms.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DeepFirstSearch
{
    public class DeepFirstSearch
    {
        public void Run()
        {
            var nodeValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var relationships = new[]{
                Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5),
                Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,8),
                Tuple.Create(8,9), Tuple.Create(8,10)};

            var graph = new Graph<int>(relationships, nodeValues);

            var root = 1;

            var initialStep = new HashSet<int>() { root };
            var visited = new HashSet<int>() { root };

            var path = Find(graph, root, 10, visited, initialStep);

            foreach (var item in path)
            {
                Console.Write(item + "->");
            }
        }

        private HashSet<int> Find(Graph<int> graph,
                                  int startingPoint,
                                  int toFind,
                                  HashSet<int> visited,
                                  HashSet<int> firstValidPath)
        {
            var nodes = graph.Neighbors[startingPoint]
                                .Where(a => !visited.Contains(a))
                                .Where(a => a != startingPoint);

            if (nodes == null || !nodes.Any())
            {
                var lastVisisted = firstValidPath.Count() - 2;
                var rollback = firstValidPath.ElementAt(lastVisisted);
                firstValidPath.Remove(firstValidPath.ElementAt(firstValidPath.Count - 1));

                return Find(graph, rollback, toFind, visited, firstValidPath);
            }

            foreach (var node in nodes)
            {
                if (node == toFind)
                {
                    visited.Add(node);
                    firstValidPath.Add(node);
                    return firstValidPath;
                }

                firstValidPath.Add(node);
                visited.Add(node);

                return Find(graph, node, toFind, visited, firstValidPath);
            }

            return firstValidPath;
        }
    }
}