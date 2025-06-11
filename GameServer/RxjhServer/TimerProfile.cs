using System;

namespace RxjhServer
{
	public class TimerProfile
	{
		private int m_Created;

		private int m_Started;

		private int m_Stopped;

		private int m_Ticked;

		private TimeSpan m_TotalProcTime;

		private TimeSpan m_PeakProcTime;

		public void RegCreation()
		{
			m_Created++;
		}

		public void RegStart()
		{
			m_Started++;
		}

		public void RegStopped()
		{
			m_Stopped++;
		}

		public void RegTicked(TimeSpan procTime)
		{
			m_Ticked++;
			m_TotalProcTime += procTime;
			if (procTime > m_PeakProcTime)
			{
				m_PeakProcTime = procTime;
			}
		}
	}
}
