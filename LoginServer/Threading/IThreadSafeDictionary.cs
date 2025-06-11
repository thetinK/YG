using System;
using System.Collections;
using System.Collections.Generic;

namespace Threading
{
	public interface IThreadSafeDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDisposable
	{
		void MergeSafe(TKey key, TValue newValue);

		void RemoveSafe(TKey key);

		new void Dispose();
	}
}
