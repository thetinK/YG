using System;

namespace RxjhServer
{
	public class 坐标Class : IDisposable
	{
		private float _Rxjh_X;

		private float _Rxjh_Y;

		private float _Rxjh_Z;

		private int _Rxjh_Map;

		private string _Rxjh_name;

		public float Rxjh_X
		{
			get
			{
				return _Rxjh_X;
			}
			set
			{
				_Rxjh_X = value;
			}
		}

		public float Rxjh_Y
		{
			get
			{
				return _Rxjh_Y;
			}
			set
			{
				_Rxjh_Y = value;
			}
		}

		public float Rxjh_Z
		{
			get
			{
				return _Rxjh_Z;
			}
			set
			{
				_Rxjh_Z = value;
			}
		}

		public int Rxjh_Map
		{
			get
			{
				return _Rxjh_Map;
			}
			set
			{
				_Rxjh_Map = value;
			}
		}

		public string Rxjh_name
		{
			get
			{
				return _Rxjh_name;
			}
			set
			{
				_Rxjh_name = value;
			}
		}

		public static string getmapname(int id)
		{
			foreach (坐标Class item in World.移动)
			{
				if (item.Rxjh_Map == id)
				{
					return item.Rxjh_name;
				}
			}
			return string.Empty;
		}

		public static int getmapid(string mapname)
		{
			foreach (坐标Class item in World.移动)
			{
				if (item.Rxjh_name == mapname)
				{
					return item.Rxjh_Map;
				}
			}
			return 0;
		}

		public static string GetMapName(int id)
		{
			string value;
			return (!World.Maplist.TryGetValue(id, out value)) ? string.Empty : value;
		}

		public void Dispose()
		{
		}

		public 坐标Class(float Rxjh__X, float Rxjh__Y, float Rxjh__Z, int Rxjh__Map)
		{
			Rxjh_X = Rxjh__X;
			Rxjh_Y = Rxjh__Y;
			Rxjh_Z = Rxjh__Z;
			Rxjh_Map = Rxjh__Map;
		}

		public static string getname(int mapid)
		{
			if (1 == 0)
			{
			}
			string result = mapid switch
			{
				201 => "三邪关", 
				101 => "泫勃派", 
				401 => "无天阁1层", 
				402 => "无天阁2层", 
				403 => "无天阁3层", 
				301 => "柳正关", 
				601 => "渊竹林", 
				501 => "万寿阁1层", 
				502 => "万寿阁2层", 
				503 => "万寿阁3层", 
				901 => "荤捧包", 
				801 => "义斗关", 
				41001 => "仙魔大战", 
				701 => "竹火林", 
				1101 => "柳善提督府", 
				1001 => "神武门", 
				1301 => "南明湖", 
				1201 => "银币广场", 
				1501 => "血魔洞2层", 
				1401 => "血魔洞1层", 
				1801 => "地灵洞2层", 
				1701 => "地灵洞1层", 
				1601 => "血魔洞3层", 
				2001 => "南明洞", 
				1901 => "地灵洞3层", 
				2201 => "百武关", 
				2101 => "松月关", 
				2501 => "失落之地", 
				2401 => "梅花迷宫", 
				2711 => "迷宫第二层", 
				2701 => "迷宫第一层", 
				2601 => "钥匙房", 
				2801 => "三界玄门", 
				2721 => "迷宫第三层", 
				5001 => "北海冰宫", 
				3201 => "女王宫殿", 
				2901 => "修炼之地", 
				5201 => "北海玄冰宫", 
				5101 => "北海水宫", 
				5601 => "植物大战僵尸", 
				5501 => "北海冰宫幻影", 
				5401 => "玄冰地宫", 
				_ => string.Empty, 
			};
			if (1 == 0)
			{
			}
			return result;
		}

		public 坐标Class()
		{
		}
	}
}
