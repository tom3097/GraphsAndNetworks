using System;
using Common;

namespace Testing
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            DisjointSetsDataStructure sets = new DisjointSetsDataStructure(5);

            sets.Union(0, 1);
            sets.Union(0, 2);
            sets.Union(3, 4);
            sets.Union(2, 3);
            
            if (sets.FindSet(0) != sets.FindSet(4))
                throw new Exception();

            double?[,] testGraphMatrix = 
                {
                    {null, 0, 1, 1, 0},
                    {0, null, 1, 0, 1},
                    {1, 1, null, 0, 1},
                    {1, 0, 0, null, 0},
                    {0, 1, 1, 0, null}
                };

            var mst = Boruvka.Boruvka.Run(new Graph(testGraphMatrix));
            Console.WriteLine("Number of nodes: " + 5);
            Console.WriteLine("Number of edges: " + mst.Count);
            
            var sparseGraph = GraphGenerator.GenerateSparse(1000);
            mst = Boruvka.Boruvka.Run(sparseGraph);
            
            Console.WriteLine("Number of nodes: " + 1000);
            Console.WriteLine("Number of edges: " + mst.Count);
            
            var denseGraph = GraphGenerator.GenerateDense(1000);
            mst = Boruvka.Boruvka.Run(denseGraph);
            
            Console.WriteLine("Number of nodes: " + 1000);
            Console.WriteLine("Number of edges: " + mst.Count);
        }
    }
}