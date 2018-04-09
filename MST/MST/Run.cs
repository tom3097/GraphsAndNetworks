using System;
using MST;

public class Run
{
	public static void Main ()
	{
		Console.WriteLine ("JOL MADAFAKA");

		Graph g1 = new Graph ();
		g1.GenerateDense (1000);
		Graph g2 = g1.DeepClone<Graph> ();

		DateTime startBoruvka = DateTime.Now;
		Edge[] boruvkaMST = BoruvkaMST.FindMST (g1);
		DateTime endBoruvka = DateTime.Now;

		DateTime startKruskal = DateTime.Now;
		Edge[] kruskalMST = KruskalMST.FindMST (g2);
		DateTime endKruskal = DateTime.Now;

		Console.WriteLine ("Boruvka MST:");
		Array.Sort (boruvkaMST);
		for (int i = 0; i < boruvkaMST.Length; ++i)
		{
			Console.WriteLine (boruvkaMST [i].ToString ());
		}

		Console.WriteLine ("Kruska MST:");
		Array.Sort (kruskalMST);
		for (int i = 0; i < kruskalMST.Length; ++i)
		{
			Console.WriteLine (kruskalMST [i].ToString ());
		}

		TimeSpan boruvkaDiff = endBoruvka - startBoruvka;
		TimeSpan kruskalDiff = endKruskal - startKruskal;

		Console.WriteLine ("Boruvka, czas pracy: " + boruvkaDiff.TotalMilliseconds);
		Console.WriteLine ("Kruskal, czas pracy: " + kruskalDiff.TotalMilliseconds);
	}
}
