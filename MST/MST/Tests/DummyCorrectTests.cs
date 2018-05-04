using System;
using System.Linq;
using System.Numerics;
using QuickGraph;
using QuickGraph.Algorithms;

namespace MST
{
	/// <summary>
	/// This class allowes to perform dummy corectness tests.
	/// </summary>
	static class DummyCorrectTests
	{
		#region methods

		/// <summary>
		/// Test the specified graph.
		/// </summary>
		/// <param name="graph">Graph to be tested.</param>
		public static void Test(Graph graph)
		{
			var graph_2 = (Graph)graph.Clone ();

			var edges = graph.E
				.Select (e => new WeightedEdge<Vertex> (e.U, e.V, e.W))
				.ToList ();
			
			var quickGraph = new UndirectedGraph<Vertex, WeightedEdge<Vertex>> ();
			quickGraph.AddVertexRange (graph.V);
			quickGraph.AddEdgeRange (edges);

			var customBoruvkaMst = BoruvkaMST.FindMST (graph);
			var customKruskalMst = KruskalMST.FindMST (graph_2);
			var quickGraphMst = quickGraph.MinimumSpanningTreeKruskal (e => e.Weight);

			if (!(customBoruvkaMst.Length == customKruskalMst.Length &&
			    customKruskalMst.Length == quickGraphMst.Count ()))
			{
				throw new Exception ("Something wrong with the number of edges.");
			}

			var boruvkaWeight = customBoruvkaMst.Select (e => new BigInteger (e.W)).Aggregate (BigInteger.Add);
			var kruskalWeight = customKruskalMst.Select (e => new BigInteger (e.W)).Aggregate (BigInteger.Add);
			var quickGraphWeight = quickGraphMst.Select (e => new BigInteger (e.Weight)).Aggregate (BigInteger.Add);

			if (!(boruvkaWeight == kruskalWeight &&
			    kruskalWeight == quickGraphWeight))
			{
				throw new Exception ("Something wrong with MST weight.");
			}
		}

		#endregion
	}
}
