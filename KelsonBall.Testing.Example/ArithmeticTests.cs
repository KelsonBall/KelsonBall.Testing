using System;

namespace KelsonBall.Testing.Example
{
	[TestClass]
	public class ArithmeticTests
	{
		[TestMethod]
		public void TwoPlusTwoTest()
		{
			var result = 2 + 2;
			Assert.Equals (result, 4);
		}

		[TestCase(true, false)]
		[TestMethod]
		public void ParametersTest(bool a, bool b)
		{
			Assert.True  (a);
			Assert.False (b);
		}

		[TestCase(0)]
		[TestMethod]
		public void DivideByZeroTest(int div)
		{
			int result;
			Assert.Throws<DivideByZeroException> (() => result = 1 / div);
		}
	}
}

