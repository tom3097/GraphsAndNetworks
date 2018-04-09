using System;
using System.Linq;

namespace MST
{
	public class Evaluator
	{
		private readonly int _runs;

		public Evaluator (int runs)
		{
			_runs = runs;
		}

		public EvaluationResults DenseGraphEvaluation (int graphSize)
		{
			return Evaluation (graphSize, GraphGenerator.GenerateDense);
		}

		public EvaluationResults SparseGraphEvaluation (int graphSize)
		{
			return Evaluation (graphSize, GraphGenerator.GenerateSparse);
		}

		private EvaluationResults Evaluation (int graphSize, Action<Graph, int> generationMethod)
		{
			var boruvkaResults = new TimeSpan[_runs];
			var kruskalResults = new TimeSpan[_runs];

			for (var i = 0; i < _runs; ++i)
			{
				var graph = new Graph ();
				generationMethod (graph, graphSize);
				var graphCopy = graph.DeepClone ();

				var startBoruvka = DateTime.Now;
				BoruvkaMST.FindMST (graph);
				var endBoruvka = DateTime.Now;

				var startKruskal = DateTime.Now;
				KruskalMST.FindMST (graphCopy);
				var endKruskal = DateTime.Now;

				boruvkaResults[i] = endBoruvka - startBoruvka;
				kruskalResults[i] = endKruskal - startKruskal;
			}

			var boruvkaAverage = new TimeSpan ((long) boruvkaResults.Select (span => span.Ticks).Average ());
			var kruskalAverage = new TimeSpan ((long) kruskalResults.Select (span => span.Ticks).Average ());

			return new EvaluationResults (boruvkaAverage, kruskalAverage);
		}

		public class EvaluationResults
		{
			public EvaluationResults (TimeSpan boruvkaAverageTime, TimeSpan kruskalAverageTime)
			{
				BoruvkaAverageTime = boruvkaAverageTime;
				KruskalAverageTime = kruskalAverageTime;
			}

			public TimeSpan BoruvkaAverageTime { get; }
			public TimeSpan KruskalAverageTime { get; }
		}
	}
}