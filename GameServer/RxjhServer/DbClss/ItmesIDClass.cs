using System;
using System.Collections.Generic;

namespace RxjhServer.DbClss
{
	public class ItmesIDClass
	{
		private readonly object AsyncLocksw = new object();

		private long ItmeId;

		private long Id;

		public ItmesIDClass()
		{
			try
			{
				ItmeId = 0L;
				Id = 0L;
				ItmeId = long.Parse(DBA.GetDBValue_3("EXEC XWWL_GetItemSerial2 1000").ToString());
				Id = ItmeId + 1000;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(100, "全局ID出错" + ex.Message);
				World.conn.Dispose();
				List<Players> list = new List<Players>();
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					list.Add(value);
				}
				foreach (Players item in list)
				{
					try
					{
						if (item.Client != null)
						{
							item.OpClient(1);
							item.Client.Dispose();
						}
					}
					catch (Exception ex2)
					{
						MainForm.WriteLine(1, "保存人物的数据 错误" + ex2.Message);
					}
				}
				list.Clear();
			}
		}

		public long AcquireBuffer()
		{
			using (new Lock(AsyncLocksw, "AcquireBuffer"))
			{
				if (ItmeId < Id)
				{
					return ItmeId++;
				}
				ItmeId = long.Parse(DBA.GetDBValue_3("EXEC XWWL_GetItemSerial2 1000").ToString());
				Id = ItmeId + 1000;
				return ItmeId++;
			}
		}
	}
}
