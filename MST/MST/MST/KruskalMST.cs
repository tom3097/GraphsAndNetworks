using System;

namespace MST
{
	/// <summary>
	/// This class implements Kruskal MST algorithm.
	/// </summary>
	static class KruskalMST
	{
		#region methods

		/// <summary>
		/// Finds the MST using Kruskal algorithm.
		/// </summary>
		/// <param name="g">The graph.</param>
		public static Edge[] FindMST(Graph g)
		{
			Edge[] mst = new Edge[g.V.Length - 1];
			int mstIdx = 0;

			foreach (var v in g.V)
			{
				v.MakeSet ();
			}

			Array.Sort (g.E);

			foreach (var e in g.E)
			{
				if (e.U.FindSet () != e.V.FindSet ())
				{
					mst [mstIdx++] = e;
					e.U.Union (e.V);
				}
			}

			return mst;
		}

		#endregion
	}
}
