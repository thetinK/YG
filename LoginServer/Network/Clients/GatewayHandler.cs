using Core;
using Delegates;
using System;
using System.Net.Sockets;
using System.Text;
using UI;

namespace Network.Clients
{
	public class GatewayHandler : GatewaySocketClient
	{
		private string _ServerId;

		public string ServerId
		{
			get
			{
				return _ServerId;
			}
			set
			{
				_ServerId = value;
			}
		}

		public void Logout()
		{
			MainForm.WriteLine(3, "网关服务器已断开 ID：" + ServerId);
		}

		public GatewayHandler(Socket from, RemoveWGClientDelegate rftsl)
			: base(from, rftsl)
		{
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
				else if (World.ErrorLoggingEnabled == 1)
				{
					MainForm.WriteLine(1, "错包：" + data[0] + " " + data[1]);
				}
				return null;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, "出错：" + ex.Message);
				return null;
			}
		}

		public byte[] DataReceived(byte[] data, int length)
		{
			int num = 0;
			try
			{
				string @string = Encoding.Default.GetString(data);
				num = 11;
				MainForm.WriteLine(3, "网关服务器收到：" + @string);
				num = 1;
				string[] array = @string.Split('|');
				num = 2;
				string text = array[0];
				if (text != null && text == "服务器连接登陆")
				{
					num = 3;
					ServerId = array[1];
					num = 4;
					World.端口更换通知(ServerId);
					num = 5;
					MainForm.WriteLine(3, "网关服务器连接成功 ID：" + array[1]);
				}
				return null;
			}
			catch (Exception ex)
			{
				MainForm.WriteLine(1, num + "|出错：" + ex.Message);
				return null;
			}
		}
	}
}
