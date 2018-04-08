using System.Collections.Generic;
using Common;

namespace Boruvka
{
    public static class Boruvka
    {
        public static HashSet<Edge> Run(Graph graph)
        {
            HashSet<Edge> mst = new HashSet<Edge>();
            int nodeCount = graph.Nodes.Count;
            Edge?[] cheapestEdges = new Edge?[nodeCount];
            DisjointSetsDataStructure sets = new DisjointSetsDataStructure(nodeCount);

            int numSets = nodeCount;
            while (numSets > 1)
            {
                foreach (Edge edge in graph.Edges)
                {
                    int uRoot = sets.FindSet(edge.U);
                    int vRoot = sets.FindSet(edge.V);

                    if (uRoot != vRoot)
                    {
                        if (cheapestEdges[uRoot] == null || ((Edge) cheapestEdges[uRoot]).Weight > edge.Weight)
                        {
                            cheapestEdges[uRoot] = edge;
                        }

                        if (cheapestEdges[vRoot] == null || ((Edge) cheapestEdges[vRoot]).Weight > edge.Weight)
                        {
                            cheapestEdges[vRoot] = edge;
                        }
                    }
                }

                for (int i = 0; i < nodeCount; ++i)
                {
                    if (cheapestEdges[i] != null)
                    {
                        Edge cheapestEdge = (Edge) cheapestEdges[i];
                        int uRoot = sets.FindSet(cheapestEdge.U);
                        int vRoot = sets.FindSet(cheapestEdge.V);

                        if (uRoot != vRoot)
                        {
                            sets.Union(uRoot, vRoot);
                            --numSets;
                            mst.Add(cheapestEdge);
                        }   
                        cheapestEdges[i] = null;
                    }
                }
            }

            return mst;
        }
    }
}
