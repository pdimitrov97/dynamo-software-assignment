using System;
using System.Threading.Tasks;

namespace DynamoSoftware.Assignment.UnitTests.Helpers
{
	internal class ExceptionHelpers
	{
		public static bool Catch(Action action, out Exception ex)
		{
			return Catch<Exception>(action, out ex);
		}

		public static bool Catch<T>(Action action, out T ex) where T : Exception
		{
			try
			{
				action();
			}
			catch (T exception)
			{
				ex = exception;
				return true;
			}

			ex = null;

			return false;
		}

		public static async Task<(bool, T)> Catch<T>(Func<Task> action) where T : Exception
		{
			try
			{
				await action();
			}
			catch (T exception)
			{
				return (true, exception);
			}

			return (false, null);
		}
	}
}