using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Authentication;
using Core;
using Database;
using Network.Servers;
using Network.TCP;
using Threading;
using UI.Helpers;
using Utilities;

namespace UI
{
	public class MainForm : Form
	{
		#region Constants
		// Server startup configuration - Change these values as needed
		private const bool DEFAULT_ERROR_LOGGING = true; // Error logging enabled on startup
		#endregion

		#region Fields
		private static List<LogEntry> logEntries = new List<LogEntry>();
		private DateTime startTime = DateTime.Now;

		// Internal log entry class with timestamp
		private class LogEntry
		{
			public int Type { get; set; }
			public string Message { get; set; }
			public DateTime Timestamp { get; set; }

			public LogEntry(int type, string message, DateTime timestamp)
			{
				Type = type;
				Message = message ?? string.Empty;
				Timestamp = timestamp;
			}
		}

		private bool isShuttingDown;

		private Thread processThread;
		private Thread serverProcessThread;

		private World gameWorld;

		private System.Timers.Timer autoConnectTimer;
		private System.Timers.Timer banCheckTimer;
		private System.Timers.Timer multiClientCheckTimer;

		private Listener gameListener;
		private AuthenticationServer authServer;
		private GatewayServer gatewayServer;

		private IContainer components;

		private MenuStrip menuStrip1;
		private ToolStripMenuItem userToolStripMenuItem;
		private ToolStripMenuItem userListToolStripMenuItem;
		private FlickerFreePanel GraphPanel;
		private System.Windows.Forms.Timer timer1;
		private ToolStripMenuItem reloadConfigToolStripMenuItem;
		private StatusStrip statusStrip1;
		private ToolStripMenuItem sendAnnouncementToolStripMenuItem;
		private ToolStripMenuItem banIPListToolStripMenuItem;
		private ToolStripMenuItem IPListToolStripMenuItem;
		private ToolStrip toolStrip1;
		private ToolStripTextBox toolStripTextBox1;
		private ToolStripButton toolStripButton1;
		private System.Windows.Forms.Timer timer2;
		private ToolStripMenuItem autoConnectMenuItem;
		private ToolStripMenuItem startServerMenuItem;
		private ToolStripMenuItem enableErrorLoggingMenuItem;
		private ToolStripMenuItem kickAllUsersMenuItem;
		#endregion

		#region Constructor
		public MainForm()
		{
			InitializeComponent();
		}
		#endregion

		#region Graphics and Logging
		private void GraphPanel_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Graphics graphics = e.Graphics;
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.PixelOffsetMode = PixelOffsetMode.None;

				// Server status information
				string statusText = BuildStatusText();
				graphics.DrawString(statusText, DefaultFont, Brushes.Black, new Point(50, 5));

				// Draw log entries
				DrawLogEntries(graphics);
			}
			catch (Exception ex)
			{
				// Log paint errors
				WriteLine(1, $"Paint error: {ex.Message}");
			}
		}

		private string BuildStatusText()
		{
			TimeSpan uptime = DateTime.Now - startTime;
			return $"Uptime: {uptime:dd\\.hh\\:mm\\:ss}  " +
				   $"Connections: {World.ConnectLst.Count}  " +
				   $"Main Socket: {(World.MainSocket ? "Active" : "Inactive")}  " +
				   $"Servers: {World.ConnectedServers.Count}  " +
				   $"Online Players: {World.Players.Count}  " +
				   $"Login Queue: {World.Connect.Count}  " +
				   $"Lion Roar Queue: {World.lionRoarQueue.Count}";
		}

		private void DrawLogEntries(Graphics graphics)
		{
			const int lineHeight = 17;
			const int startY = 25; // Start below status text
			int yPosition = startY;

			lock (logEntries)
			{
				foreach (LogEntry item in logEntries)
				{
					Brush textBrush = GetLogBrush(item.Type);
					string logText = $"[{item.Timestamp:HH:mm:ss}] {item.Message}";
					graphics.DrawString(logText, DefaultFont, textBrush, new Point(5, yPosition));
					yPosition += lineHeight;
				}
			}
		}

		private Brush GetLogBrush(int logType)
		{
			return logType switch
			{
				1 => Brushes.Red,        // Error
				2 => Brushes.Orange,     // System
				3 => Brushes.Green,      // Auth/Success
				4 => Brushes.Teal,       // Network/Info
				5 => Brushes.Purple,     // Security
				6 => Brushes.Blue,       // Activity
				7 => Brushes.DarkBlue,   // Admin
				8 => Brushes.DarkGreen,  // Performance
				9 => Brushes.Brown,      // Database
				_ => Brushes.Black       // Default
			};
		}

		public static void WriteLine(int type, string message)
		{
			DateTime logTime = DateTime.Now;
			
			// Log to files based on type using new logger
			switch (type)
			{
				case 1:
					ComprehensiveLogger.WriteError(message);
					break;
				case 2:
					ComprehensiveLogger.WriteSystem(message);
					break;
				case 3:
					ComprehensiveLogger.WriteAuth(message);
					break;
				case 4:
					ComprehensiveLogger.WriteNetwork(message);
					break;
				case 5:
					ComprehensiveLogger.WriteSecurity(message);
					break;
				case 6:
					ComprehensiveLogger.WriteActivity(message);
					break;
				case 7:
					ComprehensiveLogger.WriteAdmin(message);
					break;
				case 8:
					ComprehensiveLogger.WritePerformance(message);
					break;
				case 9:
					ComprehensiveLogger.WriteDatabase(message);
					break;
				case 99:
					ComprehensiveLogger.WriteMultiClient(message);
					return; // Don't add to display for multi-client logs
			}
			
			// Add to display log with limit
			const int maxLogEntries = 20;
			lock (logEntries)
			{
				logEntries.Add(new LogEntry(type, message, logTime));
				
				if (logEntries.Count > maxLogEntries)
				{
					int removeCount = logEntries.Count - maxLogEntries;
					for (int i = 0; i < removeCount; i++)
					{
						logEntries.RemoveAt(0);
					}
				}
			}
		}
		#endregion

		#region Initialization
		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				WriteLine(3, "Starting RXJH Login Server...");

				// Initialize core systems
				InitializeCoreServices();

				// Start network listeners
				StartNetworkServices();

				// Start processing threads
				StartProcessingThreads();

				// Initialize timers
				InitializeTimers();

				// Update window title with server info
				UpdateWindowTitle();

				WriteLine(3, "RXJH Login Server started successfully");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Failed to start server: {ex.Message}");
				MessageBox.Show($"Failed to start server: {ex.Message}", "Startup Error", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void InitializeCoreServices()
		{

				gameWorld = new World();
				gameWorld.SetConfig();
			
				// Initialize menu states from configuration
				InitializeMenuStates();
			
				WriteLine(4, "Core services initialized");


		}

		private void InitializeMenuStates()
		{
			// Set auto-connect menu state
			autoConnectMenuItem.Checked = World.AutoConnect;
			
			// Set error logging menu state  
			enableErrorLoggingMenuItem.Checked = DEFAULT_ERROR_LOGGING;
			World.ErrorLoggingEnabled = DEFAULT_ERROR_LOGGING ? 1 : 0;
			
			// Display clear startup status
			WriteLine(3, "=== Server Configuration ===");
			WriteLine(3, $"Auto-Connect: {(World.AutoConnect ? "ENABLED" : "DISABLED")}");
			WriteLine(3, $"Error Logging: {(DEFAULT_ERROR_LOGGING ? "ENABLED" : "DISABLED")}");
			WriteLine(3, "=============================");
		}

		/// <summary>
		/// Get boolean configuration value with default fallback
		/// </summary>
		private bool GetConfigBool(string key, bool defaultValue)
		{
			try
			{
				// Try to read from World configuration or config file
				// This is a placeholder - replace with actual config reading logic
				// Example: return Config.GetBool(key, defaultValue);
				
				// For now, return default value
				return defaultValue;
			}
			catch (Exception ex)
			{
				WriteLine(2, $"Error reading config '{key}': {ex.Message}, using default: {defaultValue}");
				return defaultValue;
			}
		}

		private void StartNetworkServices()
		{
			try
			{
				// Start main game listener
				gameListener = new Listener((ushort)World.GameLoginServerPort);
				WriteLine(4, $"Game listener started on port {World.GameLoginServerPort}");

				// Start authentication server
				authServer = new AuthenticationServer("127.0.0.1", World.AccountVerificationServerPort);
				WriteLine(4, $"Authentication server started on port {World.AccountVerificationServerPort}");

				// Start combat server
				new CombatServer("127.0.0.1", World.AttackServerPort).Start();
				WriteLine(4, $"Combat server started on port {World.AttackServerPort}");

				// Initialize port tracking
				World.GameLoginServerPort1 = World.GameLoginServerPort;

				// Start gateway server
				gatewayServer = new GatewayServer("127.0.0.1", World.GatewayServerPort);
				gatewayServer.Start();
				WriteLine(4, $"Gateway server started on port {World.GatewayServerPort}");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Failed to start network services: {ex.Message}");
				throw;
			}
		}

		private void StartProcessingThreads()
		{
			try
			{
				processThread = new Thread(ProcessConnections)
				{
					Name = "ProcessConnections",
					IsBackground = true
				};
				processThread.Start();
				WriteLine(4, "Connection processing thread started");

				serverProcessThread = new Thread(ProcessServerQueue)
				{
					Name = "ProcessServerQueue",
					IsBackground = true
				};
				serverProcessThread.Start();
				WriteLine(4, "Server queue processing thread started");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Failed to start processing threads: {ex.Message}");
            }

		}

		private void InitializeTimers()
		{
			// Auto-connect timer (10 seconds)
			autoConnectTimer = new System.Timers.Timer(10000.0)
			{
				AutoReset = true,
				Enabled = true
			};
			autoConnectTimer.Elapsed += OnAutoConnect;

			// Ban check timer (1 hour)
			banCheckTimer = new System.Timers.Timer(3600000.0)
			{
				AutoReset = true,
				Enabled = true
			};
			banCheckTimer.Elapsed += OnBanCheck;

			// Multi-client check timer (3 minutes)
			multiClientCheckTimer = new System.Timers.Timer(180000.0)
			{
				AutoReset = true,
				Enabled = true
			};
			multiClientCheckTimer.Elapsed += OnMultiClientCheck;

			WriteLine(4, "Timers initialized successfully");
		}

		private void UpdateWindowTitle()
		{
			string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			Text = $"RXJH Login Server - {World.ServerName} v{version}";
		}
		#endregion

		#region Timer Events
		private void OnAutoConnect(object source, ElapsedEventArgs e)
		{
			try
			{
				autoConnectTimer.Interval = World.AutoConnectInterval * 1000;

				if (autoConnectMenuItem.Checked)
				{
					RestartListener();
					WriteLine(4, "Auto-reconnect: Listener restarted");
				}

				if (!World.MainSocket)
				{
					RestartListener();
					WriteLine(2, "Main socket inactive: Listener restarted");
				}
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Auto-connect error: {ex.Message}");
			}
		}

		private void RestartListener()
		{
			try
			{
				if (gameListener != null)
				{
					gameListener.Dispose();
				}

				Random random = new Random();
				World.GameLoginServerPort1 = World.GameLoginServerPort + random.Next(1, 101);
				gameListener = new Listener((ushort)World.GameLoginServerPort1);
				World.NotifyPortChange();

				WriteLine(4, $"Listener restarted on port {World.GameLoginServerPort1}");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Failed to restart listener: {ex.Message}");
			}
		}

		private void OnMultiClientCheck(object source, ElapsedEventArgs e)
		{
			try
			{
				PerformMultiClientDetection();
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Multi-client check error: {ex.Message}");
			}
		}

		private void OnBanCheck(object source, ElapsedEventArgs e)
		{
			try
			{
				World.CheckBannedAccounts();
				WriteLine(6, "Ban check completed");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Ban check error: {ex.Message}");
			}
		}
		#endregion

		#region Multi-Client Detection
		private void PerformMultiClientDetection()
		{
			var uniquePlayers = new ThreadSafeDictionary<string, playerS>();
			var duplicatePlayers = new ThreadSafeDictionary<string, playerS>();
			var processingQueue = Queue.Synchronized(new Queue());
			var boundAccounts = new List<string>();

			try
			{
				gameWorld.LoadMultiClientUsers();

				if (World.MultiClientCheckEnabled == 0)
					return;

				// Collect players with bound accounts
				CollectPlayersWithBoundAccounts(duplicatePlayers);

				// Process each unique bound account
				ProcessDuplicateAccounts(duplicatePlayers, uniquePlayers, processingQueue, boundAccounts);

				WriteLine(6, $"Multi-client check completed. Processed {duplicatePlayers.Count} players");
			}
			finally
			{
				// Cleanup
				processingQueue.Clear();
				boundAccounts.Clear();
				uniquePlayers.Clear();
				duplicatePlayers.Clear();
			}
		}

		private void CollectPlayersWithBoundAccounts(ThreadSafeDictionary<string, playerS> duplicatePlayers)
		{
			foreach (playerS player in (IEnumerable<playerS>)World.Players.Values)
			{
				if (IsValidPlayerForMultiClientCheck(player))
				{
					if (!duplicatePlayers.TryGetValue(player.UserId, out _))
					{
						duplicatePlayers.Add(player.UserId, player);
					}
				}
			}
		}

		private bool IsValidPlayerForMultiClientCheck(playerS player)
		{
			return player?.BoundAccount?.Length > 0 &&
				   int.Parse(player.OfflineAutoFarm) == 0 &&
				   player.UserId?.Length > 0;
		}

		private void ProcessDuplicateAccounts(
			ThreadSafeDictionary<string, playerS> duplicatePlayers,
			ThreadSafeDictionary<string, playerS> uniquePlayers,
			Queue processingQueue,
			List<string> boundAccounts)
		{
			foreach (playerS player in duplicatePlayers.Values)
			{
				if (!boundAccounts.Contains(player.BoundAccount))
				{
					boundAccounts.Add(player.BoundAccount);

					// Find all players with same bound account
					FindPlayersWithSameBoundAccount(player, duplicatePlayers, uniquePlayers);

					// Queue players for processing
					QueuePlayersForProcessing(uniquePlayers, processingQueue);

					// Handle excess connections
					HandleExcessConnections(processingQueue, player.BoundAccount);

					Thread.Sleep(5);
				}
			}
		}

		private void FindPlayersWithSameBoundAccount(
			playerS targetPlayer,
			ThreadSafeDictionary<string, playerS> duplicatePlayers,
			ThreadSafeDictionary<string, playerS> uniquePlayers)
		{
			foreach (playerS checkPlayer in duplicatePlayers.Values)
			{
				if (RxjhClass.IsEquals(targetPlayer.BoundAccount, checkPlayer.BoundAccount) &&
					!uniquePlayers.TryGetValue(checkPlayer.UserId, out _))
				{
					uniquePlayers.Add(checkPlayer.UserId, checkPlayer);
				}
			}
		}

		private void QueuePlayersForProcessing(
			ThreadSafeDictionary<string, playerS> uniquePlayers,
			Queue processingQueue)
		{
			foreach (playerS queuePlayer in uniquePlayers.Values)
			{
				processingQueue.Enqueue(queuePlayer);
			}
		}

		private void HandleExcessConnections(Queue processingQueue, string boundAccount)
		{
			int violationCount = 0;
			while (processingQueue.Count > World.MaxMultiClientCount)
			{
				var excessPlayer = (playerS)processingQueue.Dequeue();

				// Check if player has multi-client privileges
				if (HasMultiClientPrivilege(excessPlayer, processingQueue.Count))
					continue;

				// Apply punishment based on configuration
				ApplyMultiClientPunishment(excessPlayer);
				violationCount++;
				Thread.Sleep(5);
			}

			if (violationCount > 0)
			{
				WriteLine(2, $"Multi-client violation: {violationCount} players punished for account {boundAccount}");
			}
		}

		private bool HasMultiClientPrivilege(playerS player, int currentCount)
		{
			if (World.RunMoreClass.TryGetValue(player.BoundAccount, out var privilege) &&
				DateTime.Now < privilege.Time &&
				currentCount <= privilege.Number)
			{
				return true;
			}
			return false;
		}

		private void ApplyMultiClientPunishment(playerS player)
		{
			switch (World.MultiClientAction)
			{
				case 1: // Kick player
					WriteLine(99, $"Multi-client kick - Account: {player.UserId}, Bound: {player.BoundAccount}");
					KickPlayer(player);
					break;

				case 2: // Ban account
					WriteLine(99, $"Multi-client ban - Account: {player.UserId}, Bound: {player.BoundAccount}");
					BanPlayer(player);
					break;

				default:
					WriteLine(2, $"Unknown multi-client action: {World.MultiClientAction}");
					break;
			}
		}

		private void KickPlayer(playerS player)
		{
			var targetPlayer = World.QueryPlayer(player.UserId);
			if (targetPlayer != null)
			{
				World.Players.Remove(player.UserId);
				World.KickPlayerFromServer(targetPlayer.ServerID, targetPlayer.WorldID);
				targetPlayer.npcTimer?.Dispose();
			}
		}

		private void BanPlayer(playerS player)
		{
			KickPlayer(player);
			DBA.ExeSqlCommand($"UPDATE TBL_ACCOUNT SET FLD_ZT=24 WHERE FLD_ID='{player.UserId}'", "rxjhaccount");
		}
		#endregion

		#region Menu Event Handlers
		private void autoConnectMenuItem_Click(object sender, EventArgs e)
		{
			// Toggle the checked state manually
			autoConnectMenuItem.Checked = !autoConnectMenuItem.Checked;
			
			string status = autoConnectMenuItem.Checked ? "ENABLED" : "DISABLED";
			WriteLine(3, $"Auto-Connect: {status}");
			
			// Update auto-connect timer interval if enabled
			if (autoConnectMenuItem.Checked)
			{
				autoConnectTimer.Interval = World.AutoConnectInterval * 1000;
				WriteLine(4, $"Auto-connect timer set to {World.AutoConnectInterval} seconds");
			}
			else
			{
				WriteLine(4, "Auto-connect timer disabled");
			}
		}

		private void startServerMenuItem_Click(object sender, EventArgs e)
		{
			if (gameListener != null)
			{
				gameListener.Dispose();
				gameListener = null;
				WriteLine(3, "Game listener stopped");
				return;
			}

			RestartListener();
			WriteLine(3, "Game listener started");
		}

		private void userListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				new userlist().ShowDialog();
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error opening user list: {ex.Message}");
			}
		}

		private void reloadConfigToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				gameWorld.SetConfig();
				WriteLine(3, "Configuration reloaded successfully");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error reloading configuration: {ex.Message}");
			}
		}

		private void sendAnnouncementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				new FormGg().ShowDialog();
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error opening announcement form: {ex.Message}");
			}
		}

		private void banIPListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				new BinIP().ShowDialog();
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error opening banned IP list: {ex.Message}");
			}
		}

		private void ipListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				new FormIpList().ShowDialog();
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error opening IP list: {ex.Message}");
			}
		}

		private void kickAllUsersMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to kick all users?", "Confirm Action",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}

			try
			{
				int kickedCount = 0;
				lock (World.Players)
				{
					var playersToKick = new List<playerS>();
					foreach (playerS player in (IEnumerable<playerS>)World.Players.Values)
					{
						if (player != null)
						{
							playersToKick.Add(player);
						}
					}

					foreach (var player in playersToKick)
					{
						World.Players.Remove(player.UserId);
						World.KickPlayerFromServer(player.ServerID, player.WorldID);
						player.npcTimer?.Dispose();
						kickedCount++;
						Thread.Sleep(5);
					}
				}
				WriteLine(3, $"Successfully kicked {kickedCount} users from server");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error kicking all users: {ex.Message}");
			}
		}

		private void enableErrorLoggingMenuItem_Click(object sender, EventArgs e)
		{
			// Toggle the checked state manually
			enableErrorLoggingMenuItem.Checked = !enableErrorLoggingMenuItem.Checked;
			
			// Update the world setting
			World.ErrorLoggingEnabled = enableErrorLoggingMenuItem.Checked ? 1 : 0;

			string status = enableErrorLoggingMenuItem.Checked ? "ENABLED" : "DISABLED";
			WriteLine(3, $"Error Logging: {status}");
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
				{
					WriteLine(2, "No hex data entered");
					return;
				}

				byte[] data = Converter.hexStringToByte(toolStripTextBox1.Text);
				int sentCount = 0;

				foreach (NetState connection in World.ConnectLst.Values)
				{
					if (connection != null)
					{
						connection.Send(data, data.Length);
						sentCount++;
					}
				}

				WriteLine(3, $"Sent hex data to {sentCount} connections: {toolStripTextBox1.Text}");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error sending hex data: {ex.Message}");
			}
		}
		#endregion

		#region Processing Threads
		private void ProcessConnections()
		{
			WriteLine(4, "Connection processing thread started");
			try
			{
				while (!isShuttingDown)
				{
					// Check if we need to restart listener due to connection limit
					if (!autoConnectMenuItem.Checked && 
						World.ConnectLst.Count > World.MaxGameLoginConnections)
					{
						RestartListener();
						WriteLine(2, $"Connection limit exceeded ({World.ConnectLst.Count}), listener restarted");
					}

					Thread.Sleep(1);
					World.ProcessDisposedQueue();
				}
			}
			catch (ThreadAbortException)
			{
				WriteLine(4, "Connection processing thread stopped");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"ProcessConnections Error: {ex.Message}");
				if (!isShuttingDown)
				{
					// Restart thread if not shutting down
					Thread.Sleep(1000);
					processThread = new Thread(ProcessConnections)
					{
						Name = "ProcessConnections",
						IsBackground = true
					};
					processThread.Start();
					WriteLine(4, "Connection processing thread restarted");
				}
			}
		}

		private void ProcessServerQueue()
		{
			WriteLine(4, "Server queue processing thread started");
			try
			{
				while (!isShuttingDown)
				{
					Thread.Sleep(1);
					World.ProcessSerQueue();
				}
			}
			catch (ThreadAbortException)
			{
				WriteLine(4, "Server queue processing thread stopped");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"ProcessServerQueue Error: {ex.Message}");
				if (!isShuttingDown)
				{
					Thread.Sleep(1000);
					serverProcessThread = new Thread(ProcessServerQueue)
					{
						Name = "ProcessServerQueue",
						IsBackground = true
					};
					serverProcessThread.Start();
					WriteLine(4, "Server queue processing thread restarted");
				}
			}
		}
		#endregion

		#region Timer Handlers
		private void timer1_Tick(object sender, EventArgs e)
		{
			GraphPanel.Invalidate();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			try
			{
				World.ProcessLionRoarQueue();
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Lion Roar queue processing error: {ex.Message}");
			}
		}
		#endregion

		#region Shutdown
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to close the server?", "Confirm Exit",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				e.Cancel = true;
				return;
			}

			WriteLine(3, "Shutting down server...");
			ShutdownServer();
		}

		private void ShutdownServer()
		{
			try
			{
				isShuttingDown = true;
				Thread.Sleep(100); // Give threads time to notice shutdown

				// Stop processing threads
				StopProcessingThreads();

				// Dispose network components
				DisposeNetworkComponents();

				// Dispose timers
				DisposeTimers();

				WriteLine(3, "Server shutdown completed");
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error during shutdown: {ex.Message}");
			}
		}

		private void StopProcessingThreads()
		{
			try
			{
				if (processThread != null)
				{
					processThread.Abort();
					processThread.Join(1000);
					processThread = null;
				}

				if (serverProcessThread != null)
				{
					serverProcessThread.Abort();
					serverProcessThread.Join(1000);
					serverProcessThread = null;
				}
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error stopping threads: {ex.Message}");
			}
		}

		private void DisposeNetworkComponents()
		{
			try
			{
				gameListener?.Dispose();
				gameListener = null;

				authServer?.Dispose();
				authServer = null;

				gatewayServer?.Dispose();
				gatewayServer = null;
			}
			catch (Exception ex)
			{
				WriteLine(1, $"Error disposing network components: {ex.Message}");
			}
		}

		private void DisposeTimers()
		{
			DisposeTimer(ref autoConnectTimer);
			DisposeTimer(ref banCheckTimer);
			DisposeTimer(ref multiClientCheckTimer);
		}

		private void DisposeTimer(ref System.Timers.Timer timer)
		{
			if (timer != null)
			{
				timer.Enabled = false;
				timer.Close();
				timer.Dispose();
				timer = null;
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			WriteLine(3, "Application closed");
		}
		#endregion

		#region Designer Code
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
			menuStrip1 = new MenuStrip();
			userToolStripMenuItem = new ToolStripMenuItem();
			autoConnectMenuItem = new ToolStripMenuItem();
			startServerMenuItem = new ToolStripMenuItem();
			userListToolStripMenuItem = new ToolStripMenuItem();
			reloadConfigToolStripMenuItem = new ToolStripMenuItem();
			sendAnnouncementToolStripMenuItem = new ToolStripMenuItem();
			banIPListToolStripMenuItem = new ToolStripMenuItem();
			IPListToolStripMenuItem = new ToolStripMenuItem();
			kickAllUsersMenuItem = new ToolStripMenuItem();
			enableErrorLoggingMenuItem = new ToolStripMenuItem();
			timer1 = new System.Windows.Forms.Timer(components);
			toolStrip1 = new ToolStrip();
			toolStripTextBox1 = new ToolStripTextBox();
			toolStripButton1 = new ToolStripButton();
			timer2 = new System.Windows.Forms.Timer(components);
			GraphPanel = new FlickerFreePanel();
			statusStrip1 = new StatusStrip();
			menuStrip1.SuspendLayout();
			toolStrip1.SuspendLayout();
			GraphPanel.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(20, 20);
			menuStrip1.Items.AddRange(new ToolStripItem[] {
			userToolStripMenuItem});
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(878, 25);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// userToolStripMenuItem
			// 
			userToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
			autoConnectMenuItem,
			startServerMenuItem,
			userListToolStripMenuItem,
			reloadConfigToolStripMenuItem,
			sendAnnouncementToolStripMenuItem,
			banIPListToolStripMenuItem,
			IPListToolStripMenuItem,
			kickAllUsersMenuItem,
			enableErrorLoggingMenuItem});
			userToolStripMenuItem.Name = "userToolStripMenuItem";
			userToolStripMenuItem.Size = new Size(53, 21);
			userToolStripMenuItem.Text = "Server";
			// 
			// autoConnectMenuItem
			// 
			autoConnectMenuItem.CheckOnClick = false; // Disable automatic checking
			autoConnectMenuItem.Name = "autoConnectMenuItem";
			autoConnectMenuItem.Size = new Size(180, 22);
			autoConnectMenuItem.Text = "Auto Connect";
			autoConnectMenuItem.Click += new EventHandler(autoConnectMenuItem_Click);
			// 
			// startServerMenuItem
			// 
			startServerMenuItem.Name = "startServerMenuItem";
			startServerMenuItem.Size = new Size(180, 22);
			startServerMenuItem.Text = "Start/Stop Server";
			startServerMenuItem.Click += new EventHandler(startServerMenuItem_Click);
			// 
			// userListToolStripMenuItem
			// 
			userListToolStripMenuItem.Name = "userListToolStripMenuItem";
			userListToolStripMenuItem.Size = new Size(180, 22);
			userListToolStripMenuItem.Text = "User List";
			userListToolStripMenuItem.Click += new EventHandler(userListToolStripMenuItem_Click);
			// 
			// reloadConfigToolStripMenuItem
			// 
			reloadConfigToolStripMenuItem.Name = "reloadConfigToolStripMenuItem";
			reloadConfigToolStripMenuItem.Size = new Size(180, 22);
			reloadConfigToolStripMenuItem.Text = "Reload Config";
			reloadConfigToolStripMenuItem.Click += new EventHandler(reloadConfigToolStripMenuItem_Click);
			// 
			// sendAnnouncementToolStripMenuItem
			// 
			sendAnnouncementToolStripMenuItem.Name = "sendAnnouncementToolStripMenuItem";
			sendAnnouncementToolStripMenuItem.Size = new Size(180, 22);
			sendAnnouncementToolStripMenuItem.Text = "Send Announcement";
			sendAnnouncementToolStripMenuItem.Click += new EventHandler(sendAnnouncementToolStripMenuItem_Click);
			// 
			// banIPListToolStripMenuItem
			// 
			banIPListToolStripMenuItem.Name = "banIPListToolStripMenuItem";
			banIPListToolStripMenuItem.Size = new Size(180, 22);
			banIPListToolStripMenuItem.Text = "Banned IP List";
			banIPListToolStripMenuItem.Click += new EventHandler(banIPListToolStripMenuItem_Click);
			// 
			// IPListToolStripMenuItem
			// 
			IPListToolStripMenuItem.Name = "IPListToolStripMenuItem";
			IPListToolStripMenuItem.Size = new Size(180, 22);
			IPListToolStripMenuItem.Text = "Active IP List";
			IPListToolStripMenuItem.Click += new EventHandler(ipListToolStripMenuItem_Click);
			// 
			// kickAllUsersMenuItem
			// 
			kickAllUsersMenuItem.Name = "kickAllUsersMenuItem";
			kickAllUsersMenuItem.Size = new Size(180, 22);
			kickAllUsersMenuItem.Text = "Kick All Users";
			kickAllUsersMenuItem.Click += new EventHandler(kickAllUsersMenuItem_Click);
			// 
			// enableErrorLoggingMenuItem
			// 
			enableErrorLoggingMenuItem.CheckOnClick = false; // Disable automatic checking
			enableErrorLoggingMenuItem.Name = "enableErrorLoggingMenuItem";
			enableErrorLoggingMenuItem.Size = new Size(180, 22);
			enableErrorLoggingMenuItem.Text = "Enable Error Logging";
			enableErrorLoggingMenuItem.Click += new EventHandler(enableErrorLoggingMenuItem_Click);
			// 
			// timer1
			// 
			timer1.Enabled = true;
			timer1.Interval = 500;
			timer1.Tick += new EventHandler(timer1_Tick);
			// 
			// toolStrip1
			// 
			toolStrip1.ImageScalingSize = new Size(20, 20);
			toolStrip1.Items.AddRange(new ToolStripItem[] {
			toolStripTextBox1,
			toolStripButton1});
			toolStrip1.Location = new Point(0, 25);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(878, 25);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "toolStrip1";
			// 
			// toolStripTextBox1
			// 
			toolStripTextBox1.Font = new Font("Microsoft YaHei UI", 9F);
			toolStripTextBox1.Name = "toolStripTextBox1";
			toolStripTextBox1.Size = new Size(200, 25);
			toolStripTextBox1.ToolTipText = "Enter hex data to send to all connections (e.g., 00 80 04 00)";
			// 
			// toolStripButton1
			// 
			toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
			toolStripButton1.ImageTransparentColor = Color.Magenta;
			toolStripButton1.Name = "toolStripButton1";
			toolStripButton1.Size = new Size(36, 22);
			toolStripButton1.Text = "Send";
			toolStripButton1.ToolTipText = "Send hex data to all active connections";
			toolStripButton1.Click += new EventHandler(toolStripButton1_Click);
			// 
			// timer2
			// 
			timer2.Enabled = true;
			timer2.Interval = 21000;
			timer2.Tick += new EventHandler(timer2_Tick);
			// 
			// GraphPanel
			// 
			GraphPanel.BackColor = Color.White;
			GraphPanel.BorderStyle = BorderStyle.Fixed3D;
			GraphPanel.Controls.Add(statusStrip1);
			GraphPanel.Dock = DockStyle.Fill;
			GraphPanel.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			GraphPanel.Location = new Point(0, 50);
			GraphPanel.Name = "GraphPanel";
			GraphPanel.Size = new Size(878, 438);
			GraphPanel.TabIndex = 0;
			GraphPanel.Paint += new PaintEventHandler(GraphPanel_Paint);
			// 
			// statusStrip1
			// 
			statusStrip1.ImageScalingSize = new Size(20, 20);
			statusStrip1.Location = new Point(0, 412);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new Size(874, 22);
			statusStrip1.TabIndex = 0;
			statusStrip1.Text = "Ready";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(6F, 12F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(878, 488);
			Controls.Add(GraphPanel);
			Controls.Add(toolStrip1);
			Controls.Add(menuStrip1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			MinimumSize = new Size(800, 400);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "RXJH Login Server";
			FormClosing += new FormClosingEventHandler(Form1_FormClosing);
			FormClosed += new FormClosedEventHandler(Form1_FormClosed);
			Load += new EventHandler(Form1_Load);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			GraphPanel.ResumeLayout(false);
			GraphPanel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}