using System.Threading;

namespace Threading.Locking
{
	public class ReadLock : BaseLock
	{
		public ReadLock(ReaderWriterLockSlim locks)
			: base(locks)
		{
			Locks.GetReadLock(_Locks);
		}

		public override void Dispose()
		{
			Locks.ReleaseReadLock(_Locks);
		}
	}
}
