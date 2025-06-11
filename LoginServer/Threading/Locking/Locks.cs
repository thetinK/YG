using System.Threading;

namespace Threading.Locking
{
	public static class Locks
	{
		public static void GetReadLock(ReaderWriterLockSlim locks)
		{
			bool flag = false;
			while (!flag)
			{
				flag = locks.TryEnterUpgradeableReadLock(1);
			}
		}

		public static void GetReadOnlyLock(ReaderWriterLockSlim locks)
		{
			bool flag = false;
			while (!flag)
			{
				flag = locks.TryEnterReadLock(1);
			}
		}

		public static void GetWriteLock(ReaderWriterLockSlim locks)
		{
			bool flag = false;
			while (!flag)
			{
				flag = locks.TryEnterWriteLock(1);
			}
		}

		public static void ReleaseReadOnlyLock(ReaderWriterLockSlim locks)
		{
			if (locks.IsReadLockHeld)
			{
				locks.ExitReadLock();
			}
		}

		public static void ReleaseReadLock(ReaderWriterLockSlim locks)
		{
			if (locks.IsUpgradeableReadLockHeld)
			{
				locks.ExitUpgradeableReadLock();
			}
		}

		public static void ReleaseWriteLock(ReaderWriterLockSlim locks)
		{
			if (locks.IsWriteLockHeld)
			{
				locks.ExitWriteLock();
			}
		}

		public static ReaderWriterLockSlim GetLockInstance(LockRecursionPolicy recursionPolicy)
		{
			return new ReaderWriterLockSlim(recursionPolicy);
		}
	}
}
