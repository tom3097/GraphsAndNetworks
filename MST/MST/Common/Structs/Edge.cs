using System;

namespace MST
{
	/// <summary>
	/// This class represents an Edge.
	/// </summary>
	public class Edge : IComparable<Edge>
	{
		#region properties

		/// <summary>
		/// The first vertex.
		/// </summary>
		/// <value>The u.</value>
		public Vertex U { private set; get; }

		/// <summary>
		/// The second vertex.
		/// </summary>
		/// <value>The v.</value>
		public Vertex V { private set; get; }

		/// <summary>
		/// The weight of the edge.
		/// </summary>
		/// <value>The w.</value>
		public int W { private set; get; }

		#endregion

		#region methods

		/// <summary>
		/// Initializes a new instance of the <see cref="MST.Edge"/> class.
		/// </summary>
		/// <param name="u">First vertex.</param>
		/// <param name="v">Second vertex.</param>
		/// <param name="w">Weight of the edge.</param>
		public Edge (Vertex u, Vertex v, int w)
		{
			U = u;
			V = v;
			W = w;
		}

		public int CompareTo(Edge other)
		{
			return W.CompareTo (other.W);
		}

		#endregion
	}
}
