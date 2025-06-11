using System;
using System.Threading;

namespace Threading.Locking
{
	public abstract class BaseLock : IDisposable
	{
		protected ReaderWriterLockSlim _Locks;

		public BaseLock(ReaderWriterLockSlim locks)
		{
			_Locks = locks;
		}

		public abstract void Dispose();
	}
}
