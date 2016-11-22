using System;
using System.Reflection;

namespace KelsonBall.Testing
{
	public class TestRunner
	{
		public static void Run(Assembly assembly = null)
		{
			assembly = assembly ?? Assembly.GetEntryAssembly ();
			MethodInfo[] tests = assembly.GetTestMethods ();
			int passed = 0;
			foreach (var test in tests) 
			{
				Exception e = test.InvokeTestMethod ();
				if (e == null)
					passed++;
				else if (e.InnerException != null)
					Console.WriteLine($@"{test.DeclaringType.Name}: {test.ToString()}, {e.InnerException.Message}");
				else
					throw e;				
			}
			Console.WriteLine($@"Passed {passed} of {tests.Length} tests.");
		}
	}
}

