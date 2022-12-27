using System;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    public class Graph<T>
    {
        public Dictionary<T, HashSet<T>> Neighbors { get; } = new Dictionary<T, HashSet<T>>();

        public Graph(IEnumerable<Tuple<T, T>> relationships, IEnumerable<T> nodeValues)
        {
            foreach (var nodeValue in nodeValues)
            {
                Neighbors[nodeValue] = new HashSet<T>();
            }

            foreach (var relation in relationships)
            {
                Neighbors[relation.Item1].Add(relation.Item2);
                Neighbors[relation.Item2].Add(relation.Item1);
            }
        }

        public static Node CreateTree()
        {
            var uno = new Node("juan_uno");
            var dos = new Node("juan_dos");
            var juan = new Node("juan", new List<Node>() { uno, dos });

            var pedro = new Node("pedro");
            var esteban = new Node("esteban", new List<Node>() { juan, pedro });

            return esteban;
        }

        public static Graph<int> CreateGraph()
        {
            var nodeValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var relationships = new[]{
                Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5),
                Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,8),
                Tuple.Create(8,9), Tuple.Create(8,10)};

            return new Graph<int>(relationships, nodeValues);
        }
    }
}