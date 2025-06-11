using Authentication;
using Core;
using Database;
using GameSystems;
using ServerManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Threading.Locking;
using UI;

namespace Network.Clients
{
	public class SockClient : IDisposable
	{
		private SevConnClass SevConn;

		private bool disposed;

		private bool isRunning;

        public ServerInfo ServerInfo { get; set; }
        public string ServerId { get; set; }           // ID ของเซิร์ฟเวอร์
        public int MaxOnline { get; set; }             // จำนวนผู้เล่นสูงสุด  
        public int CurrentOnline => World.OnlineCount(ServerId); // ผู้เล่นออนไลน์ปัจจุบัน

        public bool Running => isRunning;

		public SockClient(ServerInfo SI)
		{
			disposed = false;
			isRunning = false;
			SI.Client = this;
			ServerInfo = SI;
			using (new Lock(World.ConnectedServers, "ServerlistLock"))
			{
				if (!InList(ServerInfo.ConnId))
				{
					World.ConnectedServers.Add(ServerInfo.ConnId, this);
				}
				else
				{
					Dispose();
				}
			}
		}

		private bool InList(IntPtr key)
		{
			SockClient value;
			return World.ConnectedServers.TryGetValue(key, out value);
		}

		public void Logout(IntPtr connId)
		{
			try
			{
				World.ServerDisconnect(ServerId );
				World.ConnectedServers.Remove(connId);
                MainForm.WriteLine(2, $"เซิร์ฟเวอร์ถูกตัดการเชื่อมต่อ - ID: {ServerId}");
            }
			catch (Exception ex)
			{
                MainForm.WriteLine(1, $"ข้อผิดพลาดการ logout เซิร์ฟเวอร์: {ex.Message}");
            }
		}

        public void Dispose()
        {
            if (disposed) return;

            disposed = true;
            try
            {
                ServerInfo?.Server?.Disconnect(ServerInfo.ConnId);
                if (ServerInfo != null)
                {
                    ServerInfo.Client = null;
                    ServerInfo = null;
                }
            }
            catch (Exception ex)
            {
                MainForm.WriteLine(1, $"ข้อผิดพลาดการ dispose: {ex.Message}");
            }
        }

        private bool IsFromGameServer(string ipAddress)
		{
			try
			{
				string[] array = ipAddress.Split(':');
				if (RxjhClass.IsEquals(array[0], "127.0.0.1") || array[0].Contains("192.168."))
				{
					return true;
				}
				foreach (ServerClass server in World.ServerList)
				{
					foreach (ServerXlClass server2 in server.ServerList)
					{
						if (RxjhClass.IsEquals(server2.SERVER_IP, array[0]))
						{
							return true;
						}
					}
				}
			}
			catch
			{
			}
			return false;
		}

		public byte[] ProcessDataReceived(byte[] data, int length)
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
						return null;
					}
					while (true)
					{
						byte[] array2 = new byte[num2];
						Buffer.BlockCopy(data, num + 6, array2, 0, num2);
						num += num2 + 6;
						DataReceived(array2, num2);
						if (num >= length || data[num] != 204 || data[num + 1] != 153)
						{
							break;
						}
						Buffer.BlockCopy(data, num + 2, array, 0, 4);
						num2 = BitConverter.ToInt16(array, 0);
					}
				}
				else if (World.ErrorLoggingEnabled == 1)
				{
					string @string = Encoding.Default.GetString(data);
                    MainForm.WriteLine(4, $"เซิร์ฟเวอร์ยืนยันตัวตนได้รับแพ็คเก็ตผิดรูปแบบ: {data[0]}, {data[1]} | {@string}");

                }
                return null;
			}
			catch (Exception ex)
			{
				if (World.ErrorLoggingEnabled == 1)
				{
                    MainForm.WriteLine(1, $"เซิร์ฟเวอร์ยืนยันตัวตนเกิดข้อผิดพลาด ProcessDataReceived: {ex.Message}");
                }
				return null;
			}
		}

		public byte[] DataReceived(byte[] data, int length)
		{
			int num = 0;
			try
			{
				string @string = Encoding.Default.GetString(data);
				string text = new DESDecryptor().Decrypt(@string);
				string[] array = text.Split('|');
				switch (array[0])
				{
				case "KILLID":
					World.KillList.Add(array[1], new KillTimer
					{
						UserId = array[1],
						ConnectionAttempts  = 5,
						ExpireTime = DateTime.Now.AddMinutes(5.0)
					});
					break;
				case "PVP":
				{
					for (int i = 1; i < array.Length; i++)
					{
						try
						{
							string[] array2 = array[i].Split(';');
							int value = 0;
							if (World.PVPList.TryGetValue(array2[0], out value))
							{
								World.PVPList.Remove(array2[0]);
							}
							World.PVPList.Add(array2[0], int.Parse(array2[1]));
						}
						catch
						{
						}
					}
					if (World.PVPList.Count <= 0)
					{
						break;
					}
					int num2 = 0;
					string text2 = string.Empty;
					foreach (KeyValuePair<string, int> item in World.PVPList.OrderByDescending((pair) => pair.Value))
					{
						if (num2 < 12)
						{
							text2 = text2 + "|" + item.Key;
							num2++;
							continue;
						}
						break;
					}
					foreach (SockClient value14 in World.ConnectedServers.Values)
					{
						value14.Send("PVP" + text2);
					}
					break;
				}
				case "仙魔大战掉线":
					num = 1;
					foreach (SockClient value15 in World.ConnectedServers.Values)
					{
						value15.Send("仙魔大战掉线|" + array[1] + "|" + array[2]);
					}
					break;
				case "移除仙魔大战掉线":
					num = 2;
					foreach (SockClient value16 in World.ConnectedServers.Values)
					{
						value16.Send("移除仙魔大战掉线|" + array[1] + "|" + array[2]);
					}
					break;
				case "仙魔大战进程":
					num = 3;
					foreach (SockClient value17 in World.ConnectedServers.Values)
					{
						value17.Send("仙魔大战进程|" + array[1]);
					}
					break;
				case "仙魔大战人数":
					num = 4;
					foreach (SockClient value18 in World.ConnectedServers.Values)
					{
						value18.Send("仙魔大战人数|" + array[1] + "|" + array[2]);
					}
					break;
				case "发送公告":
					num = 5;
					foreach (SockClient value3 in World.ConnectedServers.Values)
					{
						value3.Send("发送公告|" + array[1] + "|" + array[2]);
					}
					break;
				case "狮吼功":
					num = 6;
					foreach (SockClient value4 in World.ConnectedServers.Values)
					{
						value4.Send("狮吼功|" + array[1] + "|" + array[2] + "|" + array[3]);
					}
					break;
				case "刷怪掉宝":
					num = 7;
					foreach (SockClient value6 in World.ConnectedServers.Values)
					{
						value6.Send("刷怪掉宝|" + array[1] + "|" + array[2] + "|" + array[3]);
					}
					break;
				case "全线提示":
					num = 8;
					foreach (SockClient value5 in World.ConnectedServers.Values)
					{
						value5.Send("全线提示|" + array[1] + "|" + array[2] + "|" + array[3]);
					}
					break;
				case "情侣提示":
					num = 9;
					foreach (SockClient value7 in World.ConnectedServers.Values)
					{
						value7.Send("情侣提示|" + array[1] + "|" + array[2]);
					}
					break;
				case "PK提示":
					num = 10;
					foreach (SockClient value8 in World.ConnectedServers.Values)
					{
						value8.Send("PK提示|" + array[1] + "|" + array[2]);
					}
					break;
				case "开启宝盒":
					num = 11;
					foreach (SockClient value9 in World.ConnectedServers.Values)
					{
						value9.Send("开启宝盒|" + array[1] + "|" + array[2] + "|" + array[3]);
					}
					break;
				case "百宝抽奖":
					num = 12;
					foreach (SockClient value10 in World.ConnectedServers.Values)
					{
						value10.Send("百宝抽奖|" + array[1] + "|" + array[2] + "|" + array[3]);
					}
					break;
				case "更新原服务器":
				{
					num = 13;
					playerS playerS10 = World.QueryPlayer(array[1]);
					if (playerS10 != null)
					{
						playerS10.OriginalServerIndex = int.Parse(array[2]);
						playerS10.OriginalServerIP  = array[3];
						playerS10.OriginalServerPort  = array[4];
						playerS10.OriginalServerID  = int.Parse(array[5]);
					}
					break;
				}
				case "获取服务器列表":
				{
					num = 14;
					_ = array[2];
					string str = array[3];
					_ = array[4];
					_ = array[5];
					bool flag = false;
					ServerClass serverClass = new ServerClass();
					foreach (ServerClass server in World.ServerList)
					{
						foreach (ServerXlClass server2 in server.ServerList)
						{
							if (RxjhClass.IsEquals(server2.SERVER_IP, str))
							{
								serverClass = server;
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (serverClass == null)
					{
						break;
					}
					playerS playerS5 = World.QueryPlayer(array[1]);
					if (playerS5 != null)
					{
						string text5 = "获取服务器列表|" + playerS5.UserId + "|";
						for (int k = 0; k < serverClass.ServerList.Count; k++)
						{
							text5 = text5 + serverClass.ServerList[k].ServerId + "," + serverClass.ServerList[k].SERVER_IP + "," + serverClass.ServerList[k].SERVER_PORT + "," + serverClass.ServerList[k].ServerZId + "|";
						}
						Send(text5.TrimEnd('|'));
					}
					break;
				}
				case "复查用户登陆":
				{
					num = 15;
					Dictionary<string, playerS> dictionary = new Dictionary<string, playerS>();
					string[] array5 = array[1].Split(',');
					if (array5.Length <= 1)
					{
						break;
					}
					for (int j = 0; j < array5.Length; j++)
					{
						try
						{
							string[] playerData = array5[j].Split('-');
							playerS playerS2 = new playerS();
							playerS2.UserId = playerData[0];
							if (playerData.Length >= 2)
							{
								playerS2.UserIp = playerS2.UserIp;
							}
							playerS2.ServerID = ServerId ;
							playerS2.Connection = 0;
							playerS2.BoundAccount = playerData[1];
							playerS2.OfflineAutoFarm = playerData[3];
							playerS2.UserName = playerData[4];
							playerS2.OriginalServerIndex = int.Parse(playerData[5]);
							playerS2.OriginalServerIP  = playerData[6];
							playerS2.OriginalServerPort  = playerData[7];
							playerS2.OriginalServerID  = int.Parse(playerData[8]);
							playerS2.CoinPlazaServerIP  = playerData[9];
							playerS2.CoinPlazaServerPort  = playerData[10];
							playerS2.WorldID = playerData[11];
							playerS2.UserIp = playerData[1];
							if (World.Players.TryGetValue(playerS2.UserId, out var player))
							{
								player.UserIp = playerData[1];
								player.BoundAccount = playerData[1];
								player.OfflineAutoFarm = playerData[3];
								player.UserName = playerData[4];
								player.OriginalServerIndex = int.Parse(playerData[5]);
								player.OriginalServerIP  = playerData[6];
								player.OriginalServerPort  = playerData[7];
								player.OriginalServerID  = int.Parse(playerData[8]);
								player.CoinPlazaServerIP  = playerData[9];
								player.CoinPlazaServerPort  = playerData[10];
								player.WorldID = playerData[11];
								player.GoldSymbol  = playerData[12];
								player.Profession  = playerData[13];
							}
							playerS playerS3 = World.QueryAccountDatabase(playerData[0]);
							if (playerS3 != null)
							{
								playerS3.UserIp = playerData[1];
								playerS3.BoundAccount = playerData[1];
								playerS3.OfflineAutoFarm = playerData[3];
								playerS3.UserName = playerData[4];
								playerS3.OriginalServerIndex = int.Parse(playerData[5]);
								playerS3.OriginalServerIP  = playerData[6];
								playerS3.OriginalServerPort  = playerData[7];
								playerS3.OriginalServerID  = int.Parse(playerData[8]);
								playerS3.CoinPlazaServerIP  = playerData[9];
								playerS3.CoinPlazaServerPort  = playerData[10];
								playerS3.WorldID = playerData[11];
								playerS3.GoldSymbol  = playerData[12];
								playerS3.Profession  = playerData[13];
							}
							dictionary.Add(playerData[0], playerS2);
						}
						catch
						{
						}
					}
					World.VerifyUserLogins(ServerId , dictionary);
					MainForm.WriteLine(3, "เซิร์ฟเวอร์ยืนยันตัวตนได้รับ: ตรวจสอบการเข้าสู่ระบบของผู้ใช้");
					break;
				}
				case "踢出玩家用户":
					try
					{
						num = 16;
						if (World.QueryAndKickPlayer(array[1]))
						{
							Send("踢出玩家成功   ID：   " + array[1]);
						}
						else
						{
							Send("踢出玩家失败   ID：   " + array[1] + "   不在线");
						}
						MainForm.WriteLine(6, $"เตะผู้เล่นออกจากระบบ: {text}");
					}
					catch
					{
                            MainForm.WriteLine(1, $"เตะผู้เล่นออกจากระบบเกิดข้อผิดพลาด: {text}");
                        }
					break;
				case "踢出玩家ID":
					try
					{
						num = 17;
						if (World.QueryAndKickPlayer(array[2]))
						{
							Send("踢出玩家成功   ID：   " + array[1]);
						}
						else
						{
							Send("踢出玩家失败   ID：   " + array[1]);
						}
                            MainForm.WriteLine(6, $"เตะผู้เล่น ID ออกจากระบบ: {text}");
                        }
					catch
					{
                            MainForm.WriteLine(1, $"เตะผู้เล่น ID เกิดข้อผิดพลาด: {text}");
                        }
					break;
				case "用户换线通知":
				{
					num = 18;
					if (array[2] != "1")
					{
						World.QueryAndKickPlayer(array[1]);
						break;
					}
					playerS playerS9 = World.QueryPlayer(array[1]);
					if (playerS9 != null)
					{
						playerS9.PacketChannelSwitch = int.Parse(array[2]);
					}
					if (World.PlayerChannelSwitchNotify(array[1]) == 0)
					{
						Send("用户踢出|" + array[1]);
						World.QueryAndKickPlayer(array[1]);
					}
					break;
				}
				case "用户换线登陆":
				{
					num = 20;
					playerS playerS11 = World.QueryPlayer(array[1]);
					if (playerS11 != null)
					{
						if (playerS11.OfflineAutoFarm == "1")
						{
							Send("OpClient|" + array[4] + "|1");
							return null;
						}
						if (playerS11.Connection == 0)
						{
							if (playerS11.BoundAccount != "NULL")
							{
								Send("用户换线登陆|" + array[1] + "|" + array[2] + "|" + array[3] + "|" + array[4] + "|" + array[5] + "|" + array[6] + "|" + playerS11.BoundAccount + "|" + playerS11.OriginalServerIP  + "|" + playerS11.OriginalServerPort  + "|" + playerS11.CoinPlazaServerIP  + "|" + playerS11.CoinPlazaServerPort  + "|" + playerS11.OriginalServerIndex + "|" + playerS11.OriginalServerID  + "|" + playerS11.PacketChannelSwitch);
							}
							else
							{
								Send("用户换线登陆|" + array[1] + "|" + array[2] + "|" + array[3] + "|" + array[4] + "|" + array[5] + "|" + array[6] + "|" + playerS11.BoundAccount + "|" + array[5] + "|13000|" + array[5] + "|13000|" + playerS11.OriginalServerIndex + "|" + playerS11.OriginalServerID  + "|" + playerS11.PacketChannelSwitch);
							}
							return null;
						}
					}
					else
					{
						playerS playerS12 = World.QueryAccountDatabase(array[1]);
						if (playerS12 == null)
						{
							Send("用户换线登陆|" + array[1] + "|" + array[2] + "|" + array[3] + "|" + array[4] + "|" + array[5] + "|" + array[6] + "|NULL|" + array[5] + "|13000|127.0.0.1|13000|0|" + array[6] + "|" + playerS11.PacketChannelSwitch);
							playerS playerS13 = new playerS();
							playerS13.UserId = array[1];
							playerS13.ServerID = array[6];
							playerS13.WorldID = array[4];
							playerS13.BoundAccount = array[5];
							playerS13.OfflineAutoFarm = "0";
							playerS13.UserName = "NULL";
							playerS13.UserIp = array[5];
							bool lockTaken = false;
							Dictionary<string, playerS> obj2 = new Dictionary<string, playerS>();
							try
							{
								Monitor.Enter(obj2 = World.Players, ref lockTaken);
								if (World.QueryPlayer(array[1]) == null)
								{
									World.Players.Add(array[1], playerS13);
								}
							}
							finally
							{
								if (lockTaken)
								{
									Monitor.Exit(obj2);
								}
							}
							bool lockTaken2 = false;
							try
							{
								Monitor.Enter(obj2 = World.PlayersTemp, ref lockTaken2);
								if (World.QueryAccountDatabase(array[1]) == null)
								{
									World.PlayersTemp.Add(array[1], playerS13);
								}
							}
							finally
							{
								if (lockTaken2)
								{
									Monitor.Exit(obj2);
								}
							}
							return null;
						}
						if (playerS12.OfflineAutoFarm == "0")
						{
							Send("用户换线登陆|" + array[1] + "|" + array[2] + "|" + array[3] + "|" + array[4] + "|" + array[5] + "|" + array[6] + "|" + playerS12.BoundAccount + "|" + playerS12.OriginalServerIP  + "|" + playerS12.OriginalServerPort  + "|" + playerS12.CoinPlazaServerIP  + "|" + playerS12.CoinPlazaServerPort  + "|" + playerS12.OriginalServerIndex + "|" + playerS12.OriginalServerID  + "|" + playerS11.PacketChannelSwitch);
							lock (World.Players)
							{
								playerS12.UserIp = array[5];
								World.Players.Add(array[1], playerS12);
							}
							return null;
						}
					}
					Send("用户踢出|" + array[4]);
					World.QueryAndKickPlayer(array[1]);
					break;
				}
				case "换线登陆":
				{
					num = 21;
					playerS playerS7 = World.QueryAccountDatabase(array[1]);
					if (playerS7 != null)
					{
						playerS7.UserId = array[1];
						playerS7.BoundAccount = array[2];
						playerS7.OfflineAutoFarm = array[6];
						playerS7.UserIp = array[2];
						playerS7.ServerID = array[3];
						playerS7.WorldID = array[4];
					}
					playerS playerS8 = World.QueryPlayer(array[1]);
					if (playerS8 != null)
					{
						playerS8.UserId = array[1];
						playerS8.ServerID = array[3];
						playerS8.WorldID = array[4];
						playerS8.BoundAccount = array[2];
						playerS8.OfflineAutoFarm = array[6];
						playerS8.ChannelSwitchComplete();
						if (array[7].Length > 12)
						{
							Send("更新配置|" + playerS8.UserId + "|" + array[7]);
						}
					}
					else
					{
						Send("用户踢出|" + array[4]);
						World.QueryAndKickPlayer(array[1]);
					}
					break;
				}
				case "用户登陆":
					num = 22;
					if (array.Length == 8)
					{
						SevConn = new SevConnClass();
						SevConn.Server = this;
						SevConn.UserId = array[1];
						SevConn.ServerID = array[3];
						SevConn.WorldID = array[4];
						SevConn.BoundAccount = array[5];
						SevConn.OfflineAutoFarm = array[6];
						if (World.Players.TryGetValue(array[1], out var value13))
						{
							value13.BoundAccount = value13.UserIp;
							value13.OfflineAutoFarm = array[6];
							value13.UserName = array[7];
							SevConn.UserIp = value13.UserIp;
						}
						else
						{
							SevConn.UserIp = array[2];
						}
						playerS playerS4 = World.QueryAccountDatabase(array[1]);
						if (playerS4 != null)
						{
							playerS4.BoundAccount = array[2];
							playerS4.OfflineAutoFarm = array[6];
							playerS4.UserName = array[7];
							playerS4.UserIp = array[2];
							playerS4.ServerID = array[3];
							playerS4.WorldID = array[4];
						}
						World.Connect.Enqueue(SevConn);
					}
                        MainForm.WriteLine(3, $"ผู้ใช้เข้าสู่ระบบ: {text}");
                        break;
				case "用户登出":
					num = 23;
					World.LogoutPlayer(array[1]);
					MainForm.WriteLine(3, $"ผู้ใช้ออกจากระบบ: {text}");
					break;
				case "更新服务器配置":
					num = 24;
					MaxOnline = int.Parse(array[2]);
					MainForm.WriteLine(2, $"อัปเดตการตั้งค่าเซิร์ฟเวอร์: {text}");
					break;
				case "服务器连接登陆":
					num = 25;
					MainForm.WriteLine(2, $"เซิร์ฟเวอร์เชื่อมต่อเข้าสู่ระบบ: {text}");
					num = 26;
					ServerId  = array[1];
					num = 27;
					MaxOnline = int.Parse(array[2]);
					num = 28;
					World.ServerDisconnect(ServerId );
					num = 29;
					MainForm.WriteLine(2, $"เซิร์ฟเวอร์เชื่อมต่อสำเร็จ ID: {array[1]}");
					break;
				case "狮子吼":
					num = 30;
					if (World.lionRoarQueue.Count < World.MaxLionRoarCount)
					{
						World.lionRoarQueue.Enqueue(new LionRoarSystemClass
                        {
							Id  = int.Parse(array[1]),
							UserName = array[2],
							MessageId = World.LionRoarId,
							Content = array[3],
							UserIP = array[4],
							ChannelId  = int.Parse(array[5]),
							MapId = int.Parse(array[6]),
							Style = int.Parse(array[7])
						});
						if (World.LionRoarId >= 127)
						{
							World.LionRoarId = 0;
						}
						else
						{
							World.LionRoarId++;
						}
					}
					else
					{
						Send("狮子吼|NO|" + array[1]);
					}
					break;
				case "传音消息":
					num = 31;
					World.SendPrivateMessage(array[1], array[2], array[3], array[4], int.Parse(array[5]), array[6]);
					break;
				case "帮派消息":
					num = 32;
					World.SendGuildMessage(array[1], array[3]);
					break;
				case "同盟聊天":
					num = 33;
					World.SendAllianceMessage(array[1], array[2], array[3], array[4]);
					break;
				case "全线公告":
					num = 34;
					foreach (SockClient value2 in World.ConnectedServers.Values)
					{
						value2.Send("全线公告|" + array[1] + "|" + array[2] + "|" + array[3]);
					}
					break;
				case "离线挂机":
				{
					num = 35;
					if (World.Players.TryGetValue(array[1], out var value11))
					{
						value11.OfflineAutoFarm = "1";
					}
					value11 = World.QueryAccountDatabase(array[1]);
					if (value11 != null)
					{
						value11.OfflineAutoFarm = "1";
					}
					break;
				}
				case "查人物":
				{
					num = 36;
					num = 37;
					string[] array3 = array[2].Split(';');
					string text3 = string.Empty;
					num = 38;
					string[] array4 = array3;
					string[] array7 = array4;
					foreach (string text4 in array7)
					{
						num = 39;
						if (text4.Length <= 0)
						{
							continue;
						}
						num = 40;
						foreach (playerS item2 in (IEnumerable<playerS>)World.Players.Values)
						{
							num = 41;
							if (string.Compare(text4, item2.UserName) == 0)
							{
								num = 42;
								text3 = text3 + item2.UserName + ";";
							}
						}
					}
					num = 43;
					if (text3.Length > 0)
					{
						num = 44;
						Send("查人物|" + array[1] + "|" + text3);
					}
					break;
				}
				case "更新服务器端口":
				{
					num = 45;
					string s = array[1];
					string sERVER_PORT = array[2];
					foreach (ServerClass server3 in World.ServerList)
					{
						foreach (ServerXlClass server4 in server3.ServerList)
						{
							if (server4.ServerZId == int.Parse(s))
							{
								server4.SERVER_PORT = sERVER_PORT;
							}
						}
					}
					MainForm.WriteLine(2, $"อัปเดตพอร์ตเซิร์ฟเวอร์ ID: {array[1]}{array[2]}");
					break;
				}
				case "StartTV":
				{
					num = 46;
					playerS playerS6 = World.QueryPlayer(array[1]);
					if (playerS6 != null)
					{
						World.OpClient(playerS6.ServerID, playerS6.WorldID, "6");
						Send("OK");
					}
					else
					{
						Send("账号" + array[1] + "不在线");
					}
					Dispose();
					break;
				}
				}
				return null;
			}
			catch (Exception ex)
			{
                MainForm.WriteLine(1, $"เซิร์ฟเวอร์ยืนยันตัวตน DataReceived เกิดข้อผิดพลาด: {ex.Message} | Step: {num}");
                return null;
			}
		}

		public void Send(string message)
		{
			byte[] bytes = Encoding.Default.GetBytes(message);
			SendBytes(bytes, bytes.Length);
		}

		public unsafe void SendBytes(byte[] toSendBuff, int len)
		{
			try
			{
				byte[] array = new byte[len + 6];
				array[0] = 204;
				array[1] = 153;
				Buffer.BlockCopy(BitConverter.GetBytes(len), 0, array, 2, 4);
				Buffer.BlockCopy(toSendBuff, 0, array, 6, len);
				fixed (byte* ptr = array)
				{
					ServerInfo.Server.Send(ServerInfo.ConnId, (IntPtr)ptr, array.Length);
				}
			}
			catch (Exception ex)
			{
                MainForm.WriteLine(4, $"เซิร์ฟเวอร์ยืนยันตัวตนส่งข้อมูลเกิดข้อผิดพลาด: {ex.Message}");
            }
		}

		public void Start()
		{
			isRunning = true;
		}
	}
}
