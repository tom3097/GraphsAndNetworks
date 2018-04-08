namespace MST
{
	/// <summary>
	/// This class implements Boruvka MST algorithm.
	/// </summary>
	public class BoruvkaMST
	{
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

			int numSets = g.V.Length;
			while (numSets > 1)
			{
				foreach (Edge edge in g.E)
				{
					var uRoot = edge.U.FindSet();
					var vRoot = edge.V.FindSet();

					if (uRoot != vRoot)
					{
						if (cheapestEdges[uRoot.ID] == null || cheapestEdges[uRoot.ID].W > edge.W)
						{
							cheapestEdges[uRoot.ID] = edge;
						}

						if (cheapestEdges[vRoot.ID] == null || cheapestEdges[vRoot.ID].W > edge.W)
						{
							cheapestEdges[vRoot.ID] = edge;
						}
					}
				}

				for (int i = 0; i < g.V.Length; ++i)
				{
					if (cheapestEdges[i] != null)
					{
						var uRoot = cheapestEdges[i].U.FindSet();
						var vRoot = cheapestEdges[i].V.FindSet();

						if (uRoot != vRoot)
						{
							uRoot.Union(vRoot);
							--numSets;
							mst[numSets - 1] = cheapestEdges[i];
						}   
						cheapestEdges[i] = null;
					}
				}
			}

			return mst;
		}
	}
}
