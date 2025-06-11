using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace RxjhServer
{
	public class Timer
	{
		public class TimerThread
		{
			private class TimerChangeEntry
			{
				public Timer m_Timer;

				public int m_NewIndex;

				public bool m_IsAdd;

				private static readonly Queue<TimerChangeEntry> m_InstancePool = new Queue<TimerChangeEntry>();

				private TimerChangeEntry(Timer t, int newIndex, bool isAdd)
				{
					m_Timer = t;
					m_NewIndex = newIndex;
					m_IsAdd = isAdd;
				}

				public void Free()
				{
				}

				public static TimerChangeEntry GetInstance(Timer t, int newIndex, bool isAdd)
				{
					TimerChangeEntry timerChangeEntry;
					if (m_InstancePool.Count > 0)
					{
						timerChangeEntry = m_InstancePool.Dequeue();
						if (timerChangeEntry == null)
						{
							timerChangeEntry = new TimerChangeEntry(t, newIndex, isAdd);
						}
						else
						{
							timerChangeEntry.m_Timer = t;
							timerChangeEntry.m_NewIndex = newIndex;
							timerChangeEntry.m_IsAdd = isAdd;
						}
					}
					else
					{
						timerChangeEntry = new TimerChangeEntry(t, newIndex, isAdd);
					}
					return timerChangeEntry;
				}
			}

			private static readonly Queue m_ChangeQueue = Queue.Synchronized(new Queue());

			private static readonly DateTime[] m_NextPriorities = new DateTime[8];

			private static readonly TimeSpan[] m_PriorityDelays = new TimeSpan[8]
			{
				TimeSpan.Zero,
				TimeSpan.FromMilliseconds(10.0),
				TimeSpan.FromMilliseconds(25.0),
				TimeSpan.FromMilliseconds(50.0),
				TimeSpan.FromMilliseconds(250.0),
				TimeSpan.FromSeconds(1.0),
				TimeSpan.FromSeconds(5.0),
				TimeSpan.FromMinutes(1.0)
			};

			private static readonly List<Timer>[] m_Timers = new List<Timer>[8]
			{
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>()
			};

			public static void DumpInfo(TextWriter tw)
			{
				for (int i = 0; i < 8; i++)
				{
					tw.WriteLine("Priority: {0}", (TimerPriority)i);
					tw.WriteLine();
					ConcurrentDictionary<string, List<Timer>> concurrentDictionary = new ConcurrentDictionary<string, List<Timer>>();
					for (int j = 0; j < m_Timers[i].Count; j++)
					{
						Timer timer = m_Timers[i][j];
						string key = timer.ToString();
						concurrentDictionary.TryGetValue(key, out var value);
						if (value == null)
						{
							List<Timer> list4 = (concurrentDictionary[key] = new List<Timer>());
							List<Timer> list2 = list4;
							value = list2;
						}
						value.Add(timer);
					}
					foreach (KeyValuePair<string, List<Timer>> item in concurrentDictionary)
					{
						string key2 = item.Key;
						List<Timer> value2 = item.Value;
						tw.WriteLine("Type: {0}; Count: {1}; Percent: {2}%", key2, value2.Count, (int)(100.0 * ((double)value2.Count / (double)m_Timers[i].Count)));
					}
					tw.WriteLine();
					tw.WriteLine();
				}
			}

			public static void Change(Timer t, int newIndex, bool isAdd)
			{
				m_ChangeQueue.Enqueue(TimerChangeEntry.GetInstance(t, newIndex, isAdd));
			}

			public static void AddTimer(Timer t)
			{
				Change(t, (int)t.Priority, isAdd: true);
			}

			public static void PriorityChange(Timer t, int newPrio)
			{
				Change(t, newPrio, isAdd: false);
			}

			public static void RemoveTimer(Timer t)
			{
				Change(t, -1, isAdd: false);
			}

			private static void ProcessChangeQueue()
			{
				while (m_ChangeQueue.Count > 0)
				{
					if (World.JlMsg == 1)
					{
						MainForm.WriteLine(0, "ProcessChangeQueue");
					}
					TimerChangeEntry timerChangeEntry = (TimerChangeEntry)m_ChangeQueue.Dequeue();
					Timer timer = timerChangeEntry.m_Timer;
					int newIndex = timerChangeEntry.m_NewIndex;
					if (timer.m_List != null)
					{
						timer.m_List.Remove(timer);
					}
					if (timerChangeEntry.m_IsAdd)
					{
						timer.m_Next = DateTime.Now + timer.m_Delay;
						timer.m_Index = 0;
					}
					if (newIndex >= 0)
					{
						timer.m_List = m_Timers[newIndex];
						timer.m_List.Add(timer);
					}
					else
					{
						timer.m_List = null;
					}
					timerChangeEntry.Free();
				}
			}

			public void TimerMain()
			{
				while (true)
				{
					if (World.JlMsg == 1)
					{
						MainForm.WriteLine(0, "TimerMain");
					}
					Thread.Sleep(10);
					ProcessChangeQueue();
					for (int i = 0; i < m_Timers.Length; i++)
					{
						DateTime now = DateTime.Now;
						if (now < m_NextPriorities[i])
						{
							break;
						}
						m_NextPriorities[i] = now + m_PriorityDelays[i];
						for (int j = 0; j < m_Timers[i].Count; j++)
						{
							Timer timer = m_Timers[i][j];
							if (!timer.m_Queued && now > timer.m_Next)
							{
								timer.m_Queued = true;
								lock (m_Queue)
								{
									m_Queue.Enqueue(timer);
								}
								if (timer.m_Count != 0 && ++timer.m_Index >= timer.m_Count)
								{
									timer.Stop();
								}
								else
								{
									timer.m_Next = now + timer.m_Interval;
								}
							}
						}
					}
				}
			}
		}

		private class DelayCallTimer : Timer
		{
			private readonly TimerCallback m_Callback;

			public TimerCallback Callback => m_Callback;

			public override bool DefRegCreation => false;

			public DelayCallTimer(TimeSpan delay, TimeSpan interval, int count, TimerCallback callback)
				: base(delay, interval, count)
			{
				m_Callback = callback;
				RegCreation();
			}

			protected override void OnTick()
			{
				m_Callback?.Invoke();
			}

			public override string ToString()
			{
				return "DelayCallTimer[" + FormatDelegate(m_Callback) + "]";
			}
		}

		private class DelayStateCallTimer : Timer
		{
			private readonly TimerStateCallback m_Callback;

			private readonly object m_State;

			public TimerStateCallback Callback => m_Callback;

			public override bool DefRegCreation => false;

			public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, TimerStateCallback callback, object state)
				: base(delay, interval, count)
			{
				m_Callback = callback;
				m_State = state;
				RegCreation();
			}

			protected override void OnTick()
			{
				m_Callback?.Invoke(m_State);
			}

			public override string ToString()
			{
				return "DelayStateCall[" + FormatDelegate(m_Callback) + "]";
			}
		}

		private DateTime m_Next;

		private TimeSpan m_Delay;

		private TimeSpan m_Interval;

		private bool m_Running;

		private int m_Index;

		private readonly int m_Count;

		private TimerPriority m_Priority;

		private List<Timer> m_List;

		private static readonly ConcurrentDictionary<string, TimerProfile> m_Profiles = new ConcurrentDictionary<string, TimerProfile>();

		private static readonly Queue<Timer> m_Queue = new Queue<Timer>();

		private static int m_BreakCount = 20000;

		private static int m_QueueCountAtSlice;

		private bool m_Queued;

		public TimerPriority Priority
		{
			get
			{
				return m_Priority;
			}
			set
			{
				if (m_Priority != value)
				{
					m_Priority = value;
					if (m_Running)
					{
						TimerThread.PriorityChange(this, (int)m_Priority);
					}
				}
			}
		}

		public DateTime Next => m_Next;

		public TimeSpan Delay
		{
			get
			{
				return m_Delay;
			}
			set
			{
				m_Delay = value;
			}
		}

		public TimeSpan Interval
		{
			get
			{
				return m_Interval;
			}
			set
			{
				m_Interval = value;
			}
		}

		public bool Running
		{
			get
			{
				return m_Running;
			}
			set
			{
				if (value)
				{
					Start();
				}
				else
				{
					Stop();
				}
			}
		}

		public static ConcurrentDictionary<string, TimerProfile> Profiles => m_Profiles;

		public static int BreakCount
		{
			get
			{
				return m_BreakCount;
			}
			set
			{
				m_BreakCount = value;
			}
		}

		public virtual bool DefRegCreation => true;

		private static string FormatDelegate(Delegate callback)
		{
			if ((object)callback == null)
			{
				return "null";
			}
			return callback.Method.DeclaringType.FullName + "." + callback.Method.Name;
		}

		public static void DumpInfo(TextWriter tw)
		{
			TimerThread.DumpInfo(tw);
		}

		public TimerProfile GetProfile()
		{
			string text = ToString();
			if (text == null)
			{
				text = "null";
			}
			m_Profiles.TryGetValue(text, out var value);
			if (value == null)
			{
				return m_Profiles[text] = new TimerProfile();
			}
			return value;
		}

		public static void Slice()
		{
			lock (m_Queue)
			{
				m_QueueCountAtSlice = m_Queue.Count;
				int num = 0;
				Stopwatch stopwatch = null;
				while (num < m_BreakCount && m_Queue.Count != 0)
				{
					if (World.JlMsg == 1)
					{
						MainForm.WriteLine(0, "Slice");
					}
					Timer timer = m_Queue.Dequeue();
					TimerProfile profile = timer.GetProfile();
					if (profile != null)
					{
						if (stopwatch == null)
						{
							stopwatch = Stopwatch.StartNew();
						}
						else
						{
							stopwatch.Start();
						}
					}
					timer.OnTick();
					timer.m_Queued = false;
					num++;
					if (profile != null)
					{
						profile.RegTicked(stopwatch.Elapsed);
						stopwatch.Reset();
					}
				}
			}
		}

		public Timer(TimeSpan delay)
			: this(delay, TimeSpan.Zero, 1)
		{
		}

		public Timer(TimeSpan delay, TimeSpan interval)
			: this(delay, interval, 0)
		{
		}

		public virtual void RegCreation()
		{
			GetProfile()?.RegCreation();
		}

		public Timer(TimeSpan delay, TimeSpan interval, int count)
		{
			m_Delay = delay;
			m_Interval = interval;
			m_Count = count;
			if (DefRegCreation)
			{
				RegCreation();
			}
		}

		public override string ToString()
		{
			return GetType().FullName;
		}

		public static TimerPriority ComputePriority(TimeSpan ts)
		{
			if (ts >= TimeSpan.FromMinutes(1.0))
			{
				return TimerPriority.FiveSeconds;
			}
			if (ts >= TimeSpan.FromSeconds(10.0))
			{
				return TimerPriority.OneSecond;
			}
			if (ts >= TimeSpan.FromSeconds(5.0))
			{
				return TimerPriority.TwoFiftyMS;
			}
			if (ts >= TimeSpan.FromSeconds(2.5))
			{
				return TimerPriority.FiftyMS;
			}
			if (ts >= TimeSpan.FromSeconds(1.0))
			{
				return TimerPriority.TwentyFiveMS;
			}
			if (ts >= TimeSpan.FromSeconds(0.5))
			{
				return TimerPriority.TenMS;
			}
			return TimerPriority.EveryTick;
		}

		public static Timer DelayCall(TimeSpan delay, TimerCallback callback)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback);
		}

		public static Timer DelayCall(TimeSpan delay, TimeSpan interval, TimerCallback callback)
		{
			return DelayCall(delay, interval, 0, callback);
		}

		public static Timer DelayCall(TimeSpan delay, TimeSpan interval, int count, TimerCallback callback)
		{
			Timer timer = new DelayCallTimer(delay, interval, count, callback);
			if (count == 1)
			{
				timer.Priority = ComputePriority(delay);
			}
			else
			{
				timer.Priority = ComputePriority(interval);
			}
			timer.Start();
			return timer;
		}

		public static Timer DelayCall(TimeSpan delay, TimerStateCallback callback, object state)
		{
			return DelayCall(delay, TimeSpan.Zero, 1, callback, state);
		}

		public static Timer DelayCall(TimeSpan delay, TimeSpan interval, TimerStateCallback callback, object state)
		{
			return DelayCall(delay, interval, 0, callback, state);
		}

		public static Timer DelayCall(TimeSpan delay, TimeSpan interval, int count, TimerStateCallback callback, object state)
		{
			Timer timer = new DelayStateCallTimer(delay, interval, count, callback, state);
			if (count == 1)
			{
				timer.Priority = ComputePriority(delay);
			}
			else
			{
				timer.Priority = ComputePriority(interval);
			}
			timer.Start();
			return timer;
		}

		public void Start()
		{
			if (!m_Running)
			{
				m_Running = true;
				TimerThread.AddTimer(this);
				GetProfile()?.RegStart();
			}
		}

		public void Stop()
		{
			if (m_Running)
			{
				m_Running = false;
				TimerThread.RemoveTimer(this);
				GetProfile()?.RegStopped();
			}
		}

		protected virtual void OnTick()
		{
		}
	}
}
