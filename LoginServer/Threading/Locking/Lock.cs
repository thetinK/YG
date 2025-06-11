using System;
using System.Threading;
using UI;

namespace Threading.Locking
{
	public class Lock : IDisposable
	{
		public static int DefaultMillisecondsTimeout = 1000;

		private object _obj;

		public Lock(object obj, string lei)
		{
			TryGet(obj, 1000, throwTimeoutException: true, lei);
		}

		private void TryGet(object obj, int millisecondsTimeout, bool throwTimeoutException, string lei)
		{
			if (Monitor.TryEnter(obj, millisecondsTimeout))
			{
				_obj = obj;
			}
			else if (throwTimeoutException)
			{
				string text = obj.GetType()?.ToString();
				MainForm.WriteLine(100, "锁定对象超时:" + lei + " " + text);
			}
		}

		public void Dispose()
		{
			if (_obj != null)
			{
				Monitor.Exit(_obj);
				_obj = null;
			}
		}
	}
}
