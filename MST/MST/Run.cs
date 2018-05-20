using System;
using MST;

public class Run
{
	#region methods

	/// <summary>
	/// The entry point of the program, where the program control starts and ends.
	/// </summary>
	public static void Main ()
	{
		int dummyTestsNo = 30;

		try
		{
			/* dummy correctness tests */
			for (int i = 0; i < dummyTestsNo; ++i)
			{
				Graph sparseGraph = new Graph ();
				sparseGraph.GenerateSparse (1000);

				Graph denseGraph = new Graph ();
				denseGraph.GenerateDense (1000);

				DummyCorrectTests.Test (sparseGraph);
				DummyCorrectTests.Test (denseGraph);
			}
		}
		catch(Exception e)
		{
			Console.WriteLine ("Dummy correctness tests DO NOT PASSED: {0}", e.Message);
			return;
		}
		Console.WriteLine ("Dummy tests DO PASSED.");

		/* evaluation */
		int runsNo = 100;
		//int[] vNos = {100, 500, 1000, 1750, 2500, 3750, 5000, 6250, 7500, 8750, 10000};
		int[] vNos = {1000};

		EvalResult[] results = new EvalResult[vNos.Length];

		for (int i = 0; i < vNos.Length; ++i)
		{
			results [i] = Evaluator.Eval (runsNo, vNos [i]);
			Console.WriteLine (results [i]);
			Console.WriteLine ("------------------------------");
		}
	}

	#endregion
}
