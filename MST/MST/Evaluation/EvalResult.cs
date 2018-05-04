using System;

namespace MST
{
	/// <summary>
	/// This class represents an evaluation result.
	/// </summary>
	public class EvalResult
	{
		#region properties

		/// <summary>
		/// The number of samples.
		/// </summary>
		/// <value>The runs no.</value>
		public int RunsNo { private set; get; }

		/// <summary>
		/// The number of vertexes in graph.
		/// </summary>
		/// <value>The V no.</value>
		public int VNo { private set; get; }

		/// <summary>
		/// Average time for Boruvka MST for sparse graphs.
		/// </summary>
		/// <value>The sparse boruvka avg time.</value>
		public TimeSpan SparseBoruvkaAvgTime { private set; get; }

		/// <summary>
		/// Average time for Kruskal MST for sparse graphs.
		/// </summary>
		/// <value>The sparse kruskal avg time.</value>
		public TimeSpan SparseKruskalAvgTime { private set; get; }

		/// <summary>
		/// Average time for Boruvka MST for dense graphs.
		/// </summary>
		/// <value>The dense boruvka avg time.</value>
		public TimeSpan DenseBoruvkaAvgTime { private set; get; }

		/// <summary>
		/// Average time for Kruskal MST for dense graphs.
		/// </summary>
		/// <value>The dense kruskal avg time.</value>
		public TimeSpan DenseKruskalAvgTime { private set; get; }

		#endregion

		#region methods

		/// <summary>
		/// Initializes a new instance of the <see cref="MST.EvalResult"/> class.
		/// </summary>
		/// <param name="runsNo">The number of samples.</param>
		/// <param name="vNo">The number of vertexes in graph.</param>
		/// <param name="sbat">Average time for Boruvka MST for sparse graphs.</param>
		/// <param name="skat">Average time for Kruskal MST for sparse graphs.</param>
		/// <param name="dbat">Average time for Boruvka MST for dense graphs.</param>
		/// <param name="dkat">Average time for Kruskal MST for dense graphs.</param>
		public EvalResult (int runsNo, int vNo, TimeSpan sbat, TimeSpan skat,
			TimeSpan dbat, TimeSpan dkat)
		{
			RunsNo = runsNo;
			VNo = vNo;
			SparseBoruvkaAvgTime = sbat;
			SparseKruskalAvgTime = skat;
			DenseBoruvkaAvgTime = dbat;
			DenseKruskalAvgTime = dkat;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="MST.EvalResult"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="MST.EvalResult"/>.</returns>
		public override string ToString ()
		{
			return string.Format ("[EvalResult:\nRunsNo={0},\nVNo={1},\nSparseBoruvkaAvgTime={2}," +
				"\nSparseKruskalAvgTime={3},\nDenseBoruvkaAvgTime={4},\nDenseKruskalAvgTime={5}]", RunsNo, VNo,
				SparseBoruvkaAvgTime.TotalMilliseconds, SparseKruskalAvgTime.TotalMilliseconds,
				DenseBoruvkaAvgTime.TotalMilliseconds, DenseKruskalAvgTime.TotalMilliseconds);
		}

		#endregion
	}
}
	