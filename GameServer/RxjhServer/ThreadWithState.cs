using System.Threading;

namespace RxjhServer
{
	public class ThreadWithState
	{
		private readonly Players play;

		private readonly 武功类 武功;

		private readonly NpcClass npcTemp;

		private readonly int 人物ID;

		private readonly int 临时武功;

		private readonly string UserName;

		private readonly int Map;

		private readonly string X;

		private readonly string Y;

		public ThreadWithState(Players play, 武功类 武功, NpcClass npcTemp, int 人物ID, int 临时武功)
		{
			this.play = play;
			this.武功 = 武功;
			this.npcTemp = npcTemp;
			this.人物ID = 人物ID;
			this.临时武功 = 临时武功;
		}

		public ThreadWithState(Players playe, string name, string x, string y, int map)
		{
			play = playe;
			UserName = name;
			Map = map;
			X = x;
			Y = y;
		}

		public void ThreadProc()
		{
			Thread.Sleep(1100);
			play.攻击计算(武功, npcTemp, 武功.FLD_PID, 人物ID, 临时武功);
			play.武功连击记数器++;
		}

		public void ThreadProc2()
		{
			play.换线人物登陆(UserName, X, Y, Map);
		}
	}
}
