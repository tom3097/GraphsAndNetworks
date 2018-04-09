using System;
using System.Linq;
using System.Numerics;
using MST;
using QuickGraph;
using QuickGraph.Algorithms;

public class Run
{
	public static void Main ()
	{
		var evaluator = new Evaluator (100);

		int[] testSizes = {100, 500, 1000, 5000, 10000};

		foreach (var testSize in testSizes)
		{
			Console.WriteLine ($"Testing {testSize} node sparse graph.");
			var results = evaluator.SparseGraphEvaluation (testSize);
			Console.WriteLine ("Boruvka average time: " + results.BoruvkaAverageTime.TotalMilliseconds);
			Console.WriteLine ("Kruskal average time: " + results.KruskalAverageTime.TotalMilliseconds);

			Console.WriteLine ($"Testing {testSize} node dense graph.");
			results = evaluator.DenseGraphEvaluation (testSize);
			Console.WriteLine ("Boruvka average time: " + results.BoruvkaAverageTime.TotalMilliseconds);
			Console.WriteLine ("Kruskal average time: " + results.KruskalAverageTime.TotalMilliseconds);
		}
	}

	private static void DummyCorrectnessTests (Graph customGraph)
	{
		var quickGraph = new UndirectedGraph<Vertex, WeightedEdge<Vertex>> ();
		var edges = customGraph.E
			.Select (e => new WeightedEdge<Vertex> (e.U, e.V, e.W))
			.ToList ();

		quickGraph.AddVertexRange (customGraph.V);
		quickGraph.AddEdgeRange (edges);

		var customBoruvkaMst = BoruvkaMST.FindMST (customGraph);
		var customKruskalMst = KruskalMST.FindMST (customGraph);
		var quickGraphMst = quickGraph.MinimumSpanningTreeKruskal (e => e.Weight);

		if (!(customBoruvkaMst.Length == customKruskalMst.Length &&
		      customKruskalMst.Length == quickGraphMst.Count ()))
			throw new Exception ("Something wrong with the number of edges.");

		var boruvkaWeight = customBoruvkaMst.Select (e => new BigInteger (e.W)).Aggregate (BigInteger.Add);
		var kruskalWeight = customKruskalMst.Select (e => new BigInteger (e.W)).Aggregate (BigInteger.Add);
		var quickGraphWeight = quickGraphMst.Select (e => new BigInteger (e.Weight)).Aggregate (BigInteger.Add);

		if (!(boruvkaWeight == kruskalWeight &&
		      kruskalWeight == quickGraphWeight))
			throw new Exception ("Something wrong with MST weight.");
	}

	private class WeightedEdge<TVertex> : IUndirectedEdge<TVertex>
	{
		public WeightedEdge (TVertex source, TVertex target, int weight)
		{
			Source = source;
			Target = target;
			Weight = weight;
		}

		public int Weight { get; }
		public TVertex Source { get; }

		public TVertex Target { get; }
	}
}