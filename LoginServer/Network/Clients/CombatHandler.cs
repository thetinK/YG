using Authentication;
using Core;
using Delegates;
using Network.Servers;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Threading;
using UI;

namespace Network.Clients
{
	public class CombatHandler : BaseSocketClient
	{
		private AttackServerConnector AtSend;

		public CombatHandler(Socket from, ATRemoveClientDelegate rftsl)
			: base(from, rftsl)
		{
		}

		public void 物理攻击人物包(object ParObject)
		{
			try
			{
				byte[] databyte = ((ThreadParameter)ParObject).Databyte;
				Thread.Sleep(BitConverter.ToInt16(databyte, 18));
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public void 物理攻击怪物包(object ParObject)
		{
			try
			{
				byte[] databyte = ((ThreadParameter)ParObject).Databyte;
				Thread.Sleep(BitConverter.ToInt16(databyte, 18));
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public void 物理攻击怪物包1(object ParObject)
		{
			try
			{
				byte[] databyte = ((ThreadParameter)ParObject).Databyte;
				Thread.Sleep(BitConverter.ToInt16(databyte, 18));
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public void 魔法攻击怪物包(object ParObject)
		{
			try
			{
				byte[] databyte = ((ThreadParameter)ParObject).Databyte;
				Thread.Sleep(BitConverter.ToInt16(databyte, 18));
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public void 魔法攻击怪物包1(object ParObject)
		{
			try
			{
				byte[] databyte = ((ThreadParameter)ParObject).Databyte;
				Thread.Sleep(BitConverter.ToInt16(databyte, 18));
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public void 魔法攻击怪物包2(object ParObject)
		{
			try
			{
				byte[] databyte = ((ThreadParameter)ParObject).Databyte;
				Thread.Sleep(BitConverter.ToInt16(databyte, 18));
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public void 魔法攻击怪物包3(object ParObject)
		{
			try
			{
				byte[] databyte = ((ThreadParameter)ParObject).Databyte;
				Thread.Sleep(BitConverter.ToInt16(databyte, 18));
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public void 魔法攻击怪物包4(object ParObject)
		{
			try
			{
				byte[] databyte = ((ThreadParameter)ParObject).Databyte;
				Thread.Sleep(BitConverter.ToInt16(databyte, 18));
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public void 魔法攻击怪物包5(object ParObject)
		{
			try
			{
				byte[] databyte = ((ThreadParameter)ParObject).Databyte;
				Thread.Sleep(BitConverter.ToInt16(databyte, 18));
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public void 魔法攻击人物包(object ParObject)
		{
			try
			{
				ThreadParameter obj = (ThreadParameter)ParObject;
				byte[] databyte = obj.Databyte;
				playerS playerS2 = obj.players;
				int num = BitConverter.ToInt16(databyte, 18);
				for (int i = 0; i < num / 6; i++)
				{
					Thread.Sleep(5);
					if (playerS2.IsSkillStuck)
					{
						return;
					}
				}
				AtSend.Send(databyte, 36);
			}
			catch (Exception)
			{
			}
		}

		public override byte[] ProcessDataReceived(byte[] data, int length)
		{
			try
			{
				int num = 0;
				if (170 == data[0] && 102 == data[1])
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
						if (num >= length || data[num] != 170 || data[num + 1] != 102)
						{
							break;
						}
						Buffer.BlockCopy(data, num + 2, array, 0, 4);
						num2 = BitConverter.ToInt16(array, 0);
					}
				}
				return null;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "ATServer出错：" + ex.Message);
				return null;
			}
		}

		public byte[] DataReceived(byte[] data, int length)
		{
			try
			{
				if (length != 20 && length != 19)
				{
					int num = data[20];
					playerS playerS2 = players(data, 36);
					if (playerS2 != null)
					{
						switch (num)
						{
						case 0:
							if (playerS2.PhysicalAttackPlayer != null)
							{
								if ((playerS2.PhysicalAttackPlayer.ThreadState.ToString() == "Stopped" || playerS2.PhysicalAttackPlayer.ThreadState.ToString() == "Unstarted") && !playerS2.PhysicalAttackPlayer.ThreadState.ToString().Contains("StopRequested"))
								{
									ThreadParameter parameter5 = new ThreadParameter(data);
									playerS2.StartPhysicalAttackPlayer = 物理攻击人物包;
									playerS2.PhysicalAttackPlayer = new Thread(playerS2.StartPhysicalAttackPlayer);
									playerS2.PhysicalAttackPlayer.Start(parameter5);
								}
								else
								{
									Task.Factory.StartNew(物理攻击人物包, new ThreadParameter(data));
								}
							}
							else
							{
								ThreadParameter parameter6 = new ThreadParameter(data);
								playerS2.StartPhysicalAttackPlayer = 物理攻击人物包;
								playerS2.PhysicalAttackPlayer = new Thread(playerS2.StartPhysicalAttackPlayer);
								playerS2.PhysicalAttackPlayer.IsBackground = true;
								playerS2.PhysicalAttackPlayer.Start(parameter6);
							}
							break;
						case 1:
							if (playerS2.PhysicalAttackMonster != null)
							{
								if ((playerS2.PhysicalAttackMonster.ThreadState.ToString() == "Stopped" || playerS2.PhysicalAttackMonster.ThreadState.ToString() == "Unstarted") && !playerS2.PhysicalAttackMonster.ThreadState.ToString().Contains("StopRequested"))
								{
									ThreadParameter parameter7 = new ThreadParameter(data);
									playerS2.StartPhysicalAttackMonster = 物理攻击怪物包;
									playerS2.PhysicalAttackMonster = new Thread(playerS2.StartPhysicalAttackMonster);
									playerS2.PhysicalAttackMonster.Start(parameter7);
								}
								else if (playerS2.PhysicalAttackMonster1 == null)
								{
									ThreadParameter parameter8 = new ThreadParameter(data);
									playerS2.StartPhysicalAttackMonster1 = 物理攻击怪物包1;
									playerS2.PhysicalAttackMonster1 = new Thread(playerS2.StartPhysicalAttackMonster1);
									playerS2.PhysicalAttackMonster1.IsBackground = true;
									playerS2.PhysicalAttackMonster1.Start(parameter8);
								}
								else if ((playerS2.PhysicalAttackMonster1.ThreadState.ToString() == "Stopped" || playerS2.PhysicalAttackMonster1.ThreadState.ToString() == "Unstarted") && !playerS2.PhysicalAttackMonster1.ThreadState.ToString().Contains("StopRequested"))
								{
									ThreadParameter parameter9 = new ThreadParameter(data);
									playerS2.StartPhysicalAttackMonster1 = 物理攻击怪物包1;
									playerS2.PhysicalAttackMonster1 = new Thread(playerS2.StartPhysicalAttackMonster1);
									playerS2.PhysicalAttackMonster1.Start(parameter9);
								}
								else
								{
									Task.Factory.StartNew(物理攻击怪物包, new ThreadParameter(data));
								}
							}
							else
							{
								ThreadParameter parameter10 = new ThreadParameter(data);
								playerS2.StartPhysicalAttackMonster = 物理攻击怪物包;
								playerS2.PhysicalAttackMonster = new Thread(playerS2.StartPhysicalAttackMonster);
								playerS2.PhysicalAttackMonster.IsBackground = true;
								playerS2.PhysicalAttackMonster.Start(parameter10);
							}
							break;
						case 2:
							if (playerS2.MagicAttackPlayer != null)
							{
								if ((playerS2.MagicAttackPlayer.ThreadState.ToString() == "Stopped" || playerS2.MagicAttackPlayer.ThreadState.ToString() == "Unstarted") && !playerS2.MagicAttackPlayer.ThreadState.ToString().Contains("StopRequested"))
								{
									ThreadParameter parameter3 = new ThreadParameter(data, playerS2);
									playerS2.StartMagicAttackPlayer = 魔法攻击人物包;
									playerS2.MagicAttackPlayer = new Thread(playerS2.StartMagicAttackPlayer);
									playerS2.MagicAttackPlayer.Start(parameter3);
								}
								else
								{
									Task.Factory.StartNew(魔法攻击人物包, new ThreadParameter(data, playerS2));
								}
							}
							else
							{
								ThreadParameter parameter4 = new ThreadParameter(data, playerS2);
								playerS2.StartMagicAttackPlayer = 魔法攻击人物包;
								playerS2.MagicAttackPlayer = new Thread(playerS2.StartMagicAttackPlayer);
								playerS2.MagicAttackPlayer.IsBackground = true;
								playerS2.MagicAttackPlayer.Start(parameter4);
							}
							break;
						case 3:
							if (playerS2.MagicAttackMonster != null)
							{
								if ((playerS2.MagicAttackMonster.ThreadState.ToString() == "Stopped" || playerS2.MagicAttackMonster.ThreadState.ToString() == "Unstarted") && !playerS2.MagicAttackMonster.ThreadState.ToString().Contains("StopRequested"))
								{
									ThreadParameter parameter = new ThreadParameter(data);
									playerS2.StartMagicAttackMonster = 魔法攻击怪物包;
									playerS2.MagicAttackMonster = new Thread(playerS2.StartMagicAttackMonster);
									playerS2.MagicAttackMonster.Start(parameter);
								}
								else if (playerS2.MagicAttackMonster1 == null)
								{
									ThreadParameter parameter11 = new ThreadParameter(data);
									playerS2.StartMagicAttackMonster1 = 魔法攻击怪物包1;
									playerS2.MagicAttackMonster1 = new Thread(playerS2.StartMagicAttackMonster1);
									playerS2.MagicAttackMonster1.IsBackground = true;
									playerS2.MagicAttackMonster1.Start(parameter11);
								}
								else if ((playerS2.MagicAttackMonster1.ThreadState.ToString() == "Stopped" || playerS2.MagicAttackMonster1.ThreadState.ToString() == "Unstarted") && !playerS2.MagicAttackMonster1.ThreadState.ToString().Contains("StopRequested"))
								{
									ThreadParameter parameter12 = new ThreadParameter(data);
									playerS2.StartMagicAttackMonster1 = 魔法攻击怪物包1;
									playerS2.MagicAttackMonster1 = new Thread(playerS2.StartMagicAttackMonster1);
									playerS2.MagicAttackMonster1.Start(parameter12);
								}
								else if (playerS2.MagicAttackMonster2 == null)
								{
									ThreadParameter parameter13 = new ThreadParameter(data);
									playerS2.StartMagicAttackMonster2 = 魔法攻击怪物包2;
									playerS2.MagicAttackMonster2 = new Thread(playerS2.StartMagicAttackMonster2);
									playerS2.MagicAttackMonster2.IsBackground = true;
									playerS2.MagicAttackMonster2.Start(parameter13);
								}
								else if ((playerS2.MagicAttackMonster2.ThreadState.ToString() == "Stopped" || playerS2.MagicAttackMonster2.ThreadState.ToString() == "Unstarted") && !playerS2.MagicAttackMonster2.ThreadState.ToString().Contains("StopRequested"))
								{
									ThreadParameter parameter14 = new ThreadParameter(data);
									playerS2.StartMagicAttackMonster2 = 魔法攻击怪物包2;
									playerS2.MagicAttackMonster2 = new Thread(playerS2.StartMagicAttackMonster2);
									playerS2.MagicAttackMonster2.Start(parameter14);
								}
								else if (playerS2.MagicAttackMonster3 == null)
								{
									ThreadParameter parameter15 = new ThreadParameter(data);
									playerS2.StartMagicAttackMonster3 = 魔法攻击怪物包3;
									playerS2.MagicAttackMonster3 = new Thread(playerS2.StartMagicAttackMonster3);
									playerS2.MagicAttackMonster3.IsBackground = true;
									playerS2.MagicAttackMonster3.Start(parameter15);
								}
								else if ((playerS2.MagicAttackMonster3.ThreadState.ToString() == "Stopped" || playerS2.MagicAttackMonster3.ThreadState.ToString() == "Unstarted") && !playerS2.MagicAttackMonster3.ThreadState.ToString().Contains("StopRequested"))
								{
									ThreadParameter parameter16 = new ThreadParameter(data);
									playerS2.StartMagicAttackMonster3 = 魔法攻击怪物包3;
									playerS2.MagicAttackMonster3 = new Thread(playerS2.StartMagicAttackMonster3);
									playerS2.MagicAttackMonster3.Start(parameter16);
								}
								else if (playerS2.MagicAttackMonster4 == null)
								{
									ThreadParameter parameter17 = new ThreadParameter(data);
									playerS2.StartMagicAttackMonster4 = 魔法攻击怪物包4;
									playerS2.MagicAttackMonster4 = new Thread(playerS2.StartMagicAttackMonster4);
									playerS2.MagicAttackMonster4.IsBackground = true;
									playerS2.MagicAttackMonster4.Start(parameter17);
								}
								else if ((playerS2.MagicAttackMonster4.ThreadState.ToString() == "Stopped" || playerS2.MagicAttackMonster4.ThreadState.ToString() == "Unstarted") && !playerS2.MagicAttackMonster4.ThreadState.ToString().Contains("StopRequested"))
								{
									ThreadParameter parameter18 = new ThreadParameter(data);
									playerS2.StartMagicAttackMonster4 = 魔法攻击怪物包4;
									playerS2.MagicAttackMonster4 = new Thread(playerS2.StartMagicAttackMonster4);
									playerS2.MagicAttackMonster4.Start(parameter18);
								}
								else
								{
									Task.Factory.StartNew(魔法攻击怪物包5, new ThreadParameter(data));
								}
							}
							else
							{
								ThreadParameter parameter2 = new ThreadParameter(data);
								playerS2.StartMagicAttackMonster = 魔法攻击怪物包;
								playerS2.MagicAttackMonster = new Thread(playerS2.StartMagicAttackMonster);
								playerS2.MagicAttackMonster.IsBackground = true;
								playerS2.MagicAttackMonster.Start(parameter2);
							}
							break;
						case 4:
							playerS2.IsSkillStuck = true;
							break;
						case 5:
							playerS2.IsSkillStuck = false;
							break;
						default:
							return null;
						}
					}
					return null;
				}
				try
				{
					string[] array = Encoding.Default.GetString(data).Split('|');
					AtSend = new AttackServerConnector(int.Parse(array[1]));
					AtSend.Sestup(int.Parse(array[1]));
				}
				catch (Exception ex)
				{
					MainForm.WriteLine(1, "ATServer 出错1：" + ex.Message);
				}
				return null;
			}
			catch (Exception ex2)
			{
				MainForm.WriteLine(1, "攻击伺服器包出错：" + ex2.Message);
				return null;
			}
		}

		public playerS players(byte[] data, int lenght)
		{
			try
			{
				int num = 12;
				for (int i = 0; i < 12; i++)
				{
					if (data[22 + i] == 0)
					{
						num = i;
						break;
					}
				}
				byte[] array = new byte[num];
				Buffer.BlockCopy(data, 22, array, 0, array.Length);
				string @string = Encoding.Default.GetString(array);
				playerS value;
				return World.Players.TryGetValue(@string, out value) ? value : null;
			}
			catch
			{
				return null;
			}
		}
	}
}
