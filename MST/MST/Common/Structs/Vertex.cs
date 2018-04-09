using System;

namespace MST
{
	/// <summary>
	/// This class represents a vertex. It also contains some additional
	/// information which allows to implement disjoint set operations.
	/// </summary>
	[Serializable]
	public class Vertex
	{
		#region properties

		/// <summary>
		/// The identifier.
		/// </summary>
		public int Id { private set; get; }

		/// <summary>
		/// The rank of the vertex.
		/// </summary>
		/// <value>The rank.</value>
		public int Rank { set; get; }

		/// <summary>
		/// The parent of the vertex.
		/// </summary>
		/// <value>The parent.</value>
		public Vertex Parent { set; get; }

		#endregion

		#region methods

		/// <summary>
		/// Initializes a new instance of the <see cref="MST.Vertex"/> class.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public Vertex (int id)
		{
			Id = id;
			Rank = 0;
			Parent = this;
		}

		/// <param name="v1">V1.</param>
		/// <param name="v2">V2.</param>
		public static bool operator ==(Vertex v1, Vertex v2)
		{
			return v1.Id == v2.Id;
		}

		/// <param name="v1">V1.</param>
		/// <param name="v2">V2.</param>
		public static bool operator !=(Vertex v1, Vertex v2)
		{
			return v1.Id != v2.Id;
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is
		/// equal to the current <see cref="MST.Vertex"/>.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with
		/// the current <see cref="MST.Vertex"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/>
		/// is equal to the current <see cref="MST.Vertex"/>;
		/// otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			if (obj == null || GetType () != obj.GetType ())
			{
				return false;
			}

			Vertex v = (Vertex)obj;
			return Id.Equals (v.Id);
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="MST.Vertex"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing
		/// algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

		#endregion
	}
}
