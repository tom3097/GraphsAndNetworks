using System;
using QuickGraph;

namespace MST
{
	/// <summary>
	/// This class represents a weighted edge used by QuickGraph package.
	/// </summary>
	class WeightedEdge<TVertex> : IUndirectedEdge<TVertex>
	{
		#region properties

		/// <summary>
		/// The source vertex.
		/// </summary>
		/// <value>The source.</value>
		public TVertex Source { private set; get; }

		/// <summary>
		/// The target vertex.
		/// </summary>
		/// <value>The target.</value>
		public TVertex Target { private set; get; }

		/// <summary>
		/// The weight of the edge.
		/// </summary>
		/// <value>The weight.</value>
		public int Weight { private set; get; }

		#endregion

		#region methods

		/// <summary>
		/// Initializes a new instance of the <see cref="MST.WeightedEdge`1"/> class.
		/// </summary>
		/// <param name="source">The source vertex.</param>
		/// <param name="target">The target vertex.</param>
		/// <param name="weight">The weight of the edge.</param>
		public WeightedEdge (TVertex source, TVertex target, int weight)
		{
			Source = source;
			Target = target;
			Weight = weight;
		}

		#endregion
	}
}
