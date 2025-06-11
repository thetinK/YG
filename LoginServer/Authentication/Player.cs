using Core;
using Database;
using Network.Clients;
using Network.TCP;
using ServerManagement;
using System;
using System.Collections.Generic;
using System.Text;
using UI;
using Utilities;

namespace Authentication
{
	public class Player
	{
		public string userId;               // รหัสผู้ใช้ (User ID)
        public int loginprocess;            // สถานะขั้นตอนการ Login
        public int onlinePlayerCount;       // จำนวนผู้เล่นออนไลน์
        public NetState Client;             // การเชื่อมต่อเครือข่าย

        /*
		 * คลาส Player
		 * วัตถุประสงค์: เก็บข้อมูลของผู้เล่นที่กำลังอยู่ในขั้นตอนการ Login
		 * 
		 * Properties:
		 * - userId: รหัสผู้ใช้ที่ได้รับจากไคลเอนต์
		 * - loginProcess: ติดตามสถานะขั้นตอนการ Login
		 *   * 0: เริ่มต้น/ยังไม่ได้ Login
		 *   * 1: ตรวจสอบเวอร์ชันแล้ว
		 *   * 2: ได้รับรายการเซิร์ฟเวอร์แล้ว
		 *   * 3: เลือกเซิร์ฟเวอร์แล้ว (พร้อมเข้าเกม)
		 * - onlinePlayerCount: จำนวนผู้เล่นออนไลน์ (อาจใช้สำหรับแสดงสถิติ)
		 * - Client: อ็อบเจ็กต์การเชื่อมต่อเครือข่ายสำหรับส่งและรับข้อมูล
		 * 
		 * การใช้งาน:
		 * - ใช้ในระบบ Login Server เพื่อจัดการสถานะของผู้เล่นแต่ละคน
		 * - ติดตามความคืบหน้าของการ Login
		 * - เก็บข้อมูลการเชื่อมต่อสำหรับการสื่อสาร
		 */

        public Player(NetState client)
		{
			userId = "";			// เริ่มต้นด้วย User ID ว่าง
            Client = client;        // กำหนดการเชื่อมต่อ
        }

        /*
		 * ฟังก์ชัน ManagePacket
		 * วัตถุประสงค์: จัดการและกระจาย packet ที่ได้รับจากไคลเอนต์ไปยังฟังก์ชันที่เหมาะสม
		 * 
		 * พารามิเตอร์:
		 * - data: ข้อมูล packet ที่ได้รับจากไคลเอนต์
		 * - length: ความยาวของข้อมูล
		 * 
		 * Packet Types ที่รองรับ:
		 * - 32768 (0x8000): การขอรับ User ID - เรียก GetUserID()
		 * - 32778 (0x800A): การตรวจสอบเวอร์ชัน - เรียก VersionVerification()
		 * - 32780 (0x800C): การเลือกเซิร์ฟเวอร์ - เรียก SelectServerFromList()
		 * - 32790 (0x8016): การขอรายการเซิร์ฟเวอร์ - เรียก GetServerList()
		 * 
		 * การจัดการข้อผิดพลาด:
		 * - หาก packet type ไม่รู้จัก: ปิดการเชื่อมต่อ
		 * - หากเกิด exception: ส่งข้อความแจ้งข้อผิดพลาดและปิดการเชื่อมต่อ
		 * 
		 * หมายเหตุ: ฟังก์ชันนี้เป็น packet dispatcher หลักของระบบ Login Server
		 */

        public void ManagePacket(byte[] data, int length)
		{
			try
			{
                // สร้าง buffer สำหรับอ่าน packet type (4 bytes)
                byte[] array = new byte[4];

                // คัดลอก 2 bytes แรกของข้อมูลเพื่อดู packet type
                Buffer.BlockCopy(data, 0, array, 0, 2);

                // แปลง bytes เป็น integer เพื่อตรวจสอบประเภทของ packet
                switch (BitConverter.ToInt32(array, 0))
				{
					case 32768:     // 0x8000 - ขอรับ User ID
						GetUserID(data, length);
						return;
					case 32778:     // 0x800A - ตรวจสอบเวอร์ชันเกม
						VersionVerification(data, length);
						return;
					case 32780:     // 0x800C - เลือกเซิร์ฟเวอร์จากรายการ
						SelectServerFromList(data, length);
						return;
					case 32790:     // 0x8016 - ขอรายการเซิร์ฟเวอร์ทั้งหมด
						GetServerList(data, length);
						return;
				}
				if (Client != null)
				{
                    // หาก packet type ไม่ตรงกับที่กำหนด ให้ปิดการเชื่อมต่อ
                    Client.Dispose();
					Client = null;
				}
			}
			catch (Exception)
			{
                // เกิดข้อผิดพลาด ส่งข้อความแจ้งเตือนและปิดการเชื่อมต่อ
                byte[] errorMessage = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาเข้าสู่ระบบใหม่");
                Client.Send(errorMessage, errorMessage.Length);
				if (Client != null)
				{
					Client.Dispose();
					Client = null;
				}
			}
		}

        /*
         * ฟังก์ชัน SetMsg
         * วัตถุประสงค์: สร้างแพ็กเกจข้อความแจ้งเตือนสำหรับส่งให้ไคลเอนต์
         * 
         * พารามิเตอร์:
         * - msg: ข้อความที่ต้องการส่งให้ผู้เล่น
         * 
         * คืนค่า: byte[] แพ็กเกจข้อความพร้อมส่ง
         * 
         * โครงสร้างแพ็กเกจ:
         * [MessageType][SubType][PacketLength][Category][Reserved][MessageLength][Reserved][Message...][NullTerminator]
         * 
         * การทำงาน:
         * 1. สร้าง header ตามโปรโตคอลของเกม
         * 2. แปลงข้อความเป็น byte array
         * 3. รวม header + ข้อความ + null terminator
         * 4. อัปเดตความยาวข้อมูลใน header
         * 
         * การใช้งาน:
         * - แสดงข้อความแจ้งเตือนแก่ผู้เล่น
         * - แสดงข้อผิดพลาดหรือการเตือน
         * - แจ้งสถานะต่างๆ ของระบบ
         */

        public byte[] SetMsg(string msg)
		{
            // สร้างแพ็กเกจ header สำหรับข้อความ
            // Header: [01][80][Length][00][17][00][MsgLength][00]
            byte[] messageHeader = Converter.hexStringToByte("0180040017000300");

            // แปลงข้อความเป็น byte array
            byte[] messageBytes = Encoding.Default.GetBytes(msg);

            // สร้างแพ็กเกจสุดท้าย: Header + ข้อความ + null terminator
            byte[] finalPacket = new byte[messageHeader.Length + messageBytes.Length + 1];

            // คัดลอก header ไปยังจุดเริ่มต้นของแพ็กเกจ
            Buffer.BlockCopy(messageHeader, 0, finalPacket, 0, messageHeader.Length);

            // คัดลอกข้อความไปยังตำแหน่งที่ 8 (หลัง header)
            Buffer.BlockCopy(messageBytes, 0, finalPacket, 8, messageBytes.Length);

            // อัปเดตความยาวแพ็กเกจรวม (ข้อความ + null terminator) ในตำแหน่งที่ 2-3
            Buffer.BlockCopy(BitConverter.GetBytes(messageBytes.Length + 1), 0, finalPacket, 2, 2);

            // อัปเดตความยาวข้อความเฉพาะในตำแหน่งที่ 6-7
            Buffer.BlockCopy(BitConverter.GetBytes(messageBytes.Length), 0, finalPacket, 6, 2);

			return finalPacket;  // คืนค่าแพ็กเกจข้อความสมบูรณ์
        }

		public void GetUserID(byte[] data, int length)
		{
			bool isValidPartition = false;      // ตรวจสอบว่าผู้เล่นอยู่ในพาร์ติชันที่ถูกต้อง

            byte[] passwordErrorPacket = Converter.hexStringToByte("018004000A000300");
			Converter.hexStringToByte("018004000B000300");      // ไม่ได้ใช้งาน
            Converter.hexStringToByte("0180040009000300");      // ไม่ได้ใช้งาน

            try
			{
                // ดึง IP Address ของไคลเอนต์และล้างช่องว่าง
                string clientIP = RxjhClass.GetUserIpadds(Client.ToString()).Replace("  ", "").Trim();

                // ตรวจสอบการแบนตามภูมิภาค
                if (World.BannedRegions != "")
				{
					bool isRegionUnbanned = false;
					string[] bannedRegionList = World.BannedRegions.Split(',');

					for (int i = 0; i < bannedRegionList.Length; i++)
					{
						if (clientIP.IndexOf(bannedRegionList[i]) == -1)
						{
							continue;   // ไม่ตรงกับภูมิภาคที่แบน
                        }

                        // ตรวจสอบรายการภูมิภาคที่ได้รับการยกเลิกการแบน
                        if (World.UnbannedRegions != "")
						{
							string unbannedRegions = World.UnbannedRegions;
							char[] separator = new char[1] { ',' };
                            string[] unbannedRegionArray = unbannedRegions.Split(separator);

                            foreach (string region in unbannedRegionArray)
							{
								if (clientIP.IndexOf(region) != -1)
								{
									isRegionUnbanned = true;
								}
							}
						}

                        // หากภูมิภาคถูกแบนและไม่ได้รับการยกเลิก
                        if (!isRegionUnbanned)
						{
							byte[] regionBanMessage = SetMsg("ภูมิภาคนี้ถูกห้ามเข้าสู่ระบบ กรุณาติดต่อฝ่ายบริการลูกค้า");
                            MainForm.WriteLine(1, clientIP + "ผู้ใช้เข้าสู่ระบบ[" + Client.ToString() + "]ถูกแบน" + bannedRegionList[i]);
                            Client.Send(regionBanMessage, regionBanMessage.Length);
							return;
						}
					}
				}

                // ตรวจสอบการแบน IP segment
                if (World.BannedIPSegments != "")
				{
					string[] bannedIPSegments = World.BannedIPSegments.Split(',');
					for (int j = 0; j < bannedIPSegments.Length; j++)
					{
						if (Client.ToString().IndexOf(bannedIPSegments[j]) != -1)
						{
							byte[] ipSegmentBanMessage = SetMsg("ช่วง IP ของคุณถูกผู้ดูแลระบบระงับ");
                            MainForm.WriteLine(1, clientIP + "ผู้ใช้เข้าสู่ระบบ[" + Client.ToString() + "]ช่วง IP ถูกแบน" + bannedIPSegments[j] + "เริ่มต้น");
                            Client.Send(ipSegmentBanMessage, ipSegmentBanMessage.Length);
							return;
						}
					}
				}

                // ตรวจสอบการแบน IP เฉพาะ
                if (RxjhClass.GetUserIP(Client.ToString()) == -1)
				{
					byte[] ipBanMessage = SetMsg("IP ของคุณถูกผู้ดูแลระบบระงับ");
                    MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ[" + Client.ToString() + "]ถูกแบน");
                    Client.Send(ipBanMessage, ipBanMessage.Length);
					return;
				}

                // ดึงชื่อผู้ใช้จากข้อมูลที่ได้รับ
                string username;
				try
				{
					byte[] usernameBytes = new byte[data[4]];
					Buffer.BlockCopy(data, 6, usernameBytes, 0, usernameBytes.Length);
					username = Encoding.Default.GetString(usernameBytes).Trim();
				}
				catch (Exception ex)
				{
					byte[] errorMessage1 = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาติดต่อเจ้าหน้าที่ 1");
                    MainForm.WriteLine(1, "getid_ดึงชื่อผู้ใช้  ข้อผิดพลาดของระบบ" + ex.Message);
                    Client.Send(errorMessage1, errorMessage1.Length);
					return;
				}

                // ดึงรหัสผ่านจากข้อมูลที่ได้รับ
                string password;
				try
				{
					byte[] passwordBytes = new byte[data[6 + data[4]]];
					Buffer.BlockCopy(data, 8 + data[4], passwordBytes, 0, passwordBytes.Length);
					password = Encoding.Default.GetString(passwordBytes).Trim();
				}
				catch (Exception ex2)
				{
					byte[] errorMessage2 = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาติดต่อเจ้าหน้าที่ 2");
                    MainForm.WriteLine(1, "getid_ดึงรหัสผ่าน  ข้อผิดพลาดของระบบ" + ex2.Message);
                    Client.Send(errorMessage2, errorMessage2.Length);
					return;
				}

                // ตรวจสอบการใช้ซอฟต์แวร์ผิดกฎหมาย
                if (RxjhClass.DAXIE(username) == -1)
				{
					byte[] injectionWarning = SetMsg("ตรวจพบการใช้ซอฟต์แวร์ลอกแฮก\r\nกรุณาเข้าสู่ระบบใหม่");
                    Client.Send(injectionWarning, injectionWarning.Length);
					return;
				}

                // ตรวจสอบอักขระผิดกฎหมาย
                if (RxjhClass.ReplaceComma(username) == -1)
				{
					byte[] illegalCharWarning = SetMsg("ตรวจพบการป้อนอักขระผิดกฎหมาย กรุณากรอกใหม่");
                    Client.Send(illegalCharWarning, illegalCharWarning.Length);
					return;
				}

                // ตรวจสอบการใส่รหัสผ่านผิดหลายครั้ง (ตามชื่อผู้ใช้)
                if (World.KillList.TryGetValue(username, out var userKillRecord) && userKillRecord.ConnectionAttempts  >= 3)
				{
                    MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ[" + username + "]-รหัสผ่านผิดหลายครั้ง");
                    byte[] passwordFailMessage = SetMsg("ชื่อผู้ใช้และรหัสผ่านผิดหลายครั้ง กรุณาลองใหม่ในอีก 5 นาที");
                    Client.Send(passwordFailMessage, passwordFailMessage.Length);
					return;
				}

                // ตรวจสอบการใส่ชื่อผู้ใช้ที่ไม่มีอยู่หลายครั้ง (ตาม IP)
                if (World.KillList.TryGetValue(Client.ToString(), out userKillRecord) && userKillRecord.ConnectionAttempts  >= 3)
				{
                    MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ IP[" + Client.ToString() + "]-ใส่ชื่อผู้ใช้ที่ไม่มีอยู่หลายครั้ง");
                    byte[] accountNotExistMessage = SetMsg("ชื่อผู้ใช้ไม่มีอยู่หลายครั้ง กรุณาลองใหม่ในอีก 5 นาที");
                    Client.Send(accountNotExistMessage, accountNotExistMessage.Length);
					return;
				}

                // ตรวจสอบข้อมูลผู้ใช้กับฐานข้อมูล
                int loginResult = -2;
				try
				{
					loginResult = RxjhClass.GetUserId(username, password, Client.ToString());
				}
				catch (Exception ex3)
				{
					MainForm.WriteLine(1, Converter.ToString(data));
					MainForm.WriteLine(1, ex3.Message);
				}

                // จัดการผลลัพธ์การเข้าสู่ระบบ
                switch (loginResult)
				{
					case -3:	// บัญชีถูกล็อค IP
						{
                            byte[] ipLockedMessage = SetMsg("บัญชีถูกล็อคที่อยู่ IP เข้าสู่ระบบ\r\nกรุณาไปที่เว็บไซต์[จัดการบัญชี]เพื่อปลดล็อค\r\n" + World.RegistrationWebsiteAddress);
                            MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ[" + username + "]บัญชีได้รับการป้องกัน");
                            Client.Send(ipLockedMessage, ipLockedMessage.Length);
							return;
						}
					case -2:    // ข้อผิดพลาดของระบบ
                        {
							byte[] systemErrorMessage = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาติดต่อเจ้าหน้าที่ 3");
                            Client.Send(systemErrorMessage, systemErrorMessage.Length);
							return;
						}
					case -1:    // ชื่อผู้ใช้ไม่มีอยู่	
                        {
						if (World.KillList.TryGetValue(Client.ToString(), out var ipKillRecord))
						{
							if (ipKillRecord.ConnectionAttempts  < 3)
							{
								ipKillRecord.ConnectionAttempts ++;
								byte[] accountNotExistMsg = SetMsg("ชื่อผู้ใช้ไม่มีอยู่");
								MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ IP[" + Client.ToString() + "]ชื่อผู้ใช้ไม่มีอยู่-2");
								Client.Send(accountNotExistMsg, accountNotExistMsg.Length);
							}
							else
							{
								ipKillRecord.ExpireTime = DateTime.Now.AddMinutes(5.0);
								MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ IP[" + Client.ToString() + "]ชื่อผู้ใช้ไม่มีอยู่-3");
								byte[] accountNotExistMultipleMsg = SetMsg("คุณป้อนชื่อผู้ใช้ที่ไม่มีอยู่หลายครั้ง กรุณาลองใหม่ในอีก 5 นาที");
								Client.Send(accountNotExistMultipleMsg, accountNotExistMultipleMsg.Length);
							}
						}
						else
						{
							World.KillList.Add(Client.ToString(), new KillTimer
							{
								UserId = Client.ToString(),
								ConnectionAttempts  = 1
							});

							byte[] accountNotExistFirstMsg = SetMsg("ชื่อผู้ใช้ไม่มีอยู่");
							MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ IP[" + Client.ToString() + "]ชื่อผู้ใช้ไม่มีอยู่-1");
							Client.Send(accountNotExistFirstMsg, accountNotExistFirstMsg.Length);
						}
						return;
					}
					case 0:     // รหัสผ่านผิด
                        {
						if (World.KillList.TryGetValue(username, out var passwordKillRecord))
						{
							if (passwordKillRecord.ConnectionAttempts  < 3)
							{
								passwordKillRecord.ConnectionAttempts ++;
                                MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ[" + username + "]-[" + password + "]รหัสผ่านผิด");
                                Client.Send(passwordErrorPacket, passwordErrorPacket.Length);
							}
							else
							{
								passwordKillRecord.ExpireTime = DateTime.Now.AddMinutes(5.0);
                                MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ[" + username + "]-[" + password + "]รหัสผ่านผิด");
                                byte[] passwordErrorMultipleMsg = SetMsg("คุณป้อนชื่อผู้ใช้และรหัสผ่านผิดหลายครั้ง กรุณาลองใหม่ในอีก 5 นาที");
                                Client.Send(passwordErrorMultipleMsg, passwordErrorMultipleMsg.Length);
							}
						}
						else
						{
							World.KillList.Add(username, new KillTimer
							{
								UserId = username,
								ConnectionAttempts  = 1
							});

                            MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ[" + username + "]-[" + password + "]รหัสผ่านผิด");
                            Client.Send(passwordErrorPacket, passwordErrorPacket.Length);
						}
						return;
					}
				}

                // กรณีบัญชีถูกระงับ (มีค่าเป็นบวก = จำนวนชั่วโมงที่เหลือ)
                if (loginResult > 0)
				{
                    byte[] suspendedMessage = SetMsg("บัญชีถูกระงับ\r\nเหลือเวลาอีก " + loginResult / 24 + " วัน " + (double)(loginResult % 24) + " ชั่วโมงก่อนปลดระงับ!");
                    MainForm.WriteLine(2, "ผู้ใช้เข้าสู่ระบบ[" + username + "]บัญชีถูกระงับ");
                    Client.Send(suspendedMessage, suspendedMessage.Length);
					return;
				}

                // ตรวจสอบว่าเข้าสู่ระบบสำเร็จหรือไม่ (-99 = สำเร็จ)
                if (loginResult != -99)
				{
					return;
				}

                // ล้างรายการ Kill List เมื่อเข้าสู่ระบบสำเร็จ
                if (World.KillList.ContainsKey(username))
				{
					World.KillList.Remove(username);
				}
				if (World.KillList.ContainsKey(Client.ToString()))
				{
					World.KillList.Remove(Client.ToString());
				}

                // สร้างแพ็กเกจตอบกลับสำหรับการเข้าสู่ระบบสำเร็จ
                byte[] successPacket = new byte[11 + username.Length + username.Length + 3];
				byte[] headerBytes = Converter.hexStringToByte("01800C0000003300");
				try
				{
					Buffer.BlockCopy(headerBytes, 0, successPacket, 0, headerBytes.Length);
				}
				catch (Exception ex4)
				{
					byte[] errorMessage4 = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาติดต่อเจ้าหน้าที่ 4");
                    MainForm.WriteLine(1, "getid_bySend  ข้อผิดพลาด 1 " + successPacket.Length + "  " + headerBytes.Length + ex4.Message);
                    Client.Send(errorMessage4, errorMessage4.Length);
					return;
				}
				byte[] usernameBytes2 = new byte[0];
				try
				{
					Buffer.BlockCopy(BitConverter.GetBytes(username.Length), 0, successPacket, 8, 1);
					Buffer.BlockCopy(BitConverter.GetBytes(username.Length), 0, successPacket, 8 + username.Length + 3, 1);
					Buffer.BlockCopy(BitConverter.GetBytes(7 + username.Length + username.Length + 2), 0, successPacket, 2, 1);
                    usernameBytes2 = Encoding.Default.GetBytes(username);
				}
                catch (Exception ex5)
                {
                    byte[] errorMessage5 = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาติดต่อเจ้าหน้าที่ 5");
                    MainForm.WriteLine(1, "getid_bySend  ข้อผิดพลาด 2 " + successPacket.Length + "  " + ex5.Message);
                    Client.Send(errorMessage5, errorMessage5.Length);
                    return;
                }

                try
                {
                    // คัดลอกชื่อผู้ใช้ลงในแพ็กเกจ (2 ครั้ง)
                    Buffer.BlockCopy(usernameBytes2, 0, successPacket, 10, usernameBytes2.Length);
                    Buffer.BlockCopy(usernameBytes2, 0, successPacket, 10 + username.Length + 3, usernameBytes2.Length);
                }
                catch (Exception ex6)
                {
                    byte[] errorMessage6 = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาติดต่อเจ้าหน้าที่ 6");
                    MainForm.WriteLine(1, "getid_bySend  ข้อผิดพลาด " + successPacket.Length + "  " + usernameBytes2.Length + ex6.Message);
                    Client.Send(errorMessage6, errorMessage6.Length);
                    return;
                }
                try
				{
					string[] partitionArray = World.PartitionIDs.Split(';');
					if (partitionArray.Length > 1)
					{
						for (int k = 0; k < partitionArray.Length; k++)
						{
							if (RxjhClass.GetPartitionID(username) == partitionArray[k])
							{
								isValidPartition = true;
								break;
							}
						}
					}
				}
				catch
				{
					byte[] partitionErrorMessage = SetMsg("เกิดข้อผิดพลาดของระบบ ไม่ได้ตั้งค่าพาร์ติชันเข้าสู่ระบบที่ถูกต้อง กรุณาติดต่อผู้ดูแลระบบ 7");
                    Client.Send(partitionErrorMessage, partitionErrorMessage.Length);
					return;
				}

                // ตรวจสอบว่าผู้เล่นอยู่ในพาร์ติชันที่ถูกต้อง
                if (!isValidPartition)
				{
					byte[] wrongPartitionMessage = SetMsg("บัญชีไม่ได้เปิดใช้งานหรือเข้าผิดพาร์ติชัน กรุณาติดต่อผู้ดูแลระบบ 8");
                    Client.Send(wrongPartitionMessage, wrongPartitionMessage.Length);
					return;
				}

                // ลงทะเบียนผู้เล่นในระบบ
                if (!World.LoginPlayer(username))
				{
					byte[] array26 = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาติดต่อเจ้าหน้าที่ กรุณาเข้าสู่ระบบใหม่ 9");
                    Client.Send(array26, array26.Length);
					return;
				}

                // ส่งแพ็กเกจการเข้าสู่ระบบสำเร็จ
                Client.Send(successPacket, successPacket.Length);

                // อัปเดตข้อมูลผู้เล่น
                userId = username;
				World.KickOtherInstancesOfUser(username);        // เตะผู้เล่นชื่อเดียวกันที่เข้าจากที่อื่น
                RxjhClass.UpdateLoginIP(username, Client.ToString());       // อัปเดต IP ล่าสุด

                // อัปเดต IP ในข้อมูลผู้เล่น
                if (World.Players.TryGetValue(username, out var playerData))
				{
					playerData.UserIp = Client.ToString();
				}

				loginprocess = 1;       // เปลี่ยนสถานะเป็นขั้นตอนที่ 1
                MainForm.WriteLine(2, $"ผู้ใช้เข้าสู่ระบบ : [{username}] - [{password}]");
                MainForm.WriteLine(2, $"เข้าสู่ระบบสำเร็จ : [{clientIP}] - [{Client.ToString()}]");

            }
			catch (Exception ex7)
			{
                byte[] finalErrorMessage = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาติดต่อเจ้าหน้าที่ 10");
                MainForm.WriteLine(1, "getid ข้อผิดพลาดของระบบ " + ex7.Message);
                Client.Send(finalErrorMessage, finalErrorMessage.Length);
			}
		}

        /*
		 * ฟังก์ชัน VersionVerification (版本验证)
		 * วัตถุประสงค์: ตรวจสอบเวอร์ชันไคลเอนต์และส่งข้อมูลเซิร์ฟเวอร์กลับ
		 * 
		 * พารามิเตอร์:
		 * - data: ข้อมูลเวอร์ชันที่ได้รับจากไคลเอนต์ (ไม่ได้ใช้ในฟังก์ชันนี้)
		 * - length: ความยาวของข้อมูล (ไม่ได้ใช้ในฟังก์ชันนี้)
		 * 
		 * การทำงาน:
		 * 1. ส่งแพ็กเกจตอบกลับที่มีข้อมูลเซิร์ฟเวอร์
		 * 2. แพ็กเกจประกอบด้วย: ชื่อ Login Server, ข้อมูลการเชื่อมต่อ
		 * 
		 * โครงสร้างแพ็กเกจ:
		 * [0B] - Message Type: Version Response
		 * [81] - Sub Type: Server Info  
		 * [28 00] - Data Length: 40 bytes
		 * [LOGIN_SERVER_00] - ชื่อเซิร์ฟเวอร์ Login
		 * [00] - Null terminator
		 * [01] - Version flag
		 * [59] - Additional data
		 * [BOnline--1255634117] - ข้อมูลการเชื่อมต่อ/Session
		 * [00] - Null terminator
		 * [55 46] - Footer/Checksum
		 * 
		 * หมายเหตุ: 
		 * - ฟังก์ชันนี้เป็นขั้นตอนแรกของการ Login
		 * - ไคลเอนต์จะใช้ข้อมูลนี้ในการเชื่อมต่อขั้นตอนถัดไป
		 * - ข้อมูล "BOnline--1255634117" อาจเป็น Session ID หรือ Timestamp
		 */

        public void VersionVerification(byte[] data, int length)
		{
            // ส่งแพ็กเกจตอบกลับสำหรับการตรวจสอบเวอร์ชัน
            // แพ็กเกจนี้มีข้อมูล: ประเภทข้อความ, ชื่อเซิร์ฟเวอร์, และข้อมูลการเชื่อมต่อ
            byte[] responsePacket = Converter.hexStringToByte("0B8128004C4F47494E5F5345525645525F3030000159424F6E6C696E652D2D31323535363334313137005546");

            // ส่งแพ็กเกจไปยังไคลเอนต์
            Client.Send(responsePacket, responsePacket.Length);
		}

		public void SelectServerFromList(byte[] data, int length)
		{
			try
			{
                // Check for illegal software usage
                if (RxjhClass.DAXIE(userId) == -1)
				{
					if (World.KillList.TryGetValue(userId, out var killRecord))
					{
						if (killRecord.Move  < 3)
						{
							killRecord.Move ++;
							byte[] warningMsg = SetMsg("ตรวจพบการใช้ซอฟต์แวร์ลอกผิดกฎหมาย\r\nหากใช้ซอฟต์แวร์ inject ผิดกฎหมาย 3 ครั้งติดต่อกันจะถูกแบนถาวร\r\nกรุณาเข้าสู่ระบบใหม่ (2)");
                            Client.Send(warningMsg, warningMsg.Length);
						}
						else
						{
                            // Permanent ban
                            DBA.ExeSqlCommand("UPDATE  TBL_ACCOUNT  SET  FLD_ZT=99999  WHERE  FLD_ID='" + userId + "'", "rxjhaccount");
							byte[] banMsg  = SetMsg("ตรวจพบการใช้ซอฟต์แวร์ลอกผิดกฎหมาย\r\nหากใช้ซอฟต์แวร์ inject ผิดกฎหมาย 3 ครั้งติดต่อกันจะถูกแบนถาวร\r\nกรุณาเข้าสู่ระบบใหม่ (3)");
                            Client.Send(banMsg , banMsg .Length);
						}
					}
					else
					{
                        // First offense
                        World.KillList.Add(userId, new KillTimer
						{
							UserId = userId,
							Move  = 1
						});
						byte[] firstWarning  = SetMsg("ตรวจพบการใช้ซอฟต์แวร์ลอกผิดกฎหมาย\r\nหากใช้ซอฟต์แวร์ inject ผิดกฎหมาย 3 ครั้งติดต่อกันจะถูกแบนถาวร\r\nกรุณาเข้าสู่ระบบใหม่ (1)");
                        Client.Send(firstWarning , firstWarning .Length);
					}
					return;
				}

                // Find player data
                playerS player = World.QueryPlayer(userId);
				if (player != null)
				{
					if (player.LoginOut)
					{
						byte[] kickMsg  = SetMsg("ตัวละครถูกเตะออกจากระบบหรือบัญชีค้าง\r\nกรุณาเข้าสู่ระบบใหม่");
                        Client.Send(kickMsg , kickMsg .Length);
						return;
					}

                    // Get selected server info
                    int serverGroupIndex = data[4];
					int serverIndex = data[8];
					ServerClass serverGroup = World.ServerList[serverGroupIndex - 1];

                    // Get server details
                    byte[] serverIP = Encoding.Default.GetBytes(serverGroup.ServerList[serverIndex - 1].SERVER_IP);
					byte[] serverPort = BitConverter.GetBytes(int.Parse(serverGroup.ServerList[serverIndex - 1].SERVER_PORT));
					byte[] serverName = Encoding.Default.GetBytes(serverGroup.ServerList[serverIndex - 1].SERVER_NAME);

                    // Create response packet
                    byte[] ipLengthBytes = BitConverter.GetBytes(serverIP.Length);
					byte[] nameLengthBytes = BitConverter.GetBytes(serverName.Length);

					byte[] responsePacket = new byte[6 + serverIP.Length + serverPort.Length + serverName.Length + 2 + serverName.Length];
					responsePacket[0] = 100;        // Message type
                    responsePacket[1] = 128;        // Sub type
                    responsePacket[4] = ipLengthBytes[0];

                    // Copy packet length
                    Buffer.BlockCopy(BitConverter.GetBytes(responsePacket.Length - 4), 0, responsePacket, 2, 2);

                    // Copy server data
                    Buffer.BlockCopy(serverIP, 0, responsePacket, 6, serverIP.Length);
					Buffer.BlockCopy(serverPort, 0, responsePacket, 6 + serverIP.Length, serverPort.Length);
					Buffer.BlockCopy(serverName, 0, responsePacket, responsePacket.Length - serverName.Length - serverName.Length - 2, serverName.Length);
					Buffer.BlockCopy(serverName, 0, responsePacket, responsePacket.Length - serverName.Length, serverName.Length);

					responsePacket[responsePacket.Length - serverName.Length - 2] = nameLengthBytes[0];
					responsePacket[responsePacket.Length - serverName.Length - 2 - serverName.Length - 2] = nameLengthBytes[0];

                    // Add server zone ID
                    byte[] finalPacket = new byte[responsePacket.Length + 4];
					Buffer.BlockCopy(responsePacket, 0, finalPacket, 0, responsePacket.Length);
					Buffer.BlockCopy(BitConverter.GetBytes(serverGroup.ServerList[serverIndex - 1].ServerZId), 0, finalPacket, finalPacket.Length - 2, 2);

					Client.Send(finalPacket, finalPacket.Length);

					player.OriginalServerIndex = serverGroup.ServerList[serverIndex - 1].ServerId;
					player.OriginalServerIP  = serverGroup.ServerList[serverIndex - 1].SERVER_IP;
					player.OriginalServerPort  = serverGroup.ServerList[serverIndex - 1].SERVER_PORT;
					player.OriginalServerID  = serverGroup.ServerList[serverIndex - 1].ServerZId;
					player.CoinPlazaServerIP  = serverGroup.ServerList[12].SERVER_IP;
					player.CoinPlazaServerPort  = serverGroup.ServerList[12].SERVER_PORT;


					loginprocess = 3;
				}
				else
				{
					byte[] errorMsg = SetMsg("ตัวละครถูกเตะออกจากระบบหรือบัญชีค้าง\r\nกรุณาเข้าสู่ระบบใหม่");
                    Client.Send(errorMsg, errorMsg.Length);
				}
			}
			catch (Exception ex)
			{
				byte[] systemError = SetMsg("เกิดข้อผิดพลาดของระบบ กรุณาติดต่อเจ้าหน้าที่");
                MainForm.WriteLine(1, "SelectServerFromList Error: " + ex.Message);
                Client.Send(systemError, systemError.Length);
			}
		}

        /*
		 * ฟังก์ชัน GetServerList
		 * วัตถุประสงค์: ส่งรายการเซิร์ฟเวอร์ทั้งหมดให้กับไคลเอนต์
		 * 
		 * พารามิเตอร์:
		 * - data: ข้อมูลที่ได้รับจากไคลเอนต์ (ไม่ได้ใช้ในฟังก์ชันนี้)
		 * - length: ความยาวของข้อมูล (ไม่ได้ใช้ในฟังก์ชันนี้)
		 * 
		 * การทำงาน:
		 * 1. วนลูปดึงข้อมูลทุกกลุ่มเซิร์ฟเวอร์โดยใช้ GetPartitionPacket()
		 * 2. รวมข้อมูลทั้งหมดเป็นแพ็กเกจเดียว
		 * 3. สร้าง header ที่มีข้อมูล: ประเภทข้อความ, จำนวนเซิร์ฟเวอร์, ความยาวข้อมูล
		 * 4. ส่งแพ็กเกจสมบูรณ์ให้ไคลเอนต์
		 * 5. เปลี่ยนสถานะ login เป็นขั้นตอนที่ 2
		 * 
		 * โครงสร้างแพ็กเกจสุดท้าย:
		 * [MessageType=23][SubType=128][DataLength(2bytes)][ServerCount][Reserved][ServerData...]
		 * 
		 * หมายเหตุ: ใช้ในระบบ Login เมื่อผู้เล่นต้องการดูรายการเซิร์ฟเวอร์ที่สามารถเข้าเล่นได้
		 */

        public void GetServerList(byte[] data, int length)
		{
			List<byte[]> list = new List<byte[]>();

			int serverCount = World.ServerCount;        // จำนวนกลุ่มเซิร์ฟเวอร์ทั้งหมด
            int totalSize = 0;							// ขนาดรวมของข้อมูลทั้งหมด

            // รวบรวมแพ็กเกจข้อมูลของแต่ละกลุ่มเซิร์ฟเวอร์
            for (int i = 0; i < serverCount; i++)
			{
				byte[] serverPacket  = GetPartitionPacket(i);       // ดึงแพ็กเกจของกลุ่มเซิร์ฟเวอร์
                list.Add(serverPacket );                            // เพิ่มลงในรายการ
                totalSize += serverPacket .Length;                  // รวมขนาดข้อมูล
            }

            // รวมข้อมูลเซิร์ฟเวอร์ทั้งหมดเป็น array เดียว
            byte[] combinedServerData = new byte[totalSize];
			int currentPosition  = 0;   // ตำแหน่งปัจจุบันในการคัดลอก

            for (int j = 0; j < serverCount; j++)
			{
				byte[] serverData = list[j];

                // คัดลอกข้อมูลเซิร์ฟเวอร์แต่ละกลุ่มไปยัง array รวม
                Buffer.BlockCopy(serverData, 0, combinedServerData, currentPosition , serverData.Length);
				currentPosition  += serverData.Length;      // เลื่อนตำแหน่งไปข้างหน้า
            }

            // สร้างแพ็กเกจสุดท้ายพร้อม header
            byte[] lengthBytes = BitConverter.GetBytes(combinedServerData.Length);      // ความยาวข้อมูล
            byte[] finalPacket = new byte[6 + combinedServerData.Length];				// แพ็กเกจสุดท้าย

            // ตั้งค่า header ของแพ็กเกจ
            Buffer.BlockCopy(lengthBytes , 0, finalPacket, 2, 2);       // คัดลอกความยาวข้อมูล
            finalPacket[0] = 23;                        // ประเภทข้อความ (Message Type)
            finalPacket[1] = 128;                       // ประเภทย่อย/แฟล็ก (Sub type/flag)
            finalPacket[4] = (byte)serverCount;         // จำนวนกลุ่มเซิร์ฟเวอร์
            finalPacket[5] = 0;							// สงวนไว้/แฟล็ก (Reserved/flag)

            // คัดลอกข้อมูลเซิร์ฟเวอร์ไปยังแพ็กเกจสุดท้าย
            Buffer.BlockCopy(combinedServerData, 0, finalPacket, 6, combinedServerData.Length);

            // ส่งแพ็กเกจให้กับไคลเอนต์
            Client.Send(finalPacket, finalPacket.Length);
			loginprocess = 2;       // เปลี่ยนสถานะ login process เป็นขั้นตอนที่ 2
        }

        /*
		 * ฟังก์ชัน GetChannelPacket
		 * วัตถุประสงค์: สร้างแพ็กเกจข้อมูลสำหรับแสดงรายการช่องทาง/เซิร์ฟเวอร์ย่อย
		 * 
		 * พารามิเตอร์:
		 * - channelStatus: สถานะช่องทางที่กำหนดไว้ (1=เต็ม, 2=แออัดมาก, 3=ปานกลาง, 4=ว่าง)
		 * - id: หมายเลข ID ของช่องทาง
		 * - zoneId: Zone ID สำหรับค้นหาเซิร์ฟเวอร์
		 * - channelName: ชื่อของช่องทาง
		 * 
		 * คืนค่า: byte[] แพ็กเกจข้อมูลพร้อมส่งให้ไคลเอนต์
		 * 
		 * โครงสร้างแพ็กเกจ:
		 * [ID][Reserved][NameLength][Reserved][ChannelName...][Status][Extra(v1+)]
		 * 
		 * สถานะความแออัด:
		 * - -1: เซิร์ฟเวอร์เต็ม (แดง)
		 * - 0-30: ว่าง (เขียว)  
		 * - 31-70: ปานกลาง (เหลือง)
		 * - 71-99: แออัด (ส้ม)
		 * - 101: ออฟไลน์ (เทา)
		 */

        public byte[] GetChannelPacket(int channelStatus, int id, int zoneId, string channelName)
		{
			double currentOnline = -1.0;            // จำนวนผู้เล่นออนไลน์ปัจจุบัน
            double maxOnline = 1000.0;              // จำนวนผู้เล่นสูงสุด
            double loadPercentage;                  // จำนวนผู้เล่นสูงสุด
            try
			{
                // ค้นหาข้อมูลเซิร์ฟเวอร์จาก Zone ID
                SockClient sockClient = World.QueryServer(zoneId.ToString());
                if (sockClient != null)
                {
					currentOnline = sockClient.CurrentOnline;		// ดึงจำนวนผู้เล่นปัจจุบัน
                    maxOnline = sockClient.MaxOnline;               // ดึงจำนวนผู้เล่นสูงสุด
                }

                // คำนวณเปอร์เซ็นต์ความแออัดของเซิร์ฟเวอร์
                if (currentOnline != -1.0)
				{
					if (currentOnline > 0.0)
					{
						if (currentOnline < maxOnline)
						{
                            // คำนวณเปอร์เซ็นต์ความแออัด
                            double onePercent = maxOnline / 100.0;
							loadPercentage = currentOnline / onePercent;
						}
						else
						{
							loadPercentage = -1.0;  // เซิร์ฟเวอร์เต็ม
                        }
					}
					else
					{
						loadPercentage = 0.0;   // เซิร์ฟเวอร์ว่าง
                    }
				}
				else
				{
					loadPercentage = 101.0;     // เซิร์ฟเวอร์ออฟไลน์
                }
			}
			catch
			{
				loadPercentage = 101.0;     // เกิดข้อผิดพลาด - ถือว่าออฟไลน์
            }

            // แปลงข้อมูลเป็น byte array
            byte[] channelNameBytes = Encoding.Default.GetBytes(channelName);
			byte[] idBytes = BitConverter.GetBytes(id + 1);
			byte[] statusBytes;

            // กำหนดการแสดงสถานะ
            if (World.RealChannelSwitch != 0)   // ใช้ข้อมูลเรียลไทม์
            {
				statusBytes = BitConverter.GetBytes((int)loadPercentage);
			}
            else  // ใช้สถานะที่กำหนดไว้ล่วงหน้า
            {
                statusBytes = channelStatus switch
                {
                    1 => BitConverter.GetBytes(-1),  // เต็ม (สีแดง)
                    2 => BitConverter.GetBytes(92),  // แออัดมาก (สีส้ม) 
                    3 => BitConverter.GetBytes(55),  // แออัดปานกลาง (สีเหลือง)
                    4 => BitConverter.GetBytes(22),  // ว่าง (สีเขียว)
                    _ => BitConverter.GetBytes(101), // ออฟไลน์ (สีเทา)
                };
            }
			byte[] nameLengthBytes = BitConverter.GetBytes(channelNameBytes.Length);     // ความยาวชื่อช่องทาง
            byte[] packet;      // แพ็กเกจข้อมูลที่จะส่งกลับ

            // สร้างแพ็กเกจตามเวอร์ชัน
            if (World.ver == 0) // เวอร์ชันเก่า
            {
				packet = new byte[6 + channelNameBytes.Length];
				packet[0] = idBytes[0];                             // ID ช่องทาง
                packet[2] = nameLengthBytes[0];                     // ความยาวชื่อ
                packet[packet.Length - 2] = statusBytes[0];         // สถานะ
            }
            else  // เวอร์ชันใหม่
            {
				packet = new byte[8 + channelNameBytes.Length];
				packet[0] = idBytes[0];                             // ID ช่องทาง
                packet[2] = nameLengthBytes[0];                     // ความยาวชื่อ
                packet[packet.Length - 4] = statusBytes[0];         // สถานะ
                packet[packet.Length - 2] = 3;                      // ข้อมูลเพิ่มเติม
            }

            // คัดลอกชื่อช่องทางลงในแพ็กเกจ
            Buffer.BlockCopy(channelNameBytes, 0, packet, 4, channelNameBytes.Length);
			return packet;      // คืนค่าแพ็กเกจข้อมูล
        }

		/*
		 * ฟังก์ชัน GetPartitionPacket
		 * วัตถุประสงค์: สร้างแพ็กเกจข้อมูลสำหรับกลุ่มเซิร์ฟเวอร์ (Partition/Region)
		 * 
		 * พารามิเตอร์:
		 * - partitionId: หมายเลข ID ของกลุ่มเซิร์ฟเวอร์
		 * 
		 * คืนค่า: byte[] แพ็กเกจข้อมูลที่มีรายการเซิร์ฟเวอร์ทั้งหมดในกลุ่ม
		 * 
		 * โครงสร้างแพ็กเกจ:
		 * [Header - 14 bytes + ชื่อกลุ่ม][Channel1 Data][Channel2 Data]...[ChannelN Data]
		 * 
		 * Header Structure:
		 * [PartitionID][Reserved][NameLength][PartitionName...][Flags][ServerCount][Reserved]
		 * 
		 * การทำงาน:
		 * 1. ดึงข้อมูลกลุ่มเซิร์ฟเวอร์
		 * 2. สร้างแพ็กเกจสำหรับแต่ละช่องทาง (สูงสุด 12 ช่องทาง)
		 * 3. รวมแพ็กเกจทั้งหมดเป็นแพ็กเกจเดียว
		 * 4. ใส่ header ข้อมูลกลุ่มเซิร์ฟเวอร์
		 * 
		 * หมายเหตุ: ใช้ในระบบ Login เพื่อส่งรายการเซิร์ฟเวอร์ให้ผู้เล่นเลือก
		 */
        public byte[] GetPartitionPacket(int partitionId)
		{
			// ดึงข้อมูลเซิร์ฟเวอร์กลุ่มจาก ID ที่ระบุ
			ServerClass serverClass = World.ServerList[partitionId];
			int serverCount = serverClass.ServerCount;

            // จำกัดจำนวนเซิร์ฟเวอร์สูงสุดที่ 12 เซิร์ฟเวอร์
            if (serverCount > 12)
			{
				serverCount = 12;
			}

            // แปลงชื่อกลุ่มเซิร์ฟเวอร์เป็น byte array
            byte[] partitionNameBytes = Encoding.Default.GetBytes(serverClass.SERVER_NAME);

			int totalChannelDataSize = 0;       // ขนาดรวมของข้อมูลช่องทางทั้งหมด
            List<byte[]> channelPacketList = new List<byte[]>(); // รายการแพ็กเกจของแต่ละช่องทาง

            // สร้างแพ็กเกจข้อมูลสำหรับแต่ละช่องทางในกลุ่มเซิร์ฟเวอร์
            for (int i = 0; i < serverCount; i++)
			{
                // สร้างแพ็กเกจช่องทางโดยใช้ฟังก์ชัน GetChannelPacket
                byte[] channelPacket = GetChannelPacket(
					World.PartitionChannelStatus[i],        // สถานะช่องทาง
                    serverClass.ServerList[i].ServerId,     // ID เซิร์ฟเวอร์
                    serverClass.ServerList[i].ServerZId,    // Zone ID	
                    serverClass.ServerList[i].SERVER_NAME   // ชื่อเซิร์ฟเวอร์
                );

				totalChannelDataSize += channelPacket.Length;   // รวมขนาดข้อมูล	
                channelPacketList.Add(channelPacket);           // เพิ่มลงในรายการ
            }

            // สร้างแพ็กเกจ header สำหรับกลุ่มเซิร์ฟเวอร์
            byte[] headerPacket = new byte[14 + partitionNameBytes.Length];

            // สร้างแพ็กเกจสุดท้ายที่รวม header + ข้อมูลช่องทางทั้งหมด
            byte[] finalPacket = new byte[totalChannelDataSize + headerPacket.Length];

            // คัดลอกข้อมูลช่องทางทั้งหมดไปยังแพ็กเกจสุดท้าย
            int currentPosition = 0;
			for (int j = 0; j < serverCount; j++)
			{
				byte[] channelData = channelPacketList[j];
				Buffer.BlockCopy(channelData, 0, finalPacket, headerPacket.Length + currentPosition, channelData.Length);
				currentPosition += channelData.Length;
			}

            // แปลงข้อมูลต่างๆ เป็น byte array สำหรับใส่ใน header
            byte[] partitionIdBytes = BitConverter.GetBytes(partitionId + 1);               // ID กลุ่มเซิร์ฟเวอร์
            byte[] serverCountBytes = BitConverter.GetBytes(serverCount);                   // จำนวนเซิร์ฟเวอร์
            byte[] nameLengthBytes = BitConverter.GetBytes(partitionNameBytes.Length);      // ความยาวชื่อกลุ่ม

            // สร้าง header แพ็กเกจ
            headerPacket[0] = partitionIdBytes[0];      // ID กลุ่มเซิร์ฟเวอร์			
            headerPacket[headerPacket.Length - 8] = 1;  // ค่า flag
            headerPacket[2] = nameLengthBytes[0];       // ความยาวชื่อกลุ่ม
            headerPacket[headerPacket.Length - 4] = serverCountBytes[0];    // จำนวนเซิร์ฟเวอร์	
            headerPacket[headerPacket.Length - 6] = 1;  // ค่า flag เพิ่มเติม

			// คัดลอกชื่อกลุ่มเซิร์ฟเวอร์ลงใน header											 	
            Buffer.BlockCopy(partitionNameBytes, 0, headerPacket, 4, partitionNameBytes.Length);

            // คัดลอก header ไปยังจุดเริ่มต้นของแพ็กเกจสุดท้าย
            Buffer.BlockCopy(headerPacket, 0, finalPacket, 0, headerPacket.Length);

			return finalPacket; // คืนค่าแพ็กเกจข้อมูลทั้งหมดที่รวม header และข้อมูลช่องทาง
        }
	}
}
