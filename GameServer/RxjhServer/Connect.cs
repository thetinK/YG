using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;
using RxjhServer.HelperTools;
using RxjhServer.Network;

namespace RxjhServer
{
	public class Connect
	{
		private readonly System.Timers.Timer 自动连接;

		private Socket listenSocket;

		private readonly byte[] dataReceive;

		public Connect()
		{
			dataReceive = new byte[102400];
			自动连接 = new System.Timers.Timer(5000.0);
			自动连接.Elapsed += 自动连接事件;
			自动连接.AutoReset = true;
			自动连接.Enabled = true;
		}

		private void 自动连接事件(object source, ElapsedEventArgs e)
		{
			if (!listenSocket.Connected)
			{
				Sestup();
			}
		}

		public void Sestup()
		{
			try
			{
				IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(World.帐号验证服务器IP), World.帐号验证服务器端口);
				listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				listenSocket.BeginConnect(remoteEP, ConnectCallback, listenSocket);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(2, "连接帐号验证服务器出错 " + World.帐号验证服务器端口 + " IP " + World.帐号验证服务器IP.ToString() + " " + ex.Message);
			}
		}

		public void Dispose()
		{
			if (自动连接 != null)
			{
				自动连接.Enabled = false;
				自动连接.Close();
				自动连接.Dispose();
			}
			try
			{
				listenSocket.Shutdown(SocketShutdown.Both);
			}
			catch
			{
			}
			if (listenSocket != null)
			{
				listenSocket.Close();
			}
			listenSocket = null;
		}

		public void 复查用户登陆()
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (NetState value9 in World.ConnectionList.Values)
				{
					string value = "NULL";
					int value2 = 0;
					if (value9.挂机)
					{
						value2 = 1;
					}
					int value3 = 0;
					string value4 = string.Empty;
					string value5 = string.Empty;
					int value6 = 0;
					string value7 = string.Empty;
					string value8 = string.Empty;
					Players players = World.检查玩家世界ID(value9.WorldId);
					if (players != null)
					{
						value = players.UserName;
						value3 = players.原服务器序号;
						value4 = players.原服务器IP;
						value5 = players.原服务器端口.ToString();
						value6 = players.原服务器ID;
						value7 = players.银币广场服务器IP;
						value8 = players.银币广场服务器端口.ToString();
					}
					stringBuilder.Append(value9.Player.Userid);
					stringBuilder.Append("-");
					stringBuilder.Append(value9.ToString());
					stringBuilder.Append("-");
					stringBuilder.Append(value9.绑定帐号);
					stringBuilder.Append("-");
					stringBuilder.Append(value2);
					stringBuilder.Append("-");
					stringBuilder.Append(value);
					stringBuilder.Append("-");
					stringBuilder.Append(value3);
					stringBuilder.Append("-");
					stringBuilder.Append(value4);
					stringBuilder.Append("-");
					stringBuilder.Append(value5);
					stringBuilder.Append("-");
					stringBuilder.Append(value6);
					stringBuilder.Append("-");
					stringBuilder.Append(value7);
					stringBuilder.Append("-");
					stringBuilder.Append(value8);
					stringBuilder.Append("-");
					stringBuilder.Append(value9.WorldId);
					stringBuilder.Append(", ");
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
				}
				World.conn.发送("复查用户登陆|" + stringBuilder);
				GC.Collect();
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "复查用户登陆 错误" + ex.Message);
			}
		}

		private void ConnectCallback(IAsyncResult ar)
		{
			try
			{
				((Socket)ar.AsyncState).EndConnect(ar);
				try
				{
					发送("服务器连接登陆|" + World.ServerID + "|" + World.MaxOnline + "|" + CRC32.GetEXECRC32());
					MainForm.WriteLine(2, "帐号服务器连接成功 端口 " + World.帐号验证服务器端口 + " IP " + World.帐号验证服务器IP);
					listenSocket.BeginReceive(dataReceive, 0, dataReceive.Length, SocketFlags.None, OnReceiveData, this);
					Thread.Sleep(500);
					发送("更新服务器端口|" + World.ServerID + "|" + World.游戏服务器端口2);
					复查用户登陆();
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "验证服务器ConnectCallback出错：" + ex.Message);
				}
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "帐号服务器连接出错：" + ex2.Message);
			}
		}

		public virtual void OnReceiveData(IAsyncResult ar)
		{
			try
			{
				int num = listenSocket.EndReceive(ar);
				if (num > 0 && listenSocket.Connected)
				{
					ProcessDataReceived(dataReceive, num);
					listenSocket.BeginReceive(dataReceive, 0, dataReceive.Length, SocketFlags.None, OnReceiveData, this);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "帐号服务器 接收出错：" + ex.Message);
			}
		}

		public static byte[] Compress(byte[] data)
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, leaveOpen: true);
				gZipStream.Write(data, 0, data.Length);
				gZipStream.Close();
				byte[] array = new byte[memoryStream.Length];
				memoryStream.Position = 0L;
				memoryStream.Read(array, 0, array.Length);
				memoryStream.Close();
				return array;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static string CompressString(string str)
		{
			return Convert.ToBase64String(Compress(Encoding.GetEncoding("UTF-8").GetBytes(str)));
		}

		public void 发送(string msg)
		{
			try
			{
				if (listenSocket != null && listenSocket.Connected)
				{
					byte[] bytes = Encoding.Default.GetBytes(msg);
					Send(bytes, bytes.Length);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "验证服务器发送出错：" + msg + ex.Message);
			}
		}

		public virtual void Send(byte[] toSendBuff, int len)
		{
			try
			{
				byte[] array = new byte[len + 6];
				array[0] = 204;
				array[1] = 153;
				Buffer.BlockCopy(BitConverter.GetBytes(len), 0, array, 2, 4);
				Buffer.BlockCopy(toSendBuff, 0, array, 6, len);
				listenSocket.BeginSend(array, 0, len + 6, SocketFlags.None, OnSended2, this);
			}
			catch (SocketException ex)
			{
				MainForm.WriteLine(1, "帐号服务器 发送出错：" + ex.Message);
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "帐号服务器 发送出错：" + ex2.Message);
			}
		}

		public void OnSended2(IAsyncResult ar)
		{
			try
			{
				listenSocket.EndSend(ar);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "帐号服务器 发送出错：" + ex.Message);
			}
		}

		public void ProcessDataReceived(byte[] data, int length)
		{
			try
			{
				int num = 0;
				if (204 == data[0] && 153 == data[1])
				{
					byte[] array = new byte[4];
					Buffer.BlockCopy(data, 2, array, 0, 4);
					int num2 = BitConverter.ToInt32(array, 0);
					if (length < num2 + 6)
					{
						return;
					}
					while (true)
					{
						byte[] array2 = new byte[num2];
						Buffer.BlockCopy(data, num + 6, array2, 0, num2);
						num += num2 + 6;
						DataReceived(array2, num2);
						if (num < length && data[num] == 204 && data[num + 1] == 153)
						{
							Buffer.BlockCopy(data, num + 2, array, 0, 4);
							num2 = BitConverter.ToInt16(array, 0);
							continue;
						}
						break;
					}
					return;
				}
				MainForm.WriteLine(1, "LoginServer错包：" + data[0] + " " + data[1]);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "出错：" + ex.Message);
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.Source);
				Console.WriteLine(ex.StackTrace);
			}
		}

		public void DataReceived(byte[] data, int length)
		{
			string @string = Encoding.Default.GetString(data);
			try
			{
				string[] array = @string.Split('|');
				switch (array[0])
				{
				case "OpClient":
					try
					{
						Players players3 = World.检查玩家世界ID(int.Parse(array[1]));
						NetState value;
						if (players3 != null)
						{
							if (players3.Client != null)
							{
								players3.OpClient(int.Parse(array[2]));
							}
						}
						else if (World.ConnectionList.TryGetValue(int.Parse(array[1]), out value))
						{
							if (value.Player != null)
							{
								value.Player.OpClient(int.Parse(array[2]));
								break;
							}
							byte[] array2 = Converter.hexStringToByte("AA5512000100BB00040001000000000000000000000055AA");
							Buffer.BlockCopy(BitConverter.GetBytes(int.Parse(array[2])), 0, array2, 10, 2);
							Buffer.BlockCopy(BitConverter.GetBytes(int.Parse(array[1])), 0, array2, 4, 2);
							value.Send(array2, array2.Length);
						}
					}
					catch
					{
					}
					break;
				case "帐号服务器断开连接":
					if (listenSocket != null)
					{
						listenSocket.Close();
					}
					break;
				case "PVP":
				{
					for (int i = 1; i < array.Length; i++)
					{
						Players players2 = World.检查玩家name(array[i]);
						if (players2 != null)
						{
							players2.FLD_VIP = 1;
							players2.更新人物数据(players2);
						}
					}
					break;
				}
				case "仙魔大战掉线":
					if (World.仙魔大战掉线玩家 != null && !World.仙魔大战掉线玩家.ContainsKey(array[1]))
					{
						World.仙魔大战掉线玩家.TryAdd(array[1], array[2]);
					}
					break;
				case "移除仙魔大战掉线":
					if (World.仙魔大战掉线玩家 != null && World.仙魔大战掉线玩家.ContainsKey(array[1]))
					{
						World.仙魔大战掉线玩家.TryRemove(array[1], out var _);
					}
					break;
				case "仙魔大战进程":
					World.仙魔大战进程 = int.Parse(array[1]);
					break;
				case "仙魔大战人数":
					World.仙魔大战正人数 = int.Parse(array[1]);
					World.仙魔大战邪人数 = int.Parse(array[2]);
					break;
				case "获取服务器列表":
				{
					Players players4 = World.检查玩家(array[1]);
					if (players4 != null)
					{
						for (int j = 2; j < array.Length - 1; j++)
						{
							players4.更新服务器列表(array[j]);
						}
					}
					break;
				}
				case "用户登陆":
					用户登陆(int.Parse(array[2]), array[1], array[3], array[4], array[5], array[6], array[7], array[8], array[9]);
					break;
				case "更新配置":
					更新配置(array[1], array[2]);
					break;
				case "用户换线登陆":
					MainForm.WriteLine(1, "收到LS：" + @string);
					用户换线登陆(int.Parse(array[4]), array[1], array[2], array[3], array[7], array[8], array[9], array[10], array[11], array[12], array[13], array[6], array[14]);
					break;
				case "用户踢出":
					if (array[1].Length != 0)
					{
						用户踢出(int.Parse(array[1]));
					}
					break;
				case "用户踢出ID":
					if (array[1].Length != 0)
					{
						用户踢出ID(array[1]);
					}
					break;
				case "发送公告":
					发送公告(int.Parse(array[1]), array[2]);
					break;
				case "狮吼功":
					狮吼功(array[1], array[2], array[3]);
					break;
				case "刷怪掉宝":
					刷怪掉宝(array[1], array[2], array[3]);
					break;
				case "情侣提示":
					情侣提示(array[1], array[2]);
					break;
				case "PK提示":
					PK提示(array[1], array[2]);
					break;
				case "开启宝盒":
					开启宝盒(array[1], array[2], array[3]);
					break;
				case "狮子吼":
				{
					NetState value2;
					if (array[1] == "OK")
					{
						World.发送全服狮子吼消息广播数据(int.Parse(array[2]), array[3], int.Parse(array[4]), array[5], int.Parse(array[6]), int.Parse(array[7]), int.Parse(array[8]));
					}
					else if (World.ConnectionList.TryGetValue(int.Parse(array[2]), out value2))
					{
						value2.Player.系统提示("狮子吼列队以满请等待.....");
					}
					break;
				}
				case "同盟聊天":
					if (array[1] == "OK")
					{
						World.发送同盟聊天(array[2], array[3], array[4], int.Parse(array[5]));
					}
					break;
				case "传音消息":
					World.发送传音消息(int.Parse(array[1]), array[2], array[3], array[4], int.Parse(array[5]), array[6]);
					break;
				case "帮派消息":
				{
					byte[] array3 = strToToHexByte(array[2]);
					World.发送帮派消息(array[1], array3, array3.Length);
					break;
				}
				case "全线公告":
					全线发送公告(int.Parse(array[1]), array[2], array[3]);
					foreach (Players value3 in World.AllConnectedPlayers.Values)
					{
						if (World.是否开启共用银币市场 == 1 && int.Parse(array[1]) != 1)
						{
							if (array[3] == "势力战" && value3.Player_Job_leve >= 2)
							{
								value3.活动邀请银币市场();
							}
							if (array[3] == "攻城战" && value3.宣告攻城 != 0)
							{
								value3.活动邀请银币市场();
							}
							if (array[3] == "仙魔大战" && value3.Player_Job_leve >= 2)
							{
								value3.活动邀请银币市场();
							}
							if (array[3] == "帮派战" && value3.帮派名字 != string.Empty)
							{
								value3.活动邀请银币市场();
							}
						}
						World.活动开启中 = int.Parse(array[1]);
					}
					break;
				case "全线提示":
					全线提示(array[1], array[2], array[3]);
					break;
				case "限制用户":
				{
					Players players = World.检查玩家世界ID(int.Parse(array[1]));
					if (players != null)
					{
						if (array[2] == "0")
						{
							players.LS_降低_暴率百分比 = (double)int.Parse(array[3]) * 0.01;
						}
						if (array[2] == "1")
						{
							players.LS_降低_经验百分比 = (double)int.Parse(array[3]) * 0.01;
						}
						if (array[2] == "2")
						{
							players.LS_降低_历练百分比 = (double)int.Parse(array[3]) * 0.01;
						}
						if (array[2] == "3")
						{
							players.LS_降低_金钱百分比 = (double)int.Parse(array[3]) * 0.01;
						}
					}
					break;
				}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "验证服务器接收出错：" + @string + ex.Message);
			}
		}

		private static byte[] strToToHexByte(string hexString)
		{
			hexString = hexString.Replace(" ", string.Empty);
			if (hexString.Length % 2 != 0)
			{
				hexString += " ";
			}
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
			}
			return array;
		}

		public void 更新配置(string userid, string date)
		{
			Players players = World.检查玩家(userid);
			if (players != null)
			{
				if (players.快捷栏.Contains(1008000044))
				{
					players.人物追加最大_HP += 300;
				}
				if (players.快捷栏.Contains(1008000045))
				{
					players.人物追加最大_MP += 200;
				}
				if (!players.是否更新配置)
				{
					byte[] array = Converter.hexStringToByte(date);
					Buffer.BlockCopy(BitConverter.GetBytes(players.人物全服ID), 0, array, 4, 2);
					players.换线更新配置(array, array.Length);
				}
				players.客户端设置 = date;
				players.更新HP_MP_SP();
			}
		}

		public void 用户登陆(int serverid, string userid, string txt, string 原服务器IP, string 原端口, string 银币IP, string 银币端口, string 服务器序号, string 服务器ID)
		{
			try
			{
				if (World.ConnectionList.TryGetValue(serverid, out var value))
				{
					value.Player.连接登陆2(userid, txt, 原服务器IP, 原端口, 银币IP, 银币端口, 服务器序号, 服务器ID);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "验证服务器用户登陆出错：" + ex.Message);
			}
		}

		public void 用户换线登陆(int WorldID, string userid, string 服务器ID, string 人物序号, string 绑定帐号, string 原服务器IP, string 原服务器端口, string 银币广场IP, string 银币广场端口, string 原服务器序号, string 原服务器ID, string 新服务器ID, string 封包登陆)
		{
			try
			{
				if (World.ConnectionList.TryGetValue(WorldID, out var value))
				{
					value.Player.换线账号登陆(userid, int.Parse(服务器ID), int.Parse(人物序号), WorldID, 绑定帐号, 原服务器IP, 原服务器端口, 银币广场IP, 银币广场端口, 原服务器序号, 原服务器ID, 新服务器ID, 封包登陆);
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "验证用户换线登陆：" + ex.Message);
			}
		}

		public void 狮吼功(string name, string txt, string 线路)
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					value?.系统提示(txt, 21, name + "「" + 线路 + "线」");
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送狮吼功出错：" + ex.Message);
			}
		}

		public void 刷怪掉宝(string name, string txt, string 线路)
		{
			try
			{
				World.GlobalNotification("公告", 6, txt);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送刷怪掉宝出错：" + ex.Message);
			}
		}

		public void 全线提示(string name, string txt, string 线路)
		{
			try
			{
				World.GlobalNotification("活动", 6, txt);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送刷怪掉宝出错：" + ex.Message);
			}
		}

		public void 情侣提示(string name, string txt)
		{
			try
			{
				World.GlobalNotification("情侣提示", 20, txt);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送情侣提示出错：" + ex.Message);
			}
		}

		public void PK提示(string name, string txt)
		{
			try
			{
				World.PK全局提示("PK提示", 3, txt);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送PK提示出错：" + ex.Message);
			}
		}

		public void 开启宝盒(string name, string txt, string 线路)
		{
			try
			{
				World.GlobalNotification("公告", 10, txt);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送开启宝盒出错：" + ex.Message);
			}
		}

		public void 发送公告(int ggid, string txt)
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value != null)
					{
						switch (ggid)
						{
						case 0:
							value.系统公告(txt);
							break;
						case 1:
							value.系统滚动公告(txt);
							break;
						case 2:
							value.系统提示(txt, 10, "系统提示");
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送公告出错：" + ex.Message);
			}
		}

		public void 全线发送公告(int ggid, string txt, string txt2)
		{
			try
			{
				foreach (Players value in World.AllConnectedPlayers.Values)
				{
					if (value != null)
					{
						switch (ggid)
						{
						case 0:
							value.系统公告(txt);
							break;
						case 1:
							value.横幅公告(txt);
							break;
						case 2:
							value.系统提示(txt, 10, "系统提示");
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "发送公告出错：" + ex.Message);
			}
		}

		public void 用户踢出(int WorldID)
		{
			try
			{
				Players players = World.检查玩家世界ID(WorldID);
				string text = string.Empty;
				string text2 = string.Empty;
				string text3 = string.Empty;
				if (players != null)
				{
					text = players.Userid;
					text2 = players.UserName;
					text3 = players.Client.ToString();
					if (players.Client.假人)
					{
						players.Client.DisposedOffline();
						World.假人数量--;
						if (World.假人数量 < 0)
						{
							World.假人数量 = 0;
						}
						World.CloudAfkCount--;
						if (World.CloudAfkCount < 0)
						{
							World.CloudAfkCount = 0;
						}
					}
					if (players.Client.挂机)
					{
						players.Client.DisposedOffline();
						World.OfflineCount--;
						if (World.OfflineCount < 0)
						{
							World.OfflineCount = 0;
						}
					}
					else
					{
						players.Client.Dispose();
					}
				}
				MainForm.WriteLine(3, "用户踢出 [" + text + "]-[" + text2 + "]" + text3);
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "验证服务器用户踢出出错：" + WorldID + " " + ex.Message);
			}
		}

		public void 用户踢出ID(string userid)
		{
			try
			{
				Players players = World.检查玩家(userid);
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				if (players == null)
				{
					return;
				}
				string userid2 = players.Userid;
				string userName = players.UserName;
				players.Client.ToString();
				if (players.Client.假人)
				{
					players.Client.DisposedOffline();
					World.假人数量--;
					if (World.假人数量 < 0)
					{
						World.假人数量 = 0;
					}
					World.CloudAfkCount--;
					if (World.CloudAfkCount < 0)
					{
						World.CloudAfkCount = 0;
					}
				}
				if (players.Client.挂机)
				{
					players.Client.DisposedOffline();
					World.OfflineCount--;
					if (World.OfflineCount < 0)
					{
						World.OfflineCount = 0;
					}
				}
				else
				{
					players.OpClient(1);
					players.kickidlog("玩家重复登陆 - 用户踢出ID()");
					players.Logout();
					players.Client.Dispose();
				}
				World.conn.发送("踢出玩家ID|" + World.ServerID + "|" + userid);
				MainForm.WriteLine(3, "玩家重复登陆 - 用户踢出ID [" + players.Userid + "]-[" + players.UserName + "]" + players.Client.ToString());
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "验证服务器用户踢出出错：" + userid + " " + ex.Message);
			}
		}
	}
}
