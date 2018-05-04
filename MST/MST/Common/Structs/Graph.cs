using System;

namespace MST
{
	/// <summary>
	/// This class represents a graph.
	/// </summary>
	public class Graph: ICloneable
	{
		#region properties

		/// <summary>
		/// A collection of vertexes.
		/// </summary>
		/// <value>The v.</value>
		public Vertex[] V { set; get; }

		/// <summary>
		/// A collection of edges.
		/// </summary>
		/// <value>The e.</value>
		public Edge[] E { set; get; }

		#endregion

		#region methods

		/// <summary>
		/// Initializes a new instance of the <see cref="MST.Graph"/> class.
		/// </summary>
		public Graph ()
		{
			V = null;
			E = null;
		}

		/// <summary>
		/// Clone this instance.
		/// </summary>
		public object Clone()
		{
			Graph graph = new Graph ();
			graph.V = new Vertex[this.V.Length];

			for (int i = 0; i < this.V.Length; ++i)
			{
				graph.V [i] = new Vertex (i);
			}

			for (int i = 0; i < this.V.Length; ++i)
			{
				graph.V [i].Rank = this.V [i].Rank;
				graph.V [i].Parent = graph.V [this.V [i].Parent.Id];
			}

			graph.E = new Edge[this.E.Length];

			for (int i = 0; i < this.E.Length; ++i)
			{
				Vertex u = graph.V [this.E [i].U.Id];
				Vertex v = graph.V [this.E [i].V.Id];

				graph.E [i] = new Edge (u, v, this.E [i].W);
			}

			return graph;
		}

		#endregion
	}
}
