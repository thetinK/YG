using Core;
using Database;
using System;
using System.Threading;
using System.Timers;

namespace Authentication
{
	public class playerS
	{
		public System.Timers.Timer npcTimer = new System.Timers.Timer(600000.0);

		public System.Timers.Timer channelSwitchTimer = new System.Timers.Timer(15000.0);

		private string _boundAccount = string.Empty;
		public DateTime time;
		private string userid;
		private int _originalServerIndex;
		private string _originalServerIP;
		private string _originalServerPort;
		private int _originalServerID;
		private string _coinPlazaServerIP;
		private string _coinPlazaServerPort;
		private string username;
		private bool _loginout;
		private string _offlineAutoFarm;
		private int _channelSwitching;
		private string _UserIp;
		private string _ServerID;
		private string _WorldID;
		private string _goldSymbol;
		private string _profession;
		private int _conn;
		private bool _isSkillStuck;

        // Combat threads
        private Thread _magicAttackMonster;
		private ParameterizedThreadStart _startMagicAttackMonster;
		private Thread _magicAttackMonster1;
		private ParameterizedThreadStart _startMagicAttackMonster1;
		private Thread _magicAttackMonster2;
		private ParameterizedThreadStart _startMagicAttackMonster2;
		private Thread _magicAttackMonster3;
		private ParameterizedThreadStart _startMagicAttackMonster3;
		private Thread _magicAttackMonster4;
		private ParameterizedThreadStart _startMagicAttackMonster4;
		private Thread _physicalAttackMonster;
		private ParameterizedThreadStart _startPhysicalAttackMonster;
		private Thread _magicAttackPlayer;
		private ParameterizedThreadStart _startMagicAttackPlayer;
		private Thread _physicalAttackPlayer;
		private ParameterizedThreadStart _startPhysicalAttackPlayer;
		private Thread _physicalAttackMonster1;
		private ParameterizedThreadStart _startPhysicalAttackMonster1;

		public int _packetChannelSwitch;

        // Properties
        public string UserId
        {
            get { return userid; }
            set { userid = value; }
        }

        public int OriginalServerIndex
        {
            get { return _originalServerIndex; }
            set { _originalServerIndex = value; }
        }

        public string OriginalServerIP
        {
            get { return _originalServerIP; }
            set { _originalServerIP = value; }
        }

        public int PacketChannelSwitch
        {
            get { return _packetChannelSwitch; }
            set { _packetChannelSwitch = value; }
        }

        public string OriginalServerPort
        {
            get { return _originalServerPort; }
            set { _originalServerPort = value; }
        }

        public int OriginalServerID
        {
            get { return _originalServerID; }
            set { _originalServerID = value; }
        }

        public string CoinPlazaServerIP
        {
            get { return _coinPlazaServerIP; }
            set { _coinPlazaServerIP = value; }
        }

        public string CoinPlazaServerPort
        {
            get { return _coinPlazaServerPort; }
            set { _coinPlazaServerPort = value; }
        }

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public bool LoginOut
        {
            get { return _loginout; }
            set { _loginout = value; }
        }

        public string BoundAccount
        {
            get { return _boundAccount; }
            set { _boundAccount = value; }
        }

        public string OfflineAutoFarm
        {
            get { return _offlineAutoFarm; }
            set { _offlineAutoFarm = value; }
        }

        public int ChannelSwitching
        {
            get { return _channelSwitching; }
            set { _channelSwitching = value; }
        }

        public string UserIp
        {
            get { return _UserIp; }
            set { _UserIp = value; }
        }

        public string ServerID
        {
            get { return _ServerID; }
            set { _ServerID = value; }
        }

        public string WorldID
        {
            get { return _WorldID; }
            set { _WorldID = value; }
        }

        public string GoldSymbol
        {
            get { return _goldSymbol; }
            set { _goldSymbol = value; }
        }

        public string Profession
        {
            get { return _profession; }
            set { _profession = value; }
        }

        public int Connection
        {
            get { return _conn; }
            set { _conn = value; }
        }

        public TimeSpan OnlineTime => getsj();

		public bool IsSkillStuck
		{
			get
			{
				return _isSkillStuck;
			}
			set
			{
				_isSkillStuck = value;
			}
		}

        // Combat thread properties
        public Thread MagicAttackMonster
        {
            get { return _magicAttackMonster; }
            set { _magicAttackMonster = value; }
        }

        public ParameterizedThreadStart StartMagicAttackMonster
        {
            get { return _startMagicAttackMonster; }
            set { _startMagicAttackMonster = value; }
        }

        public Thread MagicAttackMonster1
        {
            get { return _magicAttackMonster1; }
            set { _magicAttackMonster1 = value; }
        }

        public ParameterizedThreadStart StartMagicAttackMonster1
        {
            get { return _startMagicAttackMonster1; }
            set { _startMagicAttackMonster1 = value; }
        }

        public Thread MagicAttackMonster2
        {
            get { return _magicAttackMonster2; }
            set { _magicAttackMonster2 = value; }
        }

        public ParameterizedThreadStart StartMagicAttackMonster2
        {
            get { return _startMagicAttackMonster2; }
            set { _startMagicAttackMonster2 = value; }
        }

        public Thread MagicAttackMonster3
        {
            get { return _magicAttackMonster3; }
            set { _magicAttackMonster3 = value; }
        }

        public ParameterizedThreadStart StartMagicAttackMonster3
        {
            get { return _startMagicAttackMonster3; }
            set { _startMagicAttackMonster3 = value; }
        }

        public Thread MagicAttackMonster4
        {
            get { return _magicAttackMonster4; }
            set { _magicAttackMonster4 = value; }
        }

        public ParameterizedThreadStart StartMagicAttackMonster4
        {
            get { return _startMagicAttackMonster4; }
            set { _startMagicAttackMonster4 = value; }
        }

        public Thread PhysicalAttackMonster
        {
            get { return _physicalAttackMonster; }
            set { _physicalAttackMonster = value; }
        }

        public ParameterizedThreadStart StartPhysicalAttackMonster
        {
            get { return _startPhysicalAttackMonster; }
            set { _startPhysicalAttackMonster = value; }
        }

        public Thread MagicAttackPlayer
        {
            get { return _magicAttackPlayer; }
            set { _magicAttackPlayer = value; }
        }

        public ParameterizedThreadStart StartMagicAttackPlayer
        {
            get { return _startMagicAttackPlayer; }
            set { _startMagicAttackPlayer = value; }
        }

        public Thread PhysicalAttackPlayer
        {
            get { return _physicalAttackPlayer; }
            set { _physicalAttackPlayer = value; }
        }

        public ParameterizedThreadStart StartPhysicalAttackPlayer
        {
            get { return _startPhysicalAttackPlayer; }
            set { _startPhysicalAttackPlayer = value; }
        }

        public Thread PhysicalAttackMonster1
        {
            get { return _physicalAttackMonster1; }
            set { _physicalAttackMonster1 = value; }
        }

        public ParameterizedThreadStart StartPhysicalAttackMonster1
        {
            get { return _startPhysicalAttackMonster1; }
            set { _startPhysicalAttackMonster1 = value; }
        }

        // Constructor
        public playerS()
		{
			LoginOut = false;
			time = DateTime.Now;
			npcTimer.Elapsed += TimeEndEvent;
			npcTimer.Enabled = true;
		}

		public void SwitchChannel()
		{
			ChannelSwitching = 1;
			channelSwitchTimer = new System.Timers.Timer(15000.0);
			channelSwitchTimer.Elapsed += ChannelSwitchTimeEndEvent;
			channelSwitchTimer.Enabled = true;
			channelSwitchTimer.AutoReset = false;
		}

		public void ChannelSwitchComplete()
		{
			ChannelSwitching = 0;
			if (RxjhClass.IsEquals(WorldID, "0"))
			{
				RxjhClass.SetUserIdONLINE(UserId);
				lock (World.Players)
				{
					World.Players.Remove(UserId);
				}
			}
			if (channelSwitchTimer != null)
			{
				channelSwitchTimer.Enabled = false;
				channelSwitchTimer.Close();
				channelSwitchTimer.Dispose();
				channelSwitchTimer = null;
			}
		}

		public void TimeEndEvent(object source, ElapsedEventArgs e)
		{
			if (Connection == 1)
			{
				RxjhClass.SetUserIdONLINE(UserId);
				World.Players.Remove(UserId);
			}
			npcTimer.Close();
			npcTimer.Dispose();
		}

		public void ChannelSwitchTimeEndEvent(object source, ElapsedEventArgs e)
		{
			if (ChannelSwitching == 1)
			{
				RxjhClass.SetUserIdONLINE(UserId);
				lock (World.Players)
				{
					World.Players.Remove(UserId);
				}
			}
			if (channelSwitchTimer != null)
			{
				channelSwitchTimer.Enabled = false;
				channelSwitchTimer.Close();
				channelSwitchTimer.Dispose();
				channelSwitchTimer = null;
			}
		}

		private TimeSpan getsj()
		{
			return DateTime.Now.Subtract(time);
		}
	}
}
