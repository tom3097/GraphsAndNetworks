using System;
using System.Collections.Generic;
using System.Linq;

namespace MST
{
	/// <summary>
	/// Graph generator extension class for graph.
	/// </summary>
	static class GraphGenerator
	{
		#region fields

		private static readonly Random random;

		private const int MAX_W = Int32.MaxValue;

		public enum GraphType
		{
			SPARSE,
			DENSE
		};

		#endregion

		#region methods

		static GraphGenerator()
		{
			random = new Random ();
		}

		/// <summary>
		/// Generates the sparse graph.
		/// </summary>
		/// <param name="g">The graph.</param>
		public static void GenerateSparse(this Graph g, int vertexNo)
		{
			if (vertexNo < 2)
			{
				throw new ArgumentException ("vertexNo cannot be lower than 2.");
			}

			int?[,] adjacencyMatrix = CreateConnectedGraph (vertexNo);
			int edgeNo = AddAdditionalEdges (ref adjacencyMatrix, GraphType.SPARSE);
			Tuple<Vertex[], Edge[]> ve = AdjacencyToGraph (adjacencyMatrix, edgeNo);

			g.V = ve.Item1;
			g.E = ve.Item2;
		}

		/// <summary>
		/// Generates the dense graph.
		/// </summary>
		/// <param name="g">The graph.</param>
		public static void GenerateDense(this Graph g, int vertexNo)
		{
			if (vertexNo < 2)
			{
				throw new ArgumentException ("vertexNo cannot be lower than 2.");
			}

			int?[,] adjacencyMatrix = CreateConnectedGraph (vertexNo);
			int edgeNo = AddAdditionalEdges (ref adjacencyMatrix, GraphType.DENSE);
			Tuple<Vertex[], Edge[]> ve = AdjacencyToGraph (adjacencyMatrix, edgeNo);

			g.V = ve.Item1;
			g.E = ve.Item2;
		}

		private static int?[,] CreateConnectedGraph(int vertexNo)
		{
			int?[,] adjacencyMatrix = new int?[vertexNo, vertexNo];

			for (int i = 1; i < vertexNo; ++i)
			{
				int vertex = random.Next (0, i);
				int weight = random.Next (MAX_W);
				adjacencyMatrix [vertex, i] = adjacencyMatrix [i, vertex] = weight;
			}

			return adjacencyMatrix;
		}

		private static int GetSparseAdditionalEdgeNo(int vertexNo)
		{
			int minEdges = vertexNo - 1;
			return random.Next (0, (int)(0.1 * minEdges) + 1);
		}

		private static int GetDenseAdditionalEdgeNo(int vertexNo)
		{
			int minEdges = vertexNo - 1;
			int maxEdges = vertexNo * (vertexNo - 1) / 2;
			return random.Next (maxEdges - minEdges - (int)(0.1 * maxEdges) + 1, maxEdges - minEdges + 1);
		}

		private static Tuple<int, int>[] GetRemainingEdges(int?[,] adjacencyMatrix)
		{
			int vertexNo = adjacencyMatrix.GetLength (0);
			int remainingEdgeNo = vertexNo * (vertexNo - 1) / 2 - (vertexNo - 1);

			Tuple<int, int>[] edges = new Tuple<int, int>[remainingEdgeNo];
			int edgesIdx = 0;
			for (int i = 0; i < vertexNo; ++i)
			{
				for (int j = 0; j < i; ++j)
				{
					if (adjacencyMatrix [i, j] == null)
					{
						edges [edgesIdx++] = Tuple.Create (i, j);
					}
				}
			}

			return edges;
		}

		private static int AddAdditionalEdges(ref int?[,] adjacencyMatrix, GraphType type)
		{
			int vertexNo = adjacencyMatrix.GetLength (0);
			int additionalEdgeNo = type == GraphType.SPARSE ? GetSparseAdditionalEdgeNo (vertexNo) :
				GetDenseAdditionalEdgeNo (vertexNo);

			Tuple<int, int>[] edges = GetRemainingEdges (adjacencyMatrix);
			edges = edges.OrderBy (e => random.Next ()).ToArray ();

			foreach (var e in edges)
			{
				int weight = random.Next (MAX_W);
				adjacencyMatrix [e.Item1, e.Item2] = adjacencyMatrix [e.Item2, e.Item1] = weight;
			}

			return vertexNo - 1 + additionalEdgeNo;
		}

		private static Tuple<Vertex[], Edge[]> AdjacencyToGraph(int?[,] adjacencyMatrix, int edgeNo)
		{
			int vertexNo = adjacencyMatrix.GetLength (0);

			Vertex[] V = new Vertex[vertexNo];
			Edge[] E = new Edge[edgeNo];
			int edgeIdx = 0;

			for (int i = 0; i < vertexNo; ++i)
			{
				V [i] = new Vertex (i);
			}

			for (int i = 0; i < vertexNo; ++i)
			{
				for (int j = 0; j < i; ++j)
				{
					if (adjacencyMatrix [i, j] != null)
					{
						E [edgeIdx++] = new Edge (V [i], V [j], adjacencyMatrix [i, j].GetValueOrDefault());
					}
				}
			}

			return Tuple.Create (V, E);
		}

		#endregion
	}
}
