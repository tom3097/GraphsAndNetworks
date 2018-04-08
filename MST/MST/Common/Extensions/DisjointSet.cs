using System;

namespace MST
{
	/// <summary>
	/// Disjoint set extension class for Vertex.
	/// </summary>
	static class DisjointSet
	{
		#region methods

		/// <summary>
		/// Makes the set.
		/// </summary>
		/// <param name="v">The vertex.</param>
		public static void MakeSet(this Vertex v)
		{
			v.Parent = v;
			v.Rank = 0;
		}

		/// <summary>
		/// Finds the set's representative.
		/// </summary>
		/// <returns>The set's representative.</returns>
		/// <param name="v">The vertex.</param>
		public static Vertex FindSet(this Vertex v)
		{
			if (v != v.Parent)
			{
				v.Parent = v.Parent.FindSet ();
			}

			return v.Parent;
		}

		/// <summary>
		/// Link the specified v1 set and v2 set.
		/// </summary>
		/// <param name="v1">The v1 set.</param>
		/// <param name="v2">The v2 set.</param>
		private static void Link(this Vertex v1, Vertex v2)
		{
			if (v1.Rank > v2.Rank)
			{
				v2.Parent = v1;
			}
			else
			{
				v1.Parent = v2;
				if (v1.Rank == v2.Rank)
				{
					v2.Rank = v2.Rank + 1;
				}
			}
		}

		/// <summary>
		/// Union the specified v1 set and v2 set.
		/// </summary>
		/// <param name="v1">The v1 set.</param>
		/// <param name="v2">The v2 set.</param>
		public static void Union(this Vertex v1, Vertex v2)
		{
			Link (v1.FindSet (), v2.FindSet ());
		}

		#endregion
	}
}
