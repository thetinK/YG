using System.Collections.Concurrent;

namespace RxjhServer
{
	public class MapClass
	{
		public ConcurrentDictionary<int, NpcClass> npcTemplate = new ConcurrentDictionary<int, NpcClass>();

		private int _MapID;

		public int MapID
		{
			get
			{
				return _MapID;
			}
			set
			{
				_MapID = value;
			}
		}

		public static int GetNpcConn()
		{
			int num = 0;
			foreach (MapClass value in World.Map.Values)
			{
				num += value.npcTemplate.Count;
			}
			return num;
		}

		public static ConcurrentDictionary<int, NpcClass> GetnpcTemplate(int mapp)
		{
			MapClass value;
			return (!World.Map.TryGetValue(mapp, out value)) ? new ConcurrentDictionary<int, NpcClass>() : value.npcTemplate;
		}

		public static NpcClass GetNpc(int mapp, int NpcWordId)
		{
			if (!World.Map.TryGetValue(mapp, out var value))
			{
				return null;
			}
			NpcClass value2;
			return (!value.npcTemplate.TryGetValue(NpcWordId, out value2)) ? null : value2;
		}

		public static void delnpc(int mapp, int NpcWordId)
		{
			if (World.Map.TryGetValue(mapp, out var value))
			{
				value.del(NpcWordId);
			}
		}

		public static ConcurrentDictionary<int, NpcClass> GetnpcPID(int mapid, int pid)
		{
			ConcurrentDictionary<int, NpcClass> concurrentDictionary = new ConcurrentDictionary<int, NpcClass>();
			if (World.Map.TryGetValue(mapid, out var value))
			{
				foreach (NpcClass value2 in value.npcTemplate.Values)
				{
					if (value2.FLD_PID == pid)
					{
						concurrentDictionary.TryAdd(value2.FLD_INDEX, value2);
					}
				}
			}
			return concurrentDictionary;
		}

		public void del(int NpcWordId)
		{
			using (new Lock(npcTemplate, "MapClass-del"))
			{
				npcTemplate.TryRemove(NpcWordId, out var _);
			}
		}

		public void add(NpcClass npc)
		{
			for (int i = 10000; i < 30000; i++)
			{
				if (!npcTemplate.ContainsKey(i))
				{
					npc.FLD_INDEX = i;
					if (!npcTemplate.ContainsKey(npc.FLD_INDEX))
					{
						npcTemplate.TryAdd(npc.FLD_INDEX, npc);
					}
					break;
				}
			}
		}
	}
}
