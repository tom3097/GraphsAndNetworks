using System;

namespace MST
{
	/// <summary>
	/// This class represents a vertex. It also contains some additional
	/// information which allows to implement disjoint set operations.
	/// </summary>
	public class Vertex
	{
		#region fields

		/// <summary>
		/// The identifier.
		/// </summary>
		private int _id;

		#endregion

		#region properties

		/// <summary>
		/// The rank of the vertex.
		/// </summary>
		/// <value>The rank.</value>
		public int Rank { set; get; }

		/// <summary>
		/// The parent of the vertex.
		/// </summary>
		/// <value>The parent.</value>
		public Vertex Parent { get; set; }

		#endregion

		#region methods

		/// <summary>
		/// Initializes a new instance of the <see cref="MST.Vertex"/> class.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public Vertex (int id)
		{
			id = id;
			Rank = 0;
			Parent = this;
		}

		#endregion
	}
}
