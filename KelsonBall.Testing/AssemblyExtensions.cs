using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace KelsonBall.Testing
{
	internal static class AssemblyExtensions
	{					
		internal static MethodInfo[] GetTestMethods(this Assembly testAssembly)		
		{
			return testAssembly.GetTypes ()		
					.Where (t => t.GetCustomAttribute<TestClassAttribute> () != null)		
					.SelectMany (type => type.GetMethods ()		
						.Where (method => method.GetCustomAttribute<TestMethodAttribute> () != null)		
					).ToArray();		
		}
		
		internal static Exception InvokeTestMethod(this MethodInfo method)	
		{
			try
			{
				IEnumerable<object[]> parameterSets = method.GetCustomAttributes<TestCaseAttribute> ()
					.Select(attribute => ((TestCaseAttribute)attribute).Data);

				if (!parameterSets.Any())
				{
					parameterSets = new List<object[]>(){new object[]{}};
				}

				object instance = Activator.CreateInstance (method.DeclaringType);

				foreach (object[] parameters in parameterSets)
				{
					method.Invoke (instance, parameters);
				}
			}

			catch (Exception e)
			{
				return e.InnerException ?? e;
			}		
			return null;
		}
	}
}

