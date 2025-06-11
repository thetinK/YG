using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RxjhServer
{
	public class CraftingItem
	{
		public List<RequiredItem> RequiredItems = new List<RequiredItem>();

		public int ItemID;

		public string ItemName;

		public int ItemQuantity;

		public int CraftType;

		public int CraftLevel;

		public static ConcurrentDictionary<int, CraftingItem> Get制作物品类列表(int 制作类型, int 制作等级)
		{
			ConcurrentDictionary<int, CraftingItem> concurrentDictionary = new ConcurrentDictionary<int, CraftingItem>();
			foreach (CraftingItem value in World.craftingItemsList.Values)
			{
				if ((value.CraftType == 制作类型 || value.CraftType == 4) && 制作等级 >= value.CraftLevel)
				{
					concurrentDictionary.TryAdd(value.ItemID, value);
				}
			}
			return concurrentDictionary;
		}
	}
}
