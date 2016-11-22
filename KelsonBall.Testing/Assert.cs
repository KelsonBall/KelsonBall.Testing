using System;

namespace KelsonBall.Testing
{
	public static class Assert
	{
		public static void True(bool value)
		{
			if (!value)
				throw new AssertionFailedException ();
		}

		public static void True(Func<bool> action)
		{
			if (!action())
				throw new AssertionFailedException ();
		}

		public static void False(bool value)
		{
			if (value)
				throw new AssertionFailedException ();
		}

		public static void False(Func<bool> action)
		{
			if (action ())
				throw new AssertionFailedException ();
		}

		public static void Throws<TException>(Action action) where TException : Exception
		{
			try
			{
				action();
			}
			catch (TException)
			{
				return;
			}
			throw new AssertionFailedException();
		}

		public static void Throws<TException, T>(Func<T> action) where TException : Exception
		{			
			try
			{
				action();
			}
			catch (TException)
			{
				return;
			}
			throw new AssertionFailedException();
		}

		public static void Equals<T>(T a, T b)
		{
			if (!a.Equals(b))
				throw new ArgumentException ();
		}
	}
}

