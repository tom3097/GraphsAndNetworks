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
		private enum GraphType
		{
			SPARSE,
			DENSE
		};

		#region fields

		/// <summary>
		/// An instance of Random class.
		/// </summary>
		private static readonly Random _random;

		/// <summary>
		/// The max value of a weight.
		/// </summary>
		private const int maxW = Int32.MaxValue;
	
		#endregion

		#region methods

		/// <summary>
		/// Initializes the <see cref="MST.GraphGenerator"/> class.
		/// </summary>
		static GraphGenerator()
		{
			_random = new Random ();
		}

		/// <summary>
		/// Generates the sparse graph.
		/// </summary>
		/// <param name="g">The graph.</param>
		/// <param name="vertexNo">The number of vertexes in graph.</param>
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
		/// <param name="vertexNo">The number of vertexes in graph.</param>
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

		/// <summary>
		/// Creates the connected graph.
		/// </summary>
		/// <returns>The connected graph.</returns>
		/// <param name="vertexNo">The number of vertexes in graph.</param>
		private static int?[,] CreateConnectedGraph(int vertexNo)
		{
			int?[,] adjacencyMatrix = new int?[vertexNo, vertexNo];

			for (int i = 1; i < vertexNo; ++i)
			{
				int vertex = _random.Next (0, i);
				int weight = _random.Next (maxW);
				adjacencyMatrix [vertex, i] = adjacencyMatrix [i, vertex] = weight;
			}

			return adjacencyMatrix;
		}

		/// <summary>
		/// Gets the number of additional edges for sparse graph.
		/// </summary>
		/// <returns>The number of additional edges for sparse graph.</returns>
		/// <param name="vertexNo">The number of vertexes in graph.</param>
		private static int GetSparseAdditionalEdgeNo(int vertexNo)
		{
			int minEdges = vertexNo - 1;
			return _random.Next (0, (int)(0.1 * minEdges) + 1);
		}

		/// <summary>
		/// Gets the number of additional edges for dense graph.
		/// </summary>
		/// <returns>The number of additional edges for dense graph.</returns>
		/// <param name="vertexNo">The number of vertexes in graph.</param>
		private static int GetDenseAdditionalEdgeNo(int vertexNo)
		{
			int minEdges = vertexNo - 1;
			int maxEdges = vertexNo * (vertexNo - 1) / 2;
			return _random.Next (maxEdges - minEdges - (int)(0.1 * maxEdges) + 1,
				maxEdges - minEdges + 1);
		}

		/// <summary>
		/// Gets remaining edges for given graph.
		/// </summary>
		/// <returns>The remaining edges.</returns>
		/// <param name="adjacencyMatrix">Adjacency matrix.</param>
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

		/// <summary>
		/// Adds additional edges for given graph.
		/// </summary>
		/// <returns>Total number of edges in graph.</returns>
		/// <param name="adjacencyMatrix">Adjacency matrix.</param>
		/// <param name="type">Graph type.</param>
		private static int AddAdditionalEdges(ref int?[,] adjacencyMatrix, GraphType type)
		{
			int vertexNo = adjacencyMatrix.GetLength (0);
			int additionalEdgeNo = type == GraphType.SPARSE ? GetSparseAdditionalEdgeNo (vertexNo) :
				GetDenseAdditionalEdgeNo (vertexNo);

			Tuple<int, int>[] edges = GetRemainingEdges (adjacencyMatrix);
			edges = edges.OrderBy (e => _random.Next ()).ToArray ();

			for (int i = 0; i < additionalEdgeNo; ++i)
			{
				int u = edges [i].Item1;
				int v = edges [i].Item2;
				int weight = _random.Next (maxW);
				adjacencyMatrix [u, v] = adjacencyMatrix [v, u] = weight;
			}

			return vertexNo - 1 + additionalEdgeNo;
		}

		/// <summary>
		/// Transforms adjacency matrix graph representation into V, E representation.
		/// </summary>
		/// <returns>The (V,E) tuple.</returns>
		/// <param name="adjacencyMatrix">Adjacency matrix.</param>
		/// <param name="edgeNo">The number of edges in the graph.</param>
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
						E [edgeIdx++] = new Edge (V [i], V [j], adjacencyMatrix [i, j]
							.GetValueOrDefault());
					}
				}
			}

			return Tuple.Create (V, E);
		}

		#endregion
	}
}
