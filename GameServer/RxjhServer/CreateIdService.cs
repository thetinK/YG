namespace RxjhServer
{
	public static class CreateIdService
	{
		private static int BaseNPC_Id = 10000;

		private static int BaseConn_Id = 10000;

		public static int GetNpcId()
		{
			return ++BaseNPC_Id;
		}

		public static int GetUserConnId()
		{
			return ++BaseConn_Id;
		}
	}
}
