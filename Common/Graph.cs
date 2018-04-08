using System.Collections.Generic;

namespace Common
{
    public class Graph
    {
        public HashSet<Edge> Edges { get; }

        public HashSet<int> Nodes
        {
            get
            {
                var nodeSet = new HashSet<int>();
                foreach (var edge in Edges)
                {
                    nodeSet.Add(edge.U);
                    nodeSet.Add(edge.V);
                }
                return nodeSet;
            }
        }

        public Graph(double?[,] edgeMatrix)
        {
            Edges = new HashSet<Edge>();
            for (int i = 0; i < edgeMatrix.GetLength(0); ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    double? weight = edgeMatrix[i, j];
                    if (weight != null)
                    {
                        Edges.Add(new Edge(i, j, (double) weight));
                    }
                }
            }
        }
    }
}