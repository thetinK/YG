using Authentication;
using Database;
using GameSystems;
using Network.Clients;
using Network.Servers;
using Network.TCP;
using Security.IPManagement;
using Security.MultiBoxing;
using ServerManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using Threading;
using UI;
using Utilities;

namespace Core
{
	public class World
	{
		public static ThreadSafeDictionary<int, NetState> ConnectLst = new ThreadSafeDictionary<int, NetState>();

		public static ThreadSafeDictionary<IntPtr, SockClient> ConnectedServers = new ThreadSafeDictionary<IntPtr, SockClient>();

		public static Dictionary<string, playerS> Players = new Dictionary<string, playerS>();

		public static Dictionary<string, playerS> PlayersTemp = new Dictionary<string, playerS>();

		public static Queue m_Disposed = Queue.Synchronized(new Queue());

		public static Queue Connect = Queue.Synchronized(new Queue());

		public static Queue lionRoarQueue = Queue.Synchronized(new Queue());

		public static int LionRoarId = 0;

		public static int MaxLionRoarCount = 100;

		public static Dictionary<string, DbClass> Db = new Dictionary<string, DbClass>();

		public static List<ServerClass> ServerList = new List<ServerClass>();

		public static List<IPAddress> BlockedIpList = new List<IPAddress>();

		public static int ServerCount = 0;

		public static int ServerIDStart = 1;

		public static string SocketState = "Stoped";

		public static Dictionary<string, int> PVPList = new Dictionary<string, int>();

		public static Dictionary<string, KillTimer> KillList = new Dictionary<string, KillTimer>();

		public static Dictionary<string, RunMoreClass> RunMoreClass = new Dictionary<string, RunMoreClass>();

		public static int GatewayServerPort = 50200;

		public static int AccountVerificationServerPort = 55970;

		public static int AttackServerPort = 55980;

		public static int GameLoginServerPort = 1300;

		public static int GameLoginServerPort1 = 1300;

		public static int MaxGameLoginConnections = 100;

		public static int MaxLoginConnectionTime = 1000;

		public static string PartitionIDs = "";

		public static int IPBlocking = 0;

		public static int RapidConnectionLimit = 5;

		public static int RapidConnectionTimeLimit = 1;

		public static int ver = 1;

		public static int RealChannelSwitch = 0;

		public static string BannedRegions = "";

		public static string BannedIPSegments = "";

		public static string RegistrationWebsiteAddress = "http://rxjh.xwwl.net";

		public static int[] PartitionChannelStatus = new int[12];

		public static string UnbannedRegions = "";

		public static int AutoConnectInterval = 10000;

		public static bool MainSocket = false;

		public static bool DisconnectOnBlock = true;

		public static bool AddToFilterList = true;

		public static bool StopOnBlock = true;

		public static int AutoMultiClientCheck = 0;

		public static int MultiClientAction = 0;

		public static int AllowedMultiClientCount = 0;

		public static int MultiClientCheckEnabled = 0;

		public static int MultiClientActionSecondary = 0;

		public static int MaxMultiClientCount = 0;

        public static bool EnableNodeServer = false;         // แทน 开启节点

        public static int ErrorLoggingEnabled = 0;

		public static Dictionary<int, string> NodeServer = new Dictionary<int, string>();

		public static byte[] NodeServerData = null;

		public static string GameServerIP = "127.0.0.1";

		public static int BufferMultiplier = 1000;

		public static int aaaaaa = 1;

		public static string ServerName;

		public static bool AutoConnect = false;


        public void SetConfig()
        {
            // Load server ports - โหลดพอร์ตเซิร์ฟเวอร์
            AccountVerificationServerPort = GetConfigInt("LoginServer", "帐号验证服务器端口", 55970);
            GatewayServerPort = GetConfigInt("LoginServer", "转发器网关服务端口", 50200);
            GameLoginServerPort = GetConfigInt("LoginServer", "游戏登陆服务器端口", 1300);
            AttackServerPort = GetConfigInt("LoginServer", "AtPort", 55980);

            // Load connection limits - โหลดขอบเขตการเชื่อมต่อ
            MaxGameLoginConnections = GetConfigInt("LoginServer", "游戏登陆端口最大连接数", 10);
            MaxLoginConnectionTime = GetConfigInt("LoginServer", "游戏登陆端口最大连接时间数", 1000);
            RapidConnectionLimit = GetConfigInt("LoginServer", "快速连接限制次数", 5);
            RapidConnectionTimeLimit = GetConfigInt("LoginServer", "快速连接限制时间", 1);

            // Load Lion Roar settings - โหลดการตั้งค่าระบบประกาศ
            MaxLionRoarCount = GetConfigInt("LoginServer", "狮子吼最大数", 100);

            // Load multi-client settings - โหลดการตั้งค่า multi-client
            AllowedMultiClientCount = GetConfigInt("LoginServer", "允许多开数量", 0);
            AutoMultiClientCheck = GetConfigInt("LoginServer", "自动查询多开", 0);
            MultiClientAction = GetConfigInt("LoginServer", "多开查询操作", 0);
            MultiClientCheckEnabled = GetConfigInt("LoginServer", "复查查询多开", 0);
            MultiClientActionSecondary = GetConfigInt("LoginServer", "复查查询操作", 0);
            MaxMultiClientCount = GetConfigInt("LoginServer", "复查多开数量", 0);

            // Load other settings - โหลดการตั้งค่าอื่นๆ
            ver = GetConfigInt("LoginServer", "ver", 1);
            AutoConnect = GetConfigBool("LoginServer", "AutoConnect", false);
            AutoConnectInterval = GetConfigInt("LoginServer", "自动连接时间", 10000);
            BufferMultiplier = GetConfigInt("LoginServer", "缓冲区倍数", 1000);
            EnableNodeServer = GetConfigInt("LoginServer", "开启节点", 0) == 1;
            RealChannelSwitch = GetConfigInt("LoginServer", "真实线路切换", 0);
            ErrorLoggingEnabled = GetConfigInt("LoginServer", "ErrorLoggingEnabled", 0);

            // ✅ เพิ่มการตั้งค่า Database Command Timeout
            int databaseCommandTimeout = GetConfigInt("LoginServer", "DatabaseCommandTimeout", 60);
            DBA.SetCommandTimeout(databaseCommandTimeout);

            // Load string settings - โหลดการตั้งค่าแบบ string
            ServerName = GetConfigString("LoginServer", "服务器名");
            PartitionIDs = GetConfigString("LoginServer", "分区号");
            RegistrationWebsiteAddress = GetConfigString("LoginServer", "注册网站地址", "http://rxjh.xwwl.net");

            try
            {
                // Load partition channel status - โหลดสถานะช่องสัญญาณ
                LoadPartitionChannelStatus();

                // Load database configuration - โหลดการตั้งค่าฐานข้อมูล
                LoadDatabaseConfig();

                // Load server list - โหลดรายการเซิร์ฟเวอร์
                LoadServerList();

                // Load security settings - โหลดการตั้งค่าความปลอดภัย
                LoadSecurityConfig();

                // Load node servers - โหลด node servers
                LoadNodeServers();

                // Load multi-client users - โหลดผู้ใช้ multi-client
                LoadMultiClientUsers();
            }
            catch (Exception ex)
            {
                // เปลี่ยนข้อความให้ชัดเจนขึ้น
                ComprehensiveLogger.WriteError($"Configuration subsection failed: {ex.Message}");
                MainForm.WriteLine(1, $"World.SetConfig subsection error: {ex.Message} - Some features may not work properly.");
            }

            ComprehensiveLogger.WriteSystem("โหลดการตั้งค่าทั้งหมดเสร็จสิ้น");
        }

        // โหลดการตั้งค่าช่องสัญญาณ
        // Load partition channel status
        private void LoadPartitionChannelStatus()
        {
            try
            {
                string channelStatus = GetConfigString("LoginServer", "分区线路状态", "1,1,1,1,1,1,1,1,1,1,1,1");
                string[] statusArray = channelStatus.Split(',');

                for (int i = 0; i < Math.Min(12, statusArray.Length); i++)
                {
                    if (int.TryParse(statusArray[i], out int status))
                    {
                        PartitionChannelStatus[i] = status;
                    }
                    else
                    {
                        PartitionChannelStatus[i] = 1; // Default to active
                    }
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"LoadPartitionChannelStatus failed: {ex.Message}");
                // Initialize with default values
                for (int i = 0; i < 12; i++)
                {
                    PartitionChannelStatus[i] = 1;
                }
            }
        }

        // แก้ไข LoadDatabaseConfig() ใน World.cs
        private void LoadDatabaseConfig()
        {
            try
            {
                Db.Clear();
                string server = GetConfigString("LoginServer", "Server");
                string userName = GetConfigString("LoginServer", "UserName");
                string password = GetConfigString("LoginServer", "PassWord");
                string dataName = GetConfigString("LoginServer", "DataName");

                if (!string.IsNullOrEmpty(server) && !string.IsNullOrEmpty(dataName))
                {
                    // ✅ แก้ไข Connection String - ลบ Command Timeout ออก
                    string connectionString = $"server={server};uid={userName};pwd={password};database={dataName};Connect Timeout=30;Pooling=true;Min Pool Size=5;Max Pool Size=100;";

                    Db.Add("rxjhaccount", new DbClass
                    {
                        ServerDb = "rxjhaccount",
                        SqlConnect = connectionString
                    });

                    ComprehensiveLogger.WriteDatabase("โหลดการตั้งค่าฐานข้อมูลเสร็จสิ้น");
                }
                else
                {
                    ComprehensiveLogger.WriteError("การตั้งค่าฐานข้อมูลไม่ครบถ้วน - Database config incomplete");
                    MainForm.WriteLine(1, "Database configuration incomplete - missing server or database name");
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"LoadDatabaseConfig failed: {ex.Message}");
                MainForm.WriteLine(1, $"Database config error: {ex.Message}");
            }
        }

        // โหลดรายการเซิร์ฟเวอร์
        // Load server list configuration
        private void LoadServerList()
        {
            try
            {
                ServerList.Clear();
                ServerCount = GetConfigInt("LoginServer", "serverCount", 0);

                for (int i = 0; i < ServerCount; i++)
                {
                    var serverClass = new ServerClass
                    {
                        SERVER_NAME = GetConfigString($"server{i}", "servername"),
                        ServerCount = GetConfigInt($"server{i}", "serverCount", 0)
                    };

                    // Load individual servers in this group
                    for (int j = 0; j < serverClass.ServerCount; j++)
                    {
                        string serverConfig = GetConfigString($"server{i}", $"server{j}");
                        if (!string.IsNullOrEmpty(serverConfig))
                        {
                            ParseAndAddServer(serverClass, serverConfig, j);
                        }
                    }

                    // Load special server X
                    string serverXConfig = GetConfigString($"server{i}", "serverX");
                    if (!string.IsNullOrEmpty(serverXConfig))
                    {
                        ParseAndAddServer(serverClass, serverXConfig, 12);
                    }

                    ServerList.Add(serverClass);
                }

                ComprehensiveLogger.WriteSystem($"โหลดรายการเซิร์ฟเวอร์เสร็จสิ้น จำนวน: {ServerCount}");
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"LoadServerList failed: {ex.Message}");
            }
        }

        // แยกและเพิ่มข้อมูลเซิร์ฟเวอร์
        // Parse and add server information
        private void ParseAndAddServer(ServerClass serverClass, string serverConfig, int serverId)
        {
            try
            {
                string[] configParts = serverConfig.Split(',');
                if (configParts.Length >= 5)
                {
                    var serverXlClass = new ServerXlClass
                    {
                        SERVER_NAME = configParts[0],
                        ServerId = serverId,
                        SERVER_IP = configParts[2],
                        SERVER_PORT = configParts[3],
                        ServerZId = int.TryParse(configParts[4], out int zId) ? zId : 0
                    };

                    serverClass.ServerList.Add(serverXlClass);
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"ParseAndAddServer failed: {ex.Message}");
            }
        }

        // โหลดการตั้งค่าความปลอดภัย
        // Load security configuration
        private void LoadSecurityConfig()
        {
            try
            {
                IPBlocking = GetConfigInt("LoginServer", "封IP", 0);
                BannedRegions = GetConfigString("LoginServer", "封地区");
                UnbannedRegions = GetConfigString("LoginServer", "解地区");
                BannedIPSegments = GetConfigString("LoginServer", "封IP段");

                ComprehensiveLogger.WriteSecurity("โหลดการตั้งค่าความปลอดภัยเสร็จสิ้น");
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"LoadSecurityConfig failed: {ex.Message}");
            }
        }

        public void LoadMultiClientUsers()
		{
			RunMoreClass.Clear();
			DataTable dBToDataTable = DBA.GetDBToDataTable("SELECT    *    FROM    TBL_MORE_RUN", "rxjhaccount");
			if (dBToDataTable == null)
			{
				return;
			}
			if (dBToDataTable.Rows.Count == 0)
			{
				MainForm.WriteLine(2, "โหลดข้อมูลผู้ใช้ Multi-Client เสร็จสิ้น - ไม่มีข้อมูล");
			}
			else
			{
				for (int i = 0; i < dBToDataTable.Rows.Count; i++)
				{
					RunMoreClass runMoreClass = new RunMoreClass();
					runMoreClass.PID = dBToDataTable.Rows[i]["FLD_PID"].ToString();
					runMoreClass.Time = (DateTime)dBToDataTable.Rows[i]["FLD_TIME"];
					runMoreClass.Number = (int)dBToDataTable.Rows[i]["FLD_NUMBER"];
					if (!RunMoreClass.ContainsKey(runMoreClass.PID))
					{
						RunMoreClass.Add(runMoreClass.PID, runMoreClass);
					}
				}
				MainForm.WriteLine(2, "โหลดข้อมูลผู้ใช้ Multi-Client เสร็จสิ้น - จำนวน:" + dBToDataTable.Rows.Count);
			}
			dBToDataTable.Dispose();
		}

        #region Helper Methods - เมธอดช่วย

        // อ่านค่า integer จากไฟล์ config
        // Read integer value from config file
        private int GetConfigInt(string section, string key, int defaultValue = 0)
        {
            string value = Config.IniReadValue(section, key);
            return string.IsNullOrEmpty(value) ? defaultValue : int.TryParse(value, out int result) ? result : defaultValue;
        }

        // อ่านค่า boolean จากไฟล์ config
        // Read boolean value from config file
        private bool GetConfigBool(string section, string key, bool defaultValue = false)
        {
            string value = Config.IniReadValue(section, key);
            return string.IsNullOrEmpty(value) ? defaultValue : bool.TryParse(value, out bool result) ? result : defaultValue;
        }

        // อ่านค่า string จากไฟล์ config
        // Read string value from config file
        private string GetConfigString(string section, string key, string defaultValue = "")
        {
            string value = Config.IniReadValue(section, key);
            return string.IsNullOrEmpty(value) ? defaultValue : value.Trim();
        }

        // สร้าง Random Seed ที่ปลอดภัย
        // Generate secure random seed
        public static int GetRandomSeed()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[4];
                rng.GetBytes(bytes);
                return BitConverter.ToInt32(bytes, 0);
            }
        }

        #endregion
        public static long IpToInt(string ip)
		{
			char[] separator = new char[1] { '.' };
			string[] array = ip.Split(separator);
			return long.Parse(array[0]) << 24 | long.Parse(array[1]) << 16 | long.Parse(array[2]) << 8 | long.Parse(array[3]);
		}

        // โหลด Node Servers
        // Load node servers configuration
        private void LoadNodeServers()
        {
            try
            {
                if (!EnableNodeServer) return;

                NodeServer.Clear();
                int nodeCount = GetConfigInt("NodeServer", "ServerCount", 0);

                for (int i = 0; i < nodeCount; i++)
                {
                    string nodeAddress = GetConfigString("NodeServer", $"ServerAddr{i + 1}");
                    if (!string.IsNullOrEmpty(nodeAddress))
                    {
                        NodeServer.Add(i, nodeAddress);
                    }
                }

                // Build node server data array
                BuildNodeServerData();

                ComprehensiveLogger.WriteSystem($"โหลด Node Servers เสร็จสิ้น จำนวน: {NodeServer.Count}");
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"LoadNodeServers failed: {ex.Message}");
            }
        }

        private void BuildNodeServerData()
        {
            try
            {
                if (!EnableNodeServer || NodeServer.Count == 0) return;

                NodeServerData = new byte[(NodeServer.Count + 1) * 4 + 2];
                NodeServerData[0] = EnableNodeServer ? (byte)1 : (byte)0;

                int validNodeCount = 0;
                foreach (string nodeAddress in NodeServer.Values)
                {
                    long ipAsLong = ConvertIPToLong(nodeAddress);
                    if (ipAsLong > 0)
                    {
                        Buffer.BlockCopy(BitConverter.GetBytes(ipAsLong), 0, NodeServerData, 2 + validNodeCount * 4, 4);
                        validNodeCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"BuildNodeServerData failed: {ex.Message}");
            }
        }

        // แปลง IP Address เป็น Long
        // Convert IP address to long integer
        private long ConvertIPToLong(string ipAddress)
        {
            try
            {
                if (IPAddress.TryParse(ipAddress, out IPAddress ip))
                {
                    byte[] bytes = ip.GetAddressBytes();
                    if (bytes.Length == 4)
                    {
                        return (long)(bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
                    }
                }
                else
                {
                    // Try to resolve hostname
                    IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
                    if (hostEntry.AddressList.Length > 0)
                    {
                        byte[] bytes = hostEntry.AddressList[0].GetAddressBytes();
                        if (bytes.Length == 4)
                        {
                            return (long)(bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"ConvertIPToLong failed for {ipAddress}: {ex.Message}");
            }
            return 0;
        }

        public static void OpClient(string ServerID, string WorldID, string OpCode)
		{
			if (WorldID == null || WorldID == "" || ServerID == null)
			{
				return;
			}
			foreach (SockClient value in ConnectedServers.Values)
			{
				if (RxjhClass.IsEquals(value.ServerId , ServerID))
				{
					value.Send("OpClient|" + WorldID + "|" + OpCode);
					break;
				}
			}
		}

		public static NetState GetAccountData(int wid)
		{
			if (!ConnectLst.TryGetValue(wid, out var value))
			{
				return null;
			}
			return value;
		}

		public static void ProcessSerQueue()
		{
			try
			{
				int num = 0;
				while (num < 200 && Connect.Count > 0)
				{
					num++;
					SevConnClass sevConnClass = (SevConnClass)Connect.Dequeue();
					try
					{
						if (sevConnClass.UserId.IndexOf(' ', sevConnClass.UserId.Length - 1) != -1)
						{
							MainForm.WriteLine(1, "ผู้ใช้เข้าสู่ระบบผิดกฎหมาย[" + sevConnClass.UserId + "]" + sevConnClass.UserIp);
						}
						else
						{
							if (!QueryAndKickPlayer(sevConnClass.UserId))
							{
								playerS playerS2 = QueryPlayer(sevConnClass.UserId);
								if (playerS2 == null)
								{
									continue;
								}
								string smsg = string.Empty;
								int num2 = QueryMultiClientCount(sevConnClass.BoundAccount, out smsg);
								MainForm.WriteLine(100, "IP[" + sevConnClass.UserIp + "]  Multi-Client ปัจจุบัน:：" + num2 + "  อนุญาต：" + AllowedMultiClientCount);
								if (num2 > AllowedMultiClientCount)
								{
									bool flag = false;
									if (RunMoreClass.TryGetValue(sevConnClass.BoundAccount, out var value) && DateTime.Now < value.Time && num2 <= value.Number)
									{
										flag = true;
									}
									if (!flag)
									{
										MainForm.WriteLine(6, "用户非法多开[" + sevConnClass.UserId + "]" + sevConnClass.BoundAccount + "其他多开账号：" + smsg);
										switch (MultiClientAction)
										{
										case 1:
											RxjhClass.SetUserIdONLINE(playerS2.UserId);
											KickPlayerFromServer(sevConnClass.ServerID, sevConnClass.WorldID);
											lock (Players)
											{
												Players.Remove(playerS2.UserId);
											}
											playerS2.npcTimer.Dispose();
											return;
										case 2:
											lock (Players)
											{
												foreach (playerS item in (IEnumerable<playerS>)Players.Values)
												{
													if (RxjhClass.IsEquals(item.BoundAccount, sevConnClass.BoundAccount) && int.Parse(item.OfflineAutoFarm) == 0)
													{
														RxjhClass.SetUserIdONLINE(playerS2.UserId);
														KickPlayerFromServer(sevConnClass.ServerID, sevConnClass.WorldID);
														lock (Players)
														{
															Players.Remove(item.UserId);
														}
														item.npcTimer.Dispose();
														break;
													}
												}
											}
											playerS2.Connection = 0;
											playerS2.ServerID = sevConnClass.ServerID;
											playerS2.WorldID = sevConnClass.WorldID;
											playerS2.BoundAccount = sevConnClass.BoundAccount;
											sevConnClass.Server.Send("用户登陆|" + sevConnClass.UserId + "|" + sevConnClass.WorldID + "|不在线|" + playerS2.OriginalServerIP  + "|" + playerS2.OriginalServerPort  + "|" + playerS2.CoinPlazaServerIP  + "|" + playerS2.CoinPlazaServerPort  + "|" + playerS2.OriginalServerIndex + "|" + playerS2.OriginalServerID );
											break;
										}
									}
									else
									{
										MainForm.WriteLine(6, "白名单用户多开[" + sevConnClass.UserId + "]" + sevConnClass.BoundAccount + "其他多开账号：" + smsg);
										playerS2.Connection = 0;
										playerS2.ServerID = sevConnClass.ServerID;
										playerS2.WorldID = sevConnClass.WorldID;
										playerS2.BoundAccount = sevConnClass.BoundAccount;
										sevConnClass.Server.Send("用户登陆|" + sevConnClass.UserId + "|" + sevConnClass.WorldID + "|不在线|" + playerS2.OriginalServerIP  + "|" + playerS2.OriginalServerPort  + "|" + playerS2.CoinPlazaServerIP  + "|" + playerS2.CoinPlazaServerPort  + "|" + playerS2.OriginalServerIndex + "|" + playerS2.OriginalServerID );
									}
								}
								else
								{
									playerS2.Connection = 0;
									playerS2.ServerID = sevConnClass.ServerID;
									playerS2.WorldID = sevConnClass.WorldID;
									playerS2.BoundAccount = sevConnClass.BoundAccount;
									sevConnClass.Server.Send("用户登陆|" + sevConnClass.UserId + "|" + sevConnClass.WorldID + "|不在线|" + playerS2.OriginalServerIP  + "|" + playerS2.OriginalServerPort  + "|" + playerS2.CoinPlazaServerIP  + "|" + playerS2.CoinPlazaServerPort  + "|" + playerS2.OriginalServerIndex + "|" + playerS2.OriginalServerID );
								}
								continue;
							}
							lock (Players)
							{
								Players.Remove(sevConnClass.UserId);
							}
							KickPlayerFromServer(sevConnClass.ServerID, sevConnClass.WorldID);
						}
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "ProcessSerQueue()เกิดข้อผิดพลาด:    " + ex.Message);
					}
				}
			}
			catch
			{
			}
		}

		public static int QueryMultiClientCount(string UserNip, out string smsg)
		{
			smsg = "";
			if (AutoMultiClientCheck == 0)
			{
				return 0;
			}
			int num = 0;
			foreach (playerS item in (IEnumerable<playerS>)Players.Values)
			{
				if (item != null && RxjhClass.IsEquals(item.BoundAccount, UserNip) && item.OfflineAutoFarm == "0")
				{
					smsg += item.UserId;
					smsg += "        ";
					num++;
				}
			}
			smsg += UserNip;
			return num;
		}

		public static void ProcessLionRoarQueue()
		{
			if (lionRoarQueue.Count <= 0)
			{
				return;
			}
			LionRoarSystemClass message = (LionRoarSystemClass)lionRoarQueue.Dequeue();
            string broadcastData = "LionRoar|OK|" + message.Id + "|" + message.UserName + "|" +
                      message.MessageId + "|" + message.Content + "|" +
                      message.ChannelId + "|" + message.MapId + "|" + message.Style;
            foreach (SockClient client in ConnectedServers.Values)
			{
				client.Send(broadcastData);
			}
		}

        // ส่งข้อความส่วนตัว (แทน 发送传音消息)
        // Send private message
        public static void SendPrivateMessage(string playerFullId, string fromName, string toName, string message, int messageType, string hexData)
        {
            try
            {
                string messageData = $"传音消息|{playerFullId}|{fromName}|{toName}|{message}|{messageType}|{hexData}";

                Parallel.ForEach(ConnectedServers.Values, server =>
                {
                    try
                    {
                        server.Send(messageData);
                    }
                    catch (Exception ex)
                    {
                        ComprehensiveLogger.WriteError($"SendPrivateMessage failed for server {server.ServerId}: {ex.Message}");
                    }
                });

                ComprehensiveLogger.WriteActivity($"ส่งข้อความส่วนตัว: {fromName} -> {toName}");
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"SendPrivateMessage failed: {ex.Message}");
            }
        }

        // ส่งข้อความกิลด์ (แทน 发送帮派消息)
        // Send guild message
        public static void SendGuildMessage(string guildName, string hexData)
        {
            try
            {
                string messageData = $"帮派消息|{guildName}|{hexData}";

                Parallel.ForEach(ConnectedServers.Values, server =>
                {
                    try
                    {
                        server.Send(messageData);
                    }
                    catch (Exception ex)
                    {
                        ComprehensiveLogger.WriteError($"SendGuildMessage failed for server {server.ServerId}: {ex.Message}");
                    }
                });

                ComprehensiveLogger.WriteActivity($"ส่งข้อความกิลด์: {guildName}");
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"SendGuildMessage failed: {ex.Message}");
            }
        }

        // ส่งข้อความพันธมิตร (แทน 发送同盟消息)
        // Send alliance message
        public static void SendAllianceMessage(string guildName, string username, string message, string serverGroup)
        {
            try
            {
                if (!int.TryParse(serverGroup, out int groupId))
                {
                    ComprehensiveLogger.WriteError($"Invalid server group: {serverGroup}");
                    return;
                }

                string messageData = $"同盟聊天|OK|{guildName}|{username}|{message}|{groupId}";

                Parallel.ForEach(ConnectedServers.Values, server =>
                {
                    try
                    {
                        server.Send(messageData);
                    }
                    catch (Exception ex)
                    {
                        ComprehensiveLogger.WriteError($"SendAllianceMessage failed for server {server.ServerId}: {ex.Message}");
                    }
                });

                ComprehensiveLogger.WriteActivity($"ส่งข้อความพันธมิตร: {guildName} - {username}");
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"SendAllianceMessage failed: {ex.Message}");
            }
        }

        // ส่งข้อความกิจกรรม (แทน 发送活动消息)
        // Send activity message
        public static void SendActivityMessage(string guildName, string username, string message, string serverGroup)
        {
            try
            {
                if (!int.TryParse(serverGroup, out int groupId))
                {
                    ComprehensiveLogger.WriteError($"Invalid server group: {serverGroup}");
                    return;
                }

                string messageData = $"活动开启|势力战|{guildName}|{username}|{message}|{groupId}";

                Parallel.ForEach(ConnectedServers.Values, server =>
                {
                    try
                    {
                        server.Send(messageData);
                    }
                    catch (Exception ex)
                    {
                        ComprehensiveLogger.WriteError($"SendActivityMessage failed for server {server.ServerId}: {ex.Message}");
                    }
                });

                ComprehensiveLogger.WriteActivity($"ส่งข้อความกิจกรรม: {guildName} - {username}");
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"SendActivityMessage failed: {ex.Message}");
            }
        }

        public static void NotifyPortChange()
		{
			if (GatewayServer.clients == null)
			{
				return;
			}
			foreach (GatewaySocketClient client in GatewayServer.clients)
			{
				client.Sendd("更新服务器端口|" + GameLoginServerPort1);
			}
		}

		public static void 端口更换通知(string serverid)
		{
			if (GatewayServer.clients == null)
			{
				return;
			}
			foreach (GatewayHandler client in GatewayServer.clients)
			{
				if (RxjhClass.IsEquals(client.ServerId, serverid))
				{
					client.Sendd("更新服务器端口|" + GameLoginServerPort1);
				}
			}
		}

		public static int PlayerChannelSwitchNotify(string Userid)
		{
			int result = 0;
			lock (Players)
			{
				foreach (playerS item in (IEnumerable<playerS>)Players.Values)
				{
					if (RxjhClass.IsEquals(item.UserId, Userid) && item.Connection == 0)
					{
						item.SwitchChannel();
						return int.Parse(item.WorldID);
					}
				}
				return result;
			}
		}

		public static int 玩家换线完成(string Userid)
		{
			int result = 0;
			lock (Players)
			{
				foreach (playerS item in (IEnumerable<playerS>)Players.Values)
				{
					if (RxjhClass.IsEquals(item.UserId, Userid) && item.Connection == 0)
					{
						item.ChannelSwitching = 0;
						return int.Parse(item.WorldID);
					}
				}
				return result;
			}
		}

		public static void ProcessDisposedQueue()
		{
			try
			{
				int num = 0;
				while (num < 200 && m_Disposed.Count > 0)
				{
					num++;
					NetState netState = (NetState)m_Disposed.Dequeue();
					try
					{
						netState.delWorldIdd();
					}
					catch (Exception ex)
					{
						MainForm.WriteLine(1, "ProcessDisposedQueue()เกิดข้อผิดพลาด:    " + ex.Message);
					}
				}
			}
			catch
			{
			}
		}

		public static bool LoginPlayer(string Userid)
		{
			try
			{
				if (QueryPlayer(Userid) == null)
				{
					playerS playerS2 = new playerS();
					playerS2.UserId = Userid;
					playerS2.Connection = 1;
					lock (Players)
					{
						Players.Add(Userid, playerS2);
					}
				}
				if (QueryAccountDatabase(Userid) == null)
				{
					playerS playerS3 = new playerS();
					playerS3.UserId = Userid;
					playerS3.Connection = 1;
					lock (PlayersTemp)
					{
						PlayersTemp.Add(Userid, playerS3);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "World.登录玩家(id)    เกิดข้อผิดพลาด:" + ex.Message);
				return false;
			}
		}

		public static void CheckBannedAccounts()
		{
			RxjhClass.SetUserIdZT();
		}

		public static void LogoutPlayer(string Userid)
		{
			if (QueryPlayer(Userid) == null)
			{
				return;
			}
			RxjhClass.SetUserIdONLINE(Userid);
			lock (Players)
			{
				Players.Remove(Userid);
			}
		}

		public static playerS QueryPlayer(string Userid)
		{
			lock (Players)
			{
				if (Players.TryGetValue(Userid, out var value))
				{
					return value;
				}
			}
			return null;
		}

		public static playerS QueryAccountDatabase(string Userid)
		{
			lock (PlayersTemp)
			{
				if (PlayersTemp.TryGetValue(Userid, out var value))
				{
					return value;
				}
			}
			return null;
		}

		public static bool QueryAndKickPlayer(string Userid)
		{
			lock (Players)
			{
				_ = string.Empty;
				foreach (playerS item in (IEnumerable<playerS>)Players.Values)
				{
					if (RxjhClass.IsEquals(item.UserId, Userid) && item.Connection == 0)
					{
						KickPlayerFromServer(item.ServerID, item.WorldID);
						if (string.Empty != Userid)
						{
							Players.Remove(Userid);
						}
						return true;
					}
				}
			}
			return false;
		}

		public static bool LOGIN踢出玩家(string Userid)
		{
			foreach (playerS item in (IEnumerable<playerS>)Players.Values)
			{
				if (RxjhClass.IsEquals(item.UserId, Userid))
				{
					item.LoginOut = true;
					return true;
				}
			}
			return false;
		}

		public static int OnlineCount(string serverid)
		{
			int num = 0;
			foreach (playerS item in Players.Values)
			{
				if (item.ServerID == serverid)
				{
					num++;
				}
			}
			return num;
		}

		public static void ServerDisconnect(string ServerID)
		{
			try
			{
				if (Players == null)
				{
					return;
				}
				ArrayList arrayList = new ArrayList();
				foreach (playerS item in (IEnumerable<playerS>)Players.Values)
				{
					if (RxjhClass.IsEquals(item.ServerID, ServerID))
					{
						arrayList.Add(item);
					}
				}
				foreach (playerS item2 in arrayList)
				{
					RxjhClass.SetUserIdONLINE(item2.UserId);
					if (item2.npcTimer != null)
					{
						item2.npcTimer.Dispose();
					}
					Players.Remove(item2.UserId);
				}
			}
			catch
			{
			}
		}

		public static SockClient QueryServer(string serverid)
		{
			foreach (SockClient value in ConnectedServers.Values)
			{
				if (RxjhClass.IsEquals(value.ServerId , serverid))
				{
					return value;
				}
			}
			return null;
		}

		public static void KickOtherInstancesOfUser(string uid)
		{
			try
			{
				foreach (SockClient serverConnection in ConnectedServers.Values)
				{
					serverConnection.Send("KICK_USER_BY_ID|" + uid);
				}
			}
			catch (Exception)
			{
			}
		}

		public static void KickPlayerFromServer(string serverid, string userid)
		{
			try
			{
				if (userid == null || userid == "" || serverid == null)
				{
					return;
				}
				foreach (SockClient serverConnection in ConnectedServers.Values)
				{
					if (RxjhClass.IsEquals(serverConnection.ServerId , serverid))
					{
						serverConnection.Send("KICK_USER|" + userid);
						break;
					}
				}
			}
			catch (Exception)
			{
			}
		}

        /*
         * ฟังก์ชัน AddUserRestriction (加入限制用户)
         * วัตถุประสงค์: ส่งคำสั่งจำกัดผู้ใช้ไปยังเซิร์ฟเวอร์เกมที่กำหนด
         * 
         * พารามิเตอร์:
         * - serverId: รหัสเซิร์ฟเวอร์เป้าหมาย
         * - worldId: รหัสโลก/เวิลด์ที่ต้องการจำกัด
         * - type: ประเภทการจำกัด (เช่น 1=แบน, 2=เตือน, 3=จำกัดเวลา)
         * - value: ค่าพารามิเตอร์ (เช่น ระยะเวลาแบน, จำนวนครั้งเตือน)
         * 
         * การทำงาน:
         * 1. ตรวจสอบความถูกต้องของข้อมูลนำเข้า
         * 2. ค้นหาเซิร์ฟเวอร์ที่ต้องการจาก ConnectedServers
         * 3. ส่งคำสั่งในรูปแบบ "限制用户|worldId|type|value"
         * 4. หยุดค้นหาเมื่อพบและส่งเสร็จแล้ว
         * 
         * รูปแบบคำสั่ง:
         * "限制用户|WORLD_001|1|24" = แบนผู้เล่นในโลก WORLD_001 เป็นเวลา 24 ชั่วโมง
         * "限制用户|WORLD_002|2|3" = เตือนผู้เล่นในโลก WORLD_002 จำนวน 3 ครั้ง
         * 
         * หมายเหตุ: ใช้สำหรับจัดการผู้เล่นที่ละเมิดกฎระเบียบ
         */

        public static void AddUserRestriction(string serverid, string worldid, int type, int value)
		{
			try
			{
                // ตรวจสอบพารามิเตอร์ที่จำเป็น
                if (worldid == null || worldid == "" || !(serverid != string.Empty))
				{
					return;     // หากข้อมูลไม่ครบถ้วน ให้หยุดการทำงาน
                }

                // ค้นหาเซิร์ฟเวอร์ที่ต้องการจากรายการเซิร์ฟเวอร์ที่เชื่อมต่อ
                foreach (SockClient serverConnection in ConnectedServers.Values)
				{
					if (RxjhClass.IsEquals(serverConnection.ServerId , serverid))
					{
                        // ส่งคำสั่งจำกัดผู้ใช้ไปยังเซิร์ฟเวอร์
                        serverConnection.Send("RESTRICT_USER|" + worldid + "|" + type + "|" + value);
						break;  // หยุดค้นหาเมื่อพบเซิร์ฟเวอร์แล้ว
                    }
				}
			}
			catch (Exception)
			{
                // จัดการข้อผิดพลาดแบบเงียบๆ
            }
        }

        /*
         * ฟังก์ชัน VerifyUserLogins
         * วัตถุประสงค์: ตรวจสอบและจัดการสถานะการเข้าสู่ระบบของผู้เล่น
         * 
         * พารามิเตอร์:
         * - ServerID: รหัสเซิร์ฟเวอร์ที่ต้องการตรวจสอบ
         * - Players: รายการผู้เล่นปัจจุบันในเซิร์ฟเวอร์
         * 
         * การทำงาน:
         * 1. อัปเดตสถานะออนไลน์ในฐานข้อมูลสำหรับผู้เล่นทั้งหมด
         * 2. เพิ่มผู้เล่นใหม่เข้าสู่รายการ Global (World.Players)
         * 3. ตรวจจับการเข้าสู่ระบบซ้ำ (Multi-boxing across servers)
         * 4. ลบผู้เล่นที่หลุดออกจากเซิร์ฟเวอร์
         * 5. เตะผู้เล่นที่เข้าซ้ำออกจากเซิร์ฟเวอร์
         * 
         * การตรวจจับ Multi-boxing:
         * - เฉพาะ IP ที่ไม่ใช่ localhost (127.0.0.1)
         * - เฉพาะ IP ที่ไม่ใช่ของเซิร์ฟเวอร์เอง
         * - ตรวจสอบเฉพาะการเข้าจากคนละเซิร์ฟเวอร์
         * 
         * หมายเหตุ: ฟังก์ชันนี้ป้องกันการเข้าเล่นหลายตัวละครพร้อมกัน
         */

        public static void VerifyUserLogins(string ServerID, Dictionary<string, playerS> Players)
		{
			try
			{
				new Dictionary<string, playerS>();
				Dictionary<string, playerS> playersToRemove = new Dictionary<string, playerS>();
				new Dictionary<string, playerS>();
				List<playerS> duplicateLogins = new List<playerS>();

				foreach (playerS currentPlayer in Players.Values)
				{
                    // อัปเดตสถานะออนไลน์ในฐานข้อมูล
                    string updateOnlineStatusQuery = "UPDATE   TBL_ACCOUNT   SET   FLD_ONLINE=1   where   FLD_ID='" + currentPlayer.UserId + "'";
					DBA.ExeSqlCommand(updateOnlineStatusQuery);

					playerS existingPlayer;

                    // ตรวจสอบว่าผู้เล่นอยู่ในรายการ World.Players หรือไม่
                    if (!World.Players.ContainsKey(currentPlayer.UserId))
					{
                        // หากไม่มี ให้เพิ่มผู้เล่นใหม่
                        lock (World.Players)
						{
							World.Players.Add(currentPlayer.UserId, currentPlayer);
						}
					}
					else if (World.Players.TryGetValue(currentPlayer.UserId, out existingPlayer) && 
						!(existingPlayer.UserIp == "127.0.0.1") &&			// ไม่ใช่ localhost
                        !(currentPlayer.UserIp == "127.0.0.1") &&			// ไม่ใช่ localhost
                        !(existingPlayer.UserIp == Hasher.GetIP()) &&		// ไม่ใช่ IP เซิร์ฟเวอร์
                        !(currentPlayer.UserIp == Hasher.GetIP()) &&		// ไม่ใช่ IP เซิร์ฟเวอร์
                        !(existingPlayer.UserId == "") &&					// มี User ID
                        !(currentPlayer.UserId == "") &&					// มี User ID
                        existingPlayer.ServerID != currentPlayer.ServerID)	// อยู่คนละเซิร์ฟเวอร์
                    {
                        // พบการเข้าสู่ระบบซ้ำจากคนละเซิร์ฟเวอร์
                        if (existingPlayer.UserId != "")
						{
							duplicateLogins.Add(existingPlayer);
						}
						if (currentPlayer.UserId != "")
						{
							duplicateLogins.Add(currentPlayer);
						}

                        // บันทึก log การเข้าสู่ระบบซ้ำ
                        MainForm.WriteLine(6, "ผู้เล่นเข้าพร้อมกันหลายเซิร์ฟเวอร์  ID：[" + existingPlayer.UserId + 
							"]  IP:[" + existingPlayer.UserIp + 
							"]  ServerID:[" + existingPlayer.ServerID +
                            "]  และ [" + currentPlayer.UserId + 
							"]  IP:[" + currentPlayer.UserIp + 
							"]  ServerID:[" + currentPlayer.ServerID + 
							"]");
					}
				}

                // ค้นหาผู้เล่นที่หลุดออกจากเซิร์ฟเวอร์แต่ยังอยู่ในรายการ
                lock (World.Players)
				{
					foreach (playerS globalPlayer in World.Players.Values)
					{
                        // หากผู้เล่นอยู่ในเซิร์ฟเวอร์นี้ แต่ไม่อยู่ในรายการปัจจุบัน และไม่ได้เชื่อมต่อ
                        if (globalPlayer.ServerID == ServerID && 
							!Players.ContainsKey(globalPlayer.UserId) && 
							globalPlayer.Connection == 0)
						{
							playersToRemove.Add(globalPlayer.UserId, globalPlayer);
						}
					}
				}

                // ลบผู้เล่นที่หลุดออกจากรายการ Global
                foreach (playerS playerToRemove in playersToRemove.Values)
				{
					lock (World.Players)
					{
						World.Players.Remove(playerToRemove.UserId);
					}
				}

                // เตะผู้เล่นที่เข้าซ้ำออกจากเซิร์ฟเวอร์
                foreach (playerS duplicatePlayer in duplicateLogins)
				{
					KickPlayerFromServer(duplicatePlayer.ServerID, duplicatePlayer.WorldID);
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
