using System;
using System.Linq;

namespace MST
{
	/// <summary>
	/// This class represents an evaluator.
	/// </summary>
	static class Evaluator
	{
		#region methods

		/// <summary>
		/// Performs evaluation.
		/// </summary>
		/// <param name="runsNo">The number of samples.</param>
		/// <param name="vNo">The number of vertexes in graph.</param>
		public static EvalResult Eval(int runsNo, int vNo)
		{
			var boruvkaSparseTimes = new TimeSpan[runsNo];
			var kruskalSparseTimes = new TimeSpan[runsNo];
			var boruvkaDenseTimes = new TimeSpan[runsNo];
			var kruskalDenseTimes = new TimeSpan[runsNo];

			for (int i = 0; i < runsNo; ++i)
			{
				Graph sparseGraph_1 = new Graph ();
				sparseGraph_1.GenerateSparse (vNo);
				Graph sparseGraph_2 = (Graph)sparseGraph_1.Clone ();

				GC.Collect ();
				GC.WaitForPendingFinalizers ();
				var startBoruvka = DateTime.Now;
				BoruvkaMST.FindMST (sparseGraph_1);
				var endBoruvka = DateTime.Now;

				GC.Collect ();
				GC.WaitForPendingFinalizers ();
				var startKruskal = DateTime.Now;
				KruskalMST.FindMST (sparseGraph_2);
				var endKruskal = DateTime.Now;

				boruvkaSparseTimes[i] = endBoruvka - startBoruvka;
				kruskalSparseTimes[i] = endKruskal - startKruskal;
			}

			for (int i = 0; i < runsNo; ++i)
			{
				Graph denseGraph_1 = new Graph ();
				denseGraph_1.GenerateDense (vNo);
				Graph denseGraph_2 = (Graph)denseGraph_1.Clone ();

				var startBoruvka = DateTime.Now;
				BoruvkaMST.FindMST (denseGraph_1);
				var endBoruvka = DateTime.Now;

				var startKruskal = DateTime.Now;
				KruskalMST.FindMST (denseGraph_2);
				var endKruskal = DateTime.Now;

				boruvkaDenseTimes[i] = endBoruvka - startBoruvka;
				kruskalDenseTimes[i] = endKruskal - startKruskal;
			}

			var boruvkaSparseAverage = new TimeSpan ((long) boruvkaSparseTimes.Select
				(span => span.Ticks).Average ());
			var kruskalSparseAverage = new TimeSpan ((long) kruskalSparseTimes.Select
				(span => span.Ticks).Average ());
			var boruvkaDenseAverage = new TimeSpan ((long) boruvkaDenseTimes.Select
				(span => span.Ticks).Average ());
			var kruskalDenseAverage = new TimeSpan ((long) kruskalDenseTimes.Select
				(span => span.Ticks).Average ());

			return new EvalResult (runsNo, vNo, boruvkaSparseAverage, kruskalSparseAverage,
				boruvkaDenseAverage, kruskalDenseAverage);
		}

		#endregion
	}
}
