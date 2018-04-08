using System;

namespace MST
{
	/// <summary>
	/// This class implements Kruskal MST algorithm.
	/// </summary>
	public class KruskalMST
	{
		/// <summary>
		/// Finds the MST using Kruskal algorithm.
		/// </summary>
		/// <param name="g">The graph.</param>
		public static void FindMST(Graph g)
		{
			// FIXME: missing implementation

			Edge[] mst = new Edge[g.V.Length - 1];

			foreach (var v in g.V)
			{
				v.MakeSet ();
			}

			Array.Sort (g.E);

			foreach (var e in g.E)
			{
				Console.WriteLine ("dfdf");
			}
		}
	}
}

