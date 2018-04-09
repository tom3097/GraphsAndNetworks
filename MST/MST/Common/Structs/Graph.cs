using System;

namespace MST
{
	/// <summary>
	/// This class represents a graph.
	/// </summary>
	[Serializable]
	public class Graph
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

		#endregion
	}
}
