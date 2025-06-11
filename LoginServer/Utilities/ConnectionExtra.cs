using System;
using System.Collections.Concurrent;

namespace Utilities
{
	public class ConnectionExtra
	{
		private ConcurrentDictionary<IntPtr, object> dict = new ConcurrentDictionary<IntPtr, object>();

		public T GetExtra<T>(IntPtr key)
		{
			if (!dict.TryGetValue(key, out var value))
			{
				return default;
			}
			return (T)value;
		}

		public bool SetExtra(IntPtr key, object newValue)
		{
			try
			{
				dict.AddOrUpdate(key, newValue, (tKey, existingVal) => newValue);
				return true;
			}
			catch (OverflowException)
			{
				return false;
			}
			catch (ArgumentNullException)
			{
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
