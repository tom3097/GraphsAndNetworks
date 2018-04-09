using System;

namespace MST
{
	/// <summary>
	/// This class represents an Edge.
	/// </summary>
	[Serializable]
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

		/// <Docs>To be added.</Docs>
		/// <para>Returns the sort order of the current instance compared to
		/// the specified object.</para>
		/// <summary>
		/// Compares to.
		/// </summary>
		/// <returns>The to.</returns>
		/// <param name="other">Other.</param>
		public int CompareTo(Edge other)
		{
			return W.CompareTo (other.W);
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the
		/// current <see cref="MST.Edge"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the
		/// current <see cref="MST.Edge"/>.</returns>
		public override string ToString ()
		{
			return string.Format ("[Edge: U={0}, V={1}, W={2}]", U.Id, V.Id, W);
		}

		#endregion
	}
}
