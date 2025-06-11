using System;
using System.Runtime.InteropServices;

namespace RxjhServer
{
	internal class UserClass
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1
		{
			public string usri1_name;

			public string usri1_password;

			public int usri1_password_age;

			public int usri1_priv;

			public string usri1_home_dir;

			public string comment;

			public int usri1_flags;

			public string usri1_script_path;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_0
		{
			public string Username;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LOCALGROUP_USERS_INFO_0
		{
			public string groupname;
		}

		[DllImport("Netapi32.dll")]
		public static extern int NetUserAdd([MarshalAs(UnmanagedType.LPWStr)] string servername, int level, ref USER_INFO_1 buf, int parm_err);

		[DllImport("Netapi32.dll")]
		public static extern int NetUserDel([MarshalAs(UnmanagedType.LPWStr)] string servername, [MarshalAs(UnmanagedType.LPWStr)] string username);

		[DllImport("Netapi32.dll")]
		public static extern int NetUserGetInfo([MarshalAs(UnmanagedType.LPWStr)] string servername, [MarshalAs(UnmanagedType.LPWStr)] string username, int level, out IntPtr bufptr);

		[DllImport("Netapi32.dll")]
		public static extern int NetUserSetInfo([MarshalAs(UnmanagedType.LPWStr)] string servername, [MarshalAs(UnmanagedType.LPWStr)] string username, int level, ref USER_INFO_1 buf, int error);

		[DllImport("Netapi32.dll")]
		public static extern int NetUserChangePassword([MarshalAs(UnmanagedType.LPWStr)] string domainname, [MarshalAs(UnmanagedType.LPWStr)] string username, [MarshalAs(UnmanagedType.LPWStr)] string oldpassword, [MarshalAs(UnmanagedType.LPWStr)] string newpassword);

		[DllImport("Netapi32.dll")]
		private static extern int NetUserEnum([MarshalAs(UnmanagedType.LPWStr)] string servername, int level, int filter, out IntPtr bufptr, int prefmaxlen, out int entriesread, out int totalentries, out int resume_handle);

		[DllImport("Netapi32.dll")]
		private static extern int NetApiBufferFree(IntPtr Buffer);

		[DllImport("Netapi32.dll")]
		public static extern int NetUserGetLocalGroups([MarshalAs(UnmanagedType.LPWStr)] string servername, [MarshalAs(UnmanagedType.LPWStr)] string username, int level, int flags, out IntPtr bufptr, int prefmaxlen, out int entriesread, out int totalentries);
	}
}
