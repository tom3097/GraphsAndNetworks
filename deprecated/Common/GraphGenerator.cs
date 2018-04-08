using System;
using System.Collections.Generic;

namespace Common
{
    public static class GraphGenerator
    {
        private static Random random = new Random();
        
        public static Graph GenerateSparse(int nodeNumber)
        {
            if (nodeNumber < 2)
            {
                throw new ArgumentException("nodeNumber cannot be lower than 2.");
            }

            double?[,] edgeMatrix = CreateConnectedGraph(nodeNumber);

            int edgesToAdd = AdditionalSparseGraphEdgeNumber(nodeNumber);
            for (int i = 0; i < edgesToAdd; ++i)
            {
                int u, v;
                do
                {
                    u = random.Next(0, nodeNumber);
                    v = random.Next(0, nodeNumber);
                } while (u == v || edgeMatrix[u, v] != null);

                double weight = random.NextDouble();
                edgeMatrix[u, v] = edgeMatrix[v, u] = weight;
            }

            return new Graph(edgeMatrix);
        }

        public static Graph GenerateDense(int nodeNumber)
        {
            if (nodeNumber < 2)
            {
                throw new ArgumentException("nodeNumber cannot be lower than 2.");
            }

            double?[,] edgeMatrix = CreateConnectedGraph(nodeNumber);
            int edgesToAdd = AdditionalDenseGraphEdgeNumber(nodeNumber);
            List<ValueTuple<int, int>> allPossibleEdges = GetAllRemainingEdges(edgeMatrix);
            allPossibleEdges.Shuffle();
            for (int i = 0; i < edgesToAdd; ++i)
            {
                int u = allPossibleEdges[i].Item1;
                int v = allPossibleEdges[i].Item2;
                double weight = random.NextDouble();
                edgeMatrix[u, v] = edgeMatrix[v, u] = weight;
            }

            return new Graph(edgeMatrix);
        }

        private static double?[,] CreateConnectedGraph(int nodeNumber)
        {
            double?[,] edgeMatrix = new double?[nodeNumber, nodeNumber];
            for (int i = 1; i < nodeNumber; ++i)
            {
                int connectedNode = random.Next(0, i);
                double weight = random.NextDouble();
                edgeMatrix[connectedNode, i] = edgeMatrix[i, connectedNode] = weight;
            }

            return edgeMatrix;
        }

        private static List<ValueTuple<int, int>> GetAllRemainingEdges(double?[,] edgeMatrix)
        {
            int nodeNumber = edgeMatrix.GetLength(0);
            int remainingEdgesCount = nodeNumber * (nodeNumber - 1) / 2 - (nodeNumber - 1);
            var remainingEdges = new List<ValueTuple<int, int>>(remainingEdgesCount);
            for (int i = 0; i < nodeNumber; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (edgeMatrix[i, j] == null)
                    {
                        remainingEdges.Add(new ValueTuple<int, int>(i, j));
                    }
                }
            }

            return remainingEdges;
        }

        private static int AdditionalSparseGraphEdgeNumber(int nodeNumber)
        {
            int minimum = nodeNumber - 1;
            return random.Next(0, (int) (0.1 * minimum));
        }
        
        private static int AdditionalDenseGraphEdgeNumber(int nodeNumber)
        {
            int maksimum = nodeNumber * (nodeNumber - 1) / 2;
            int currentEdges = nodeNumber - 1;
            return random.Next(maksimum - currentEdges - (int) (0.1 * maksimum), maksimum - currentEdges + 1);
        }
        
        // https://stackoverflow.com/a/22668974
        private static void Shuffle<T>(this IList<T> list)
        {
            for(var i=0; i < list.Count; i++)
                list.Swap(i, random.Next(i, list.Count));
        }

        private static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}