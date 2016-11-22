using System;

namespace KelsonBall.Testing
{
	public class TestClassAttribute : Attribute { }

	public class TestMethodAttribute : Attribute { }

	public class TestCaseAttribute : Attribute 
	{
		public object[] Data;

		public TestCaseAttribute(params object[] parameters)
		{
			Data = parameters;
		}
	}
}

