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
		/// Sorts an array of edges using QuickSort algorithm.
		/// </summary>
		/// <param name="edges">Array of edges to be sorted.</param>
		private static void QuickSort(Edge[] edges)
		{
			DoQuickSort (edges, 0, edges.Length - 1);
		}

		/// <summary>
		/// Implements QuickSort algorithm logic.
		/// </summary>
		/// <param name="edges">Array of edges to be sorted.</param>
		/// <param name="left">Left index.</param>
		/// <param name="right">Right index.</param>
		private static void DoQuickSort(Edge[] edges, int left, int right)
		{
			int i = left;
			int j = right;
			Edge x;

			x = edges[(left + right) >> 1];
			do
			{
				while (edges[i].CompareTo(x) < 0)
				{
					i++;
				}
				while (edges[j].CompareTo(x) > 0)
				{
					j--;
				}

				if (i <= j)
				{
					Swap(edges, i, j);
					i++;
					j--;
				}
			}
			while (i < j);

			if (left < j)
			{
				DoQuickSort (edges, left, j);
			}
			if (right > i)
			{
				DoQuickSort (edges, i, right);
			}
		}

		/// <summary>
		/// Swaps the specified edges, left and right.
		/// </summary>
		/// <param name="edges">Array of edges to be swaped.</param>
		/// <param name="left">Left index.</param>
		/// <param name="right">Right index.</param>
		private static void Swap(Edge[] edges, int left, int right)
		{
			Edge temp = edges[left];
			edges[left] = edges[right];
			edges[right] = temp;
		}

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

			QuickSort (g.E);

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
