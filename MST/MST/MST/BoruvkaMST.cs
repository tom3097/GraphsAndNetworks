namespace MST
{
	/// <summary>
	/// This class implements Boruvka MST algorithm.
	/// </summary>
	static class BoruvkaMST
	{
		#region methods

		/// <summary>
		/// Finds the MST using Boruvka algorithm.
		/// </summary>
		/// <param name="g">The graph.</param>
		public static Edge[] FindMST(Graph g)
		{
			Edge[] mst = new Edge[g.V.Length - 1];
			Edge[] cheapestEdges = new Edge[g.V.Length];

			foreach (var v in g.V)
			{
				v.MakeSet();
			}

			int setsNo = g.V.Length;
			while (setsNo > 1)
			{
				foreach (var e in g.E)
				{
					var uRoot = e.U.FindSet();
					var vRoot = e.V.FindSet();

					if (uRoot != vRoot)
					{
						if (cheapestEdges[uRoot.Id] == null || cheapestEdges[uRoot.Id].W > e.W)
						{
							cheapestEdges[uRoot.Id] = e;
						}

						if (cheapestEdges[vRoot.Id] == null || cheapestEdges[vRoot.Id].W > e.W)
						{
							cheapestEdges[vRoot.Id] = e;
						}
					}
				}

				for (int i = 0; i < g.V.Length; ++i)
				{
					if (cheapestEdges[i] != null)
					{
						var e = cheapestEdges [i];

						if (e.U.FindSet() != e.V.FindSet())
						{
							mst[--setsNo - 1] = cheapestEdges[i];
							e.U.Union(e.V);
						}   
						cheapestEdges[i] = null;
					}
				}
			}

			return mst;
		}

		#endregion
	}
}
