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
			_id = id;
			Rank = 0;
			Parent = this;
		}

		public static bool operator ==(Vertex v1, Vertex v2)
		{
			return v1._id == v2._id;
		}

		public static bool operator !=(Vertex v1, Vertex v2)
		{
			return v1._id != v2._id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType () != obj.GetType ())
			{
				return false;
			}

			Vertex v = (Vertex)obj;
			return _id.Equals (v._id);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		#endregion
	}
}
