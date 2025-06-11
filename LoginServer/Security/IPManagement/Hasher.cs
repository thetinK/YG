using System.Net;
using System.Net.Sockets;

namespace Security.IPManagement
{
	public class Hasher
	{
		public static string GetIP()
		{
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
				for (int i = 0; i < hostEntry.AddressList.Length; i++)
				{
					if (hostEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
					{
						return hostEntry.AddressList[i].ToString();
					}
				}
				return "";
			}
			catch
			{
				return "";
			}
		}
	}
}
