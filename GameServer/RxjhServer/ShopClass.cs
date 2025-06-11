using System.Collections.Generic;
using System.Linq;

namespace RxjhServer
{
	public class ShopClass
	{
        public int NpcId { get; set; }            // รหัส NPC เจ้าของร้าน (0 = ร้านระบบ)
        public int ItemIndex { get; set; }        // รหัสไอเทมในฐานข้อมูลไอเทม
        public int PlayerId { get; set; }         // รหัสผู้เล่นเจ้าของร้าน (หากเป็นร้านผู้เล่น)
        public long Price { get; set; }           // ราคาขายเป็นเงินทอง

        // คุณสมบัติพิเศษของไอเทม (เช่น +5, +10, สีต่างๆ)
        public int MagicProperty0 { get; set; }   // คุณสมบัติพิเศษที่ 1
        public int MagicProperty1 { get; set; }   // คุณสมบัติพิเศษที่ 2
        public int MagicProperty2 { get; set; }   // คุณสมบัติพิเศษที่ 3
        public int MagicProperty3 { get; set; }   // คุณสมบัติพิเศษที่ 4
        public int MagicProperty4 { get; set; }   // คุณสมบัติพิเศษที่ 5

        // สกุลเงินพิเศษที่ต้องการในการซื้อ
        public int RequiredWarMerit { get; set; } // คะแนนการรบที่ต้องการ (ได้จากการ PvP)
        public int RequiredIceJade { get; set; }  // น้ำแข็งหยกที่ต้องการ (วัสดุหายาก)

        public List<ShopClass> Shop { get; set; } = new List<ShopClass>();

        public int ActiveMagicPropertiesCount =>
            new[] { MagicProperty1, MagicProperty2, MagicProperty3, MagicProperty4 }
                .Count(property => property != 0);

        public static List<ShopClass> GetShopListAll(int id)
		{
			List<ShopClass> list = new List<ShopClass>();
			foreach (ShopClass item in World.Shop)
			{
				if (item.NpcId == id)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public static List<ShopClass> GetShopList(int id, int pages)
		{
			List<ShopClass> list = new List<ShopClass>();
			List<ShopClass> list2 = new List<ShopClass>();
			if (pages == 0)
			{
				int num = 0;
				foreach (ShopClass item in World.Shop)
				{
					num++;
					if (item.NpcId == id)
					{
						list.Add(item);
					}
					if (list.Count == 60)
					{
						break;
					}
				}
				return list;
			}
			foreach (ShopClass item2 in World.Shop)
			{
				if (item2.NpcId == id)
				{
					list.Add(item2);
				}
			}
			for (int i = pages * 60; i < list.Count; i++)
			{
				list2.Add(list[i]);
				if (list2.Count == 60)
				{
					break;
				}
			}
			return list2;
		}

		public static ShopClass Getwp(int id)
		{
			foreach (ShopClass item in World.Shop)
			{
				if (item.PlayerId == id)
				{
					return item;
				}
			}
			return null;
		}

		public static int GetShop(int id)
		{
			int num = 0;
			foreach (ShopClass item in World.Shop)
			{
				if (item.NpcId == id)
				{
					num++;
				}
			}
			return num;
		}
	}
}
