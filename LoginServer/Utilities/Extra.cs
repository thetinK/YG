using System;
using System.Collections.Concurrent;

namespace Utilities
{
	public class Extra<T>
	{
		private ConcurrentDictionary<IntPtr, T> dict = new ConcurrentDictionary<IntPtr, T>();

		public T Get(IntPtr key)
		{
			if (!dict.TryGetValue(key, out var value))
			{
				return default;
			}
			return value;
		}

		public bool Set(IntPtr key, T newValue)
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

		public bool Remove(IntPtr key)
		{
			T value;
			return dict.TryRemove(key, out value);
		}
	}
}
