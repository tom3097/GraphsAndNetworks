using System;
using System.Diagnostics;
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

			Stopwatch stopWatch = Stopwatch.StartNew();
			for (int i = 0; i < runsNo; ++i)
			{
				Graph sparseGraph_1 = new Graph ();
				sparseGraph_1.GenerateSparse (vNo);
				Graph sparseGraph_2 = (Graph)sparseGraph_1.Clone ();

				GC.Collect ();
				GC.WaitForPendingFinalizers ();
				stopWatch.Start();
				BoruvkaMST.FindMST (sparseGraph_1);
				stopWatch.Stop();
				
				boruvkaSparseTimes[i] = stopWatch.Elapsed;
				stopWatch.Reset();	
				
				GC.Collect ();
				GC.WaitForPendingFinalizers ();
				stopWatch.Start();
				KruskalMST.FindMST (sparseGraph_2);
				stopWatch.Stop();
				
				kruskalSparseTimes[i] = stopWatch.Elapsed;
				stopWatch.Reset();
			}

			for (int i = 0; i < runsNo; ++i)
			{
				Graph denseGraph_1 = new Graph ();
				denseGraph_1.GenerateDense (vNo);
				Graph denseGraph_2 = (Graph)denseGraph_1.Clone ();

				GC.Collect ();
				GC.WaitForPendingFinalizers ();
				stopWatch.Start();
				BoruvkaMST.FindMST (denseGraph_1);
				stopWatch.Stop();
				
				boruvkaDenseTimes[i] = stopWatch.Elapsed;
				stopWatch.Reset();
				
				GC.Collect ();
				GC.WaitForPendingFinalizers ();
				stopWatch.Start();
				KruskalMST.FindMST (denseGraph_2);
				stopWatch.Stop();

				kruskalDenseTimes[i] = stopWatch.Elapsed;
				stopWatch.Reset();
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
