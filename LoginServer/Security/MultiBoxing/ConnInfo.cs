using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Security.MultiBoxing
{
	public class ConnInfo
	{
		public static List<ConnInfo> ConnInfos = new List<ConnInfo>();

		private static object _lock = new object();

		public string Ip { get; set; }

		public int Port { get; set; }

		public DateTime Time { get; set; }

		public bool Kill { get; set; }

		public static void Add(ConnInfo info)
		{
			lock (_lock)
			{
				ConnInfos.Add(info);
			}
		}

		public static bool Check(string ip, int port)
		{
			lock (_lock)
			{
				List<ConnInfo> t = ConnInfos.Where((i) => i.Ip == ip).ToList();
				if (t.Count < World.RapidConnectionLimit)
				{
					return true;
				}
				if (t.FirstOrDefault((i) => i.Kill) != null)
				{
					return false;
				}
				IEnumerable<ConnInfo> t2 = t.OrderByDescending((i) => i.Time).Take(World.RapidConnectionLimit);
				DateTime ct = t2.Min((i) => i.Time);
				if ((DateTime.Now - ct).TotalSeconds < World.RapidConnectionTimeLimit)
				{
					return false;
				}
				return true;
			}
		}
	}
}
