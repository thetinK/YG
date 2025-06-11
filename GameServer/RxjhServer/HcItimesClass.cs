using System;

namespace RxjhServer
{
	public class HcItimesClass
	{
		private int _位置;

		private byte[] _物品;

		private byte[] _物品id;

		private int _截取气功属性类型;

		private int _强化类型;

		private int _强化数量;

		private int _阶段类型;

		private int _气功属性类型;

		private int _阶段数量;

		private Itimesx _属性1;

		private Itimesx _属性2;

		private Itimesx _属性3;

		private Itimesx _属性4;

		public int 位置
		{
			get
			{
				return _位置;
			}
			set
			{
				_位置 = value;
			}
		}

		public byte[] 物品
		{
			get
			{
				return _物品;
			}
			set
			{
				_物品 = value;
			}
		}

		public byte[] 物品id
		{
			get
			{
				return 得到物品Id();
			}
			set
			{
				_物品id = value;
			}
		}

		public byte[] 物品全局ID => 得到全局ID();

		public byte[] 物品数量
		{
			get
			{
				return 得到物品数量();
			}
			set
			{
				设置物品数量(value);
			}
		}

		public byte[] 物品属性 => 得到物品属性();

		public int 强化类型
		{
			get
			{
				return _强化类型;
			}
			set
			{
				_强化类型 = value;
			}
		}

		public int 强化数量
		{
			get
			{
				return _强化数量;
			}
			set
			{
				_强化数量 = value;
			}
		}

		public int 阶段类型
		{
			get
			{
				return _阶段类型;
			}
			set
			{
				_阶段类型 = value;
			}
		}

		public int 气功属性类型
		{
			get
			{
				return _气功属性类型;
			}
			set
			{
				_气功属性类型 = value;
			}
		}

		public int 截取气功属性类型
		{
			get
			{
				return _截取气功属性类型;
			}
			set
			{
				_截取气功属性类型 = value;
			}
		}

		public int 阶段数量
		{
			get
			{
				return _阶段数量;
			}
			set
			{
				_阶段数量 = value;
			}
		}

		public Itimesx 属性1
		{
			get
			{
				return _属性1;
			}
			set
			{
				_属性1 = value;
			}
		}

		public Itimesx 属性2
		{
			get
			{
				return _属性2;
			}
			set
			{
				_属性2 = value;
			}
		}

		public Itimesx 属性3
		{
			get
			{
				return _属性3;
			}
			set
			{
				_属性3 = value;
			}
		}

		public Itimesx 属性4
		{
			get
			{
				return _属性4;
			}
			set
			{
				_属性4 = value;
			}
		}

		public int FLD_FJ_觉醒
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品, 62, array, 0, 4);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品, 62, 4);
			}
		}

		public int FLD_FJ_四神之力
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品, 71, array, 0, 1);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品, 71, 1);
			}
		}

		public int FLD_FJ_进化
		{
			get
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品, 68, array, 0, 2);
				return BitConverter.ToInt32(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品, 68, 2);
			}
		}

		public int FLD_FJ_NJ
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品, 60, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品, 60, 2);
			}
		}

		public int FLD_FJ_中级附魂
		{
			get
			{
				byte[] array = new byte[2];
				Buffer.BlockCopy(物品, 40, array, 0, 2);
				return BitConverter.ToInt16(array, 0);
			}
			set
			{
				if (value > 0)
				{
					Buffer.BlockCopy(BitConverter.GetBytes(1), 0, 物品, 38, 2);
				}
				Buffer.BlockCopy(BitConverter.GetBytes(value), 0, 物品, 40, 2);
			}
		}

		public byte[] 得到物品属性()
		{
			byte[] array = new byte[56];
			try
			{
				Buffer.BlockCopy(物品, 16, array, 0, 56);
			}
			catch
			{
			}
			return array;
		}

		public byte[] 得到物品Id()
		{
			byte[] array = new byte[4];
			try
			{
				Buffer.BlockCopy(物品, 8, array, 0, 4);
			}
			catch
			{
			}
			return array;
		}

		public byte[] 得到物品数量()
		{
			byte[] array = new byte[4];
			try
			{
				Buffer.BlockCopy(物品, 12, array, 0, 4);
			}
			catch
			{
			}
			return array;
		}

		public void 设置物品数量(byte[] 数量)
		{
			Buffer.BlockCopy(数量, 0, 物品, 12, 4);
		}

		public void 设置属性()
		{
			try
			{
				string s = "00000000";
				string s2 = "00000000";
				string s3 = "00000000";
				string s4 = "00000000";
				if (World.是否支持扩展物品属性位数 == 0)
				{
					if (属性1.属性数量 != 0)
					{
						s = ((属性1.属性数量 >= 10) ? ((属性1.属性类型 != 8 || 属性1.气功属性类型 == 0) ? (属性1.属性类型 + "00000" + 属性1.属性数量) : ((属性1.气功属性类型.ToString().Length > 2) ? (属性1.属性类型 + "00" + 属性1.气功属性类型 + "0" + 属性1.属性数量) : (属性1.属性类型 + "000" + 属性1.气功属性类型 + "0" + 属性1.属性数量))) : ((属性1.属性类型 != 8 || 属性1.气功属性类型 == 0) ? (属性1.属性类型 + "000000" + 属性1.属性数量) : ((属性1.气功属性类型.ToString().Length > 2) ? (属性1.属性类型 + "00" + 属性1.气功属性类型 + "0" + 属性1.属性数量) : (属性1.属性类型 + "000" + 属性1.气功属性类型 + "0" + 属性1.属性数量))));
					}
					if (属性2.属性数量 != 0)
					{
						s2 = ((属性2.属性数量 >= 10) ? ((属性2.属性类型 != 8 || 属性2.气功属性类型 == 0) ? (属性2.属性类型 + "00000" + 属性2.属性数量) : ((属性2.气功属性类型.ToString().Length > 2) ? (属性2.属性类型 + "00" + 属性2.气功属性类型 + "0" + 属性2.属性数量) : (属性2.属性类型 + "000" + 属性2.气功属性类型 + "0" + 属性2.属性数量))) : ((属性2.属性类型 != 8 || 属性2.气功属性类型 == 0) ? (属性2.属性类型 + "000000" + 属性2.属性数量) : ((属性2.气功属性类型.ToString().Length > 2) ? (属性2.属性类型 + "00" + 属性2.气功属性类型 + "0" + 属性2.属性数量) : (属性2.属性类型 + "000" + 属性2.气功属性类型 + "0" + 属性2.属性数量))));
					}
					if (属性3.属性数量 != 0)
					{
						s3 = ((属性3.属性数量 >= 10) ? ((属性3.属性类型 != 8 || 属性3.气功属性类型 == 0) ? (属性3.属性类型 + "00000" + 属性3.属性数量) : ((属性3.气功属性类型.ToString().Length > 2) ? (属性3.属性类型 + "00" + 属性3.气功属性类型 + "0" + 属性3.属性数量) : (属性3.属性类型 + "000" + 属性3.气功属性类型 + "0" + 属性3.属性数量))) : ((属性3.属性类型 != 8 || 属性3.气功属性类型 == 0) ? (属性3.属性类型 + "000000" + 属性3.属性数量) : ((属性3.气功属性类型.ToString().Length > 2) ? (属性3.属性类型 + "00" + 属性3.气功属性类型 + "0" + 属性3.属性数量) : (属性3.属性类型 + "000" + 属性3.气功属性类型 + "0" + 属性3.属性数量))));
					}
					if (属性4.属性数量 != 0)
					{
						s4 = ((属性4.属性数量 >= 10) ? ((属性4.属性类型 != 8 || 属性4.气功属性类型 == 0) ? (属性4.属性类型 + "00000" + 属性4.属性数量) : ((属性4.气功属性类型.ToString().Length > 2) ? (属性4.属性类型 + "00" + 属性4.气功属性类型 + "0" + 属性4.属性数量) : (属性4.属性类型 + "000" + 属性4.气功属性类型 + "0" + 属性4.属性数量))) : ((属性4.属性类型 != 8 || 属性4.气功属性类型 == 0) ? (属性4.属性类型 + "000000" + 属性4.属性数量) : ((属性4.气功属性类型.ToString().Length > 2) ? (属性4.属性类型 + "00" + 属性4.气功属性类型 + "0" + 属性4.属性数量) : (属性4.属性类型 + "000" + 属性4.气功属性类型 + "0" + 属性4.属性数量))));
					}
				}
				else
				{
					if (属性1.属性数量 != 0)
					{
						switch (属性1.属性数量.ToString().Length)
						{
						case 1:
							s = ((属性1.属性类型 != 8 || 属性1.气功属性类型 == 0) ? (属性1.属性类型 + "000000" + 属性1.属性数量) : ((属性1.气功属性类型.ToString().Length > 2) ? (属性1.属性类型 + "00" + 属性1.气功属性类型 + "0" + 属性1.属性数量) : (属性1.属性类型 + "000" + 属性1.气功属性类型 + "0" + 属性1.属性数量)));
							break;
						case 2:
							s = 属性1.属性类型 + "00000" + 属性1.属性数量;
							break;
						case 3:
							s = 属性1.属性类型 + "0000" + 属性1.属性数量;
							break;
						case 4:
							s = 属性1.属性类型 + "000" + 属性1.属性数量;
							break;
						case 5:
							s = 属性1.属性类型 + "00" + 属性1.属性数量;
							break;
						}
					}
					if (属性2.属性数量 != 0)
					{
						switch (属性2.属性数量.ToString().Length)
						{
						case 1:
							s2 = ((属性2.属性类型 != 8 || 属性2.气功属性类型 == 0) ? (属性2.属性类型 + "000000" + 属性2.属性数量) : ((属性2.气功属性类型.ToString().Length > 2) ? (属性2.属性类型 + "00" + 属性2.气功属性类型 + "0" + 属性2.属性数量) : (属性2.属性类型 + "000" + 属性2.气功属性类型 + "0" + 属性2.属性数量)));
							break;
						case 2:
							s2 = 属性2.属性类型 + "00000" + 属性2.属性数量;
							break;
						case 3:
							s2 = 属性2.属性类型 + "0000" + 属性2.属性数量;
							break;
						case 4:
							s2 = 属性2.属性类型 + "000" + 属性2.属性数量;
							break;
						case 5:
							s2 = 属性2.属性类型 + "00" + 属性2.属性数量;
							break;
						}
					}
					if (属性3.属性数量 != 0)
					{
						switch (属性3.属性数量.ToString().Length)
						{
						case 1:
							s3 = ((属性3.属性类型 != 8 || 属性3.气功属性类型 == 0) ? (属性3.属性类型 + "000000" + 属性3.属性数量) : ((属性3.气功属性类型.ToString().Length > 2) ? (属性3.属性类型 + "00" + 属性3.气功属性类型 + "0" + 属性3.属性数量) : (属性3.属性类型 + "000" + 属性3.气功属性类型 + "0" + 属性3.属性数量)));
							break;
						case 2:
							s3 = 属性3.属性类型 + "00000" + 属性3.属性数量;
							break;
						case 3:
							s3 = 属性3.属性类型 + "0000" + 属性3.属性数量;
							break;
						case 4:
							s3 = 属性3.属性类型 + "000" + 属性3.属性数量;
							break;
						case 5:
							s3 = 属性3.属性类型 + "00" + 属性3.属性数量;
							break;
						}
					}
					if (属性4.属性数量 != 0)
					{
						switch (属性4.属性数量.ToString().Length)
						{
						case 1:
							s4 = ((属性4.属性类型 != 8 || 属性4.气功属性类型 == 0) ? (属性4.属性类型 + "000000" + 属性4.属性数量) : ((属性4.气功属性类型.ToString().Length > 2) ? (属性4.属性类型 + "00" + 属性4.气功属性类型 + "0" + 属性4.属性数量) : (属性4.属性类型 + "000" + 属性4.气功属性类型 + "0" + 属性4.属性数量)));
							break;
						case 2:
							s4 = 属性4.属性类型 + "00000" + 属性4.属性数量;
							break;
						case 3:
							s4 = 属性4.属性类型 + "0000" + 属性4.属性数量;
							break;
						case 4:
							s4 = 属性4.属性类型 + "000" + 属性4.属性数量;
							break;
						case 5:
							s4 = 属性4.属性类型 + "00" + 属性4.属性数量;
							break;
						}
					}
				}
				byte[] bytes = BitConverter.GetBytes(int.Parse(s));
				byte[] bytes2 = BitConverter.GetBytes(int.Parse(s2));
				byte[] bytes3 = BitConverter.GetBytes(int.Parse(s3));
				byte[] bytes4 = BitConverter.GetBytes(int.Parse(s4));
				byte[] 物品 = this.物品;
				Buffer.BlockCopy(bytes, 0, 物品, 20, 4);
				Buffer.BlockCopy(bytes2, 0, this.物品, 24, 4);
				Buffer.BlockCopy(bytes3, 0, this.物品, 28, 4);
				Buffer.BlockCopy(bytes4, 0, this.物品, 32, 4);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "合成 设置属性 出错：" + ex);
			}
		}

		public void 得到属性()
		{
			try
			{
				byte[] array = new byte[4];
				byte[] array2 = new byte[4];
				byte[] array3 = new byte[4];
				byte[] array4 = new byte[4];
				Buffer.BlockCopy(物品, 20, array, 0, 4);
				Buffer.BlockCopy(物品, 24, array2, 0, 4);
				Buffer.BlockCopy(物品, 28, array3, 0, 4);
				Buffer.BlockCopy(物品, 32, array4, 0, 4);
				属性1 = new Itimesx(array);
				属性2 = new Itimesx(array2);
				属性3 = new Itimesx(array3);
				属性4 = new Itimesx(array4);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "合成 得到属性 出错：" + ex);
			}
		}

		public void 设置阶段属性()
		{
			try
			{
				string s = "00000000";
				string s2 = "0000000000";
				if (强化数量 != 0)
				{
					string text;
					if (强化数量 >= 10 && 强化数量 < 100)
					{
						string str = 强化类型.ToString();
						string str2 = 强化数量.ToString();
						text = str + "00000" + str2;
					}
					else if (强化数量 >= 100 && 强化数量 < 1000)
					{
						string str3 = 强化类型.ToString();
						string str4 = 强化数量.ToString();
						text = str3 + "0000" + str4;
					}
					else
					{
						string str5 = 强化类型.ToString();
						string str6 = 强化数量.ToString();
						text = str5 + "000000" + str6;
					}
					s = text;
				}
				if (阶段数量 != 0)
				{
					阶段数量--;
					string str7 = 阶段类型.ToString();
					string str8 = 阶段数量.ToString();
					s2 = "100000" + str7 + str8 + "00";
				}
				Buffer.BlockCopy(BitConverter.GetBytes(int.Parse(s) + int.Parse(s2)), 0, 物品, 16, 4);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "合成 设置阶段属性 出错：" + ex);
			}
		}

		public byte[] 得到全局ID()
		{
			byte[] array = new byte[8];
			try
			{
				Buffer.BlockCopy(物品, 0, array, 0, 8);
			}
			catch
			{
			}
			return array;
		}

		public void 强化属性阶段()
		{
			try
			{
				byte[] array = new byte[4];
				Buffer.BlockCopy(物品, 16, array, 0, 4);
				string text = BitConverter.ToInt32(array, 0).ToString();
				switch (text.Length)
				{
				case 2:
					阶段数量 = int.Parse(text.Substring(0, 2));
					break;
				case 6:
					阶段类型 = int.Parse(text.Substring(0, 1));
					if (阶段类型 == 8)
					{
						气功属性类型 = int.Parse(text.Substring(1, 3));
						截取气功属性类型 = int.Parse(text.Substring(2, 2));
						阶段数量 = int.Parse(text.Substring(4, 2));
					}
					else if (World.是否支持扩展物品属性位数 == 0)
					{
						阶段数量 = int.Parse(text.Substring(4, 2));
					}
					else
					{
						阶段数量 = int.Parse(text) - int.Parse(text.Substring(0, 1)) * 100000;
					}
					break;
				case 7:
					阶段类型 = int.Parse(text.Substring(0, 1));
					if (阶段类型 == 2)
					{
						阶段类型 = int.Parse(text.Substring(3, 1));
						break;
					}
					阶段类型 = int.Parse(text.Substring(0, 2));
					if (World.是否支持扩展物品属性位数 == 0)
					{
						阶段数量 = int.Parse(text.Substring(5, 2));
					}
					else
					{
						阶段数量 = int.Parse(text) - int.Parse(text.Substring(0, 2)) * 100000;
					}
					break;
				case 8:
					强化类型 = int.Parse(text.Substring(0, 1));
					强化数量 = int.Parse(text.Substring(text.Length - 3, 3));
					break;
				case 9:
					强化类型 = int.Parse(text.Substring(0, 2));
					强化数量 = int.Parse(text.Substring(text.Length - 3, 3));
					break;
				case 10:
					阶段类型 = int.Parse(text.Substring(6, 1));
					阶段数量 = int.Parse(text.Substring(7, 1)) + 1;
					强化类型 = int.Parse(text.Substring(2, 1));
					强化数量 = int.Parse(text.Substring(text.Length - 2, 2));
					break;
				case 3:
				case 4:
				case 5:
					break;
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "合成 强化属性阶段 出错：" + ex);
			}
		}
	}
}
