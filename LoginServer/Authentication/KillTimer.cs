using Core;
using System;
using System.Timers;

namespace Authentication
{
    public class KillTimer
    {
        public readonly Timer timer = new Timer(300000.0);

        public string UserId { get; set; }
        public int ConnectionAttempts { get; set; }
        public int Move { get; set; }
        public DateTime ExpireTime { get; set; }

        public KillTimer()
        {
            ExpireTime = DateTime.Now.AddMinutes(5.0);
            timer.Elapsed += OnTimerExpired;
            timer.Enabled = true;
        }

        public void OnTimerExpired(object source, ElapsedEventArgs e)
        {
            lock (World.KillList)
            {
                World.KillList.Remove(UserId);
            }
            timer?.Dispose();
        }

        public TimeSpan GetRemainingTime() => ExpireTime.Subtract(DateTime.Now);
    }
}
