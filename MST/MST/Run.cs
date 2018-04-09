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
		Console.WriteLine("JOL MADAFAKA");

		Graph g1 = new Graph();
		g1.GenerateDense(1000);
		Graph g2 = g1.DeepClone<Graph>();

		DateTime startBoruvka = DateTime.Now;
		Edge[] boruvkaMST = BoruvkaMST.FindMST(g1);
		DateTime endBoruvka = DateTime.Now;

		DateTime startKruskal = DateTime.Now;
		Edge[] kruskalMST = KruskalMST.FindMST(g2);
		DateTime endKruskal = DateTime.Now;

		Console.WriteLine("Boruvka MST:");
		Array.Sort(boruvkaMST);
		for (int i = 0; i < boruvkaMST.Length; ++i)
		{
			Console.WriteLine(boruvkaMST[i].ToString());
		}

		Console.WriteLine("Kruska MST:");
		Array.Sort(kruskalMST);
		for (int i = 0; i < kruskalMST.Length; ++i)
		{
			Console.WriteLine(kruskalMST[i].ToString());
		}

		TimeSpan boruvkaDiff = endBoruvka - startBoruvka;
		TimeSpan kruskalDiff = endKruskal - startKruskal;

		Console.WriteLine("Boruvka, czas pracy: " + boruvkaDiff.TotalMilliseconds);
		Console.WriteLine("Kruskal, czas pracy: " + kruskalDiff.TotalMilliseconds);

		var sparseGraph = new Graph();
		sparseGraph.GenerateSparse(1000);
		DummyCorrectnessTests(sparseGraph);
		var denseGraph = new Graph();
		denseGraph.GenerateDense(1000);
		DummyCorrectnessTests(denseGraph);
		Console.WriteLine("Testy przeszły!");
		Console.ReadKey();
	}

	private static void DummyCorrectnessTests(Graph customGraph)
	{
		var quickGraph = new UndirectedGraph<Vertex, WeightedEdge<Vertex>>();
		var edges = customGraph.E
			.Select(e => new WeightedEdge<Vertex>(e.U, e.V, e.W))
			.ToList();

		quickGraph.AddVertexRange(customGraph.V);
		quickGraph.AddEdgeRange(edges);

		var customBoruvkaMst = BoruvkaMST.FindMST(customGraph);
		var customKruskalMst = KruskalMST.FindMST(customGraph);
		var quickGraphMst = quickGraph.MinimumSpanningTreeKruskal<Vertex, WeightedEdge<Vertex>>(e => e.Weight);

		if (!(customBoruvkaMst.Length == customKruskalMst.Length && 
			customKruskalMst.Length == quickGraphMst.Count()))
		{
			throw new Exception("Something wrong with the number of edges.");
		}

		var boruvkaWeight = customBoruvkaMst.Select(e => new BigInteger(e.W)).Aggregate(BigInteger.Add);
		var kruskalWeight = customKruskalMst.Select(e => new BigInteger(e.W)).Aggregate(BigInteger.Add);
		var quickGraphWeight = quickGraphMst.Select(e => new BigInteger(e.Weight)).Aggregate(BigInteger.Add);

		if (!(boruvkaWeight == kruskalWeight &&
			kruskalWeight == quickGraphWeight))
		{
			throw new Exception("Something wrong with MST weight.");
		}
	}

	internal class WeightedEdge<Vertex> : IUndirectedEdge<Vertex>
	{
		public Vertex Source { get; }

		public Vertex Target { get; }

		public int Weight { get; }

		public WeightedEdge(Vertex source, Vertex target, int weight)
		{
			Source = source;
			Target = target;
			Weight = weight;
		}
	}
}
