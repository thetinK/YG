using Authentication;
using Core;
using Network.Protocol;
using Security.MultiBoxing;
using ServerManagement;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using UI;
using Utilities;

namespace Network.TCP
{
    public class Listener : IDisposable
    {
        #region Constants and Fields

        // Constants - ค่าคงที่
        private const int MIN_WORLD_ID = 300;                    // World ID ต่ำสุด
        private const int MAX_WORLD_ID = 65500;                  // World ID สูงสุด
        private const int PRIORITY_THRESHOLD = 3000;             // เกณฑ์ความสำคัญ
        private const string LISTEN_ALL_IP = "0.0.0.0";         // ฟังทุก IP

        // Private Fields - ฟิลด์ส่วนตัว
        private readonly TcpServer server = new TcpServer();     // TCP Server instance
        private readonly Extra<ClientInfo> connectionPool = new Extra<ClientInfo>(); // Connection pool
        private AppState appState = AppState.Stoped;             // สถานะแอปพลิเคชัน
        private bool isDisposed;                                 // ตรวจสอบการ dispose

        // Connection tracking - ติดตามการเชื่อมต่อ
        private readonly ConcurrentDictionary<IPAddress, int> connectionCounts = new ConcurrentDictionary<IPAddress, int>();
        private readonly object worldIdLock = new object();

        #endregion

        #region Constructor and Initialization

        public Listener(ushort port)
        {
            try
            {
                InitializeServerEvents();
                StartListening(port);
                ComprehensiveLogger.WriteSystem($"เริ่มต้น Login Server Listener ที่พอร์ต {port} สำเร็จ");
            }
            catch (Exception ex)
            {
                SetAppState(AppState.Error);
                ComprehensiveLogger.WriteError($"ไม่สามารถ Initialize Listener ได้: {ex.Message}");
                throw;
            }
        }

        private void InitializeServerEvents()
        {
            server.OnPrepareListen += OnPrepareListen;
            server.OnAccept += OnAccept;
            server.OnSend += OnSend;
            server.OnPointerDataReceive += OnPointerDataReceive;
            server.OnClose += OnClose;
            server.OnShutdown += OnShutdown;
            SetAppState(AppState.Stoped);
        }

        #endregion

        #region Server Control Methods

        private void StartListening(ushort port)
        {
            try
            {
                SetAppState(AppState.Starting);
                server.IpAddress = LISTEN_ALL_IP;
                server.Port = port;
                server.SendPolicy = SendPolicy.Direct;

                if (server.Start(World.ServerIDStart))
                {
                    World.MainSocket = true;
                    ComprehensiveLogger.WriteSystem($"เริ่ม Listen บน {LISTEN_ALL_IP}:{port} สำเร็จ");
                    SetAppState(AppState.Started);
                }
                else
                {
                    SetAppState(AppState.Stoped);
                    throw new Exception($"Start Listening ล้มเหลว -> {server.ErrorMessage}({server.ErrorCode})");
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"Start Listening Error: {ex.Message}");
                throw;
            }
        }

        public void Stop()
        {
            if (isDisposed) return;

            try
            {
                SetAppState(AppState.Stoping);
                World.MainSocket = false;

                if (server.Stop())
                {
                    SetAppState(AppState.Stoped);
                    isDisposed = true;
                    ComprehensiveLogger.WriteSystem("Login Server หยุดทำงานสำเร็จ");
                }
                else
                {
                    ComprehensiveLogger.WriteError("หยุด Communication Service ล้มเหลว");
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"Stop Service Error: {ex.Message}");
            }
        }

        public void Dispose()
        {
            if (isDisposed) return;

            World.MainSocket = false;
            ComprehensiveLogger.WriteSystem("ปิด Login Service Listener Port");
            isDisposed = true;

            try
            {
                if (server != null)
                {
                    server.Destroy();
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"Dispose Communication Service Error: {ex.Message}");
            }
        }

        #endregion

        #region Connection Management

        private int GetNextAvailableWorldId()
        {
            lock (worldIdLock)
            {
                // First pass: Try priority range (300-3000)
                for (int i = MIN_WORLD_ID; i < PRIORITY_THRESHOLD; i++)
                {
                    if (!World.ConnectLst.ContainsKey(i))
                        return i;
                }

                // Second pass: Try full range (300-65500)
                for (int i = MIN_WORLD_ID; i < MAX_WORLD_ID; i++)
                {
                    if (!World.ConnectLst.ContainsKey(i))
                        return i;
                }

                ComprehensiveLogger.WriteError("ไม่มี World ID ที่ใช้งานได้!");
                return 0;
            }
        }

        private ClientInfo CreateClientInfo(IntPtr connId, string ip, ushort port)
        {
            try
            {
                return new ClientInfo
                {
                    ConnId = connId,
                    IpAddress = ip,
                    Port = port,
                    Server = server,
                    WorldId = GetNextAvailableWorldId()
                };
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"สร้าง Client Info ล้มเหลว: {ex.Message}");
                return null;
            }
        }

        private void DisconnectClient(IntPtr connId, string reason = "")
        {
            try
            {
                if (server.Disconnect(connId))
                {
                    ComprehensiveLogger.WriteNetwork($"Client {connId} ถูก Disconnect แล้ว. เหตุผล: {reason}");
                }
                else
                {
                    ComprehensiveLogger.WriteError($"Disconnect Client {connId} ล้มเหลว");
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"Disconnect Error: {ex.Message}");
            }
        }

        #endregion

        #region IP Security and Rate Limiting

        private bool IsIpBlocked(IPAddress clientIp)
        {
            return World.IPBlocking == 1 && World.BlockedIpList.Contains(clientIp);
        }

        private bool CheckConnectionLimit(IPAddress clientIp)
        {
            int currentConnections = 0;
            DateTime lastLoginTime = DateTime.Now;

            foreach (var netState in World.ConnectLst.Values)
            {
                if (netState.ToString() == clientIp.ToString())
                {
                    lastLoginTime = netState.LastLoginTime;
                    currentConnections++;
                }
            }

            if (currentConnections > World.MaxGameLoginConnections)
            {
                // Check if within time limit for blocking
                int timeDifference = (int)DateTime.Now.Subtract(lastLoginTime).TotalMilliseconds;
                return timeDifference >= World.MaxLoginConnectionTime;
            }

            return true;
        }

        private void HandleExcessiveConnections(IPAddress clientIp, IntPtr connId)
        {
            ComprehensiveLogger.WriteSecurity($"IP {clientIp} ถึง Max Connections แล้ว");

            if (World.AddToFilterList && !World.BlockedIpList.Contains(clientIp))
            {
                World.BlockedIpList.Add(clientIp);
                ComprehensiveLogger.WriteSecurity($"IP {clientIp} ถูกเพิ่มเข้า Block List");
            }

            DisconnectClient(connId, "Excessive Connections - เชื่อมต่อเกินจำนวน");

            // Disconnect all connections from this IP
            DisconnectAllFromIp(clientIp);
        }

        private void DisconnectAllFromIp(IPAddress clientIp)
        {
            try
            {
                var connectionsToRemove = new Queue();

                foreach (var netState in World.ConnectLst.Values)
                {
                    if (netState.ToString() == clientIp.ToString())
                    {
                        connectionsToRemove.Enqueue(netState);
                    }
                }

                while (connectionsToRemove.Count > 0)
                {
                    var netState = (NetState)connectionsToRemove.Dequeue();
                    netState.Dispose();
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"Disconnect All จาก IP {clientIp} Error: {ex.Message}");
            }
        }

        #endregion

        #region Event Handlers

        private HandleResult OnPrepareListen(IntPtr soListen)
        {
            return HandleResult.Ok;
        }

        private HandleResult OnAccept(IntPtr connId, IntPtr pClient)
        {
            string debugStep = "0";
            try
            {
                // Get client address
                debugStep = "1";
                string clientIp = string.Empty;
                ushort clientPort = 0;
                if (!server.GetRemoteAddress(connId, ref clientIp, ref clientPort))
                {
                    ComprehensiveLogger.WriteError($"[{connId}] ไม่สามารถ Get Remote Address ได้");
                    return HandleResult.Error;
                }

                // Basic connection validation
                debugStep = "2";
                if (!ConnInfo.Check(clientIp, clientPort))
                {
                    ConnInfo.Add(new ConnInfo
                    {
                        Ip = clientIp,
                        Port = clientPort,
                        Time = DateTime.Now,
                        Kill = true
                    });
                    ComprehensiveLogger.WriteSecurity($"Connection ถูก Restrict: IP={clientIp}, Port={clientPort}");
                    return HandleResult.Error;
                }

                var clientIpAddress = IPAddress.Parse(clientIp);

                // IP blocking check
                debugStep = "3";
                if (IsIpBlocked(clientIpAddress))
                {
                    if (World.DisconnectOnBlock) DisconnectClient(connId, "IP ถูก Block");
                    if (World.StopOnBlock) Stop();
                    return HandleResult.Error;
                }

                // Connection limit check
                debugStep = "4";
                if (!CheckConnectionLimit(clientIpAddress))
                {
                    HandleExcessiveConnections(clientIpAddress, connId);
                    return HandleResult.Error;
                }

                // Create and register client
                debugStep = "5";
                var clientInfo = CreateClientInfo(connId, clientIp, clientPort);
                if (clientInfo == null)
                {
                    ComprehensiveLogger.WriteError($"[{connId}] สร้าง Client Info ล้มเหลว");
                    return HandleResult.Error;
                }

                debugStep = "6";
                if (!connectionPool.Set(connId, clientInfo))
                {
                    ComprehensiveLogger.WriteError($"[{connId}] Set Connection ใน Pool ล้มเหลว");
                    return HandleResult.Error;
                }

                debugStep = "7";
                new NetState(clientInfo).Start();

                // Log successful connection
                ConnInfo.Add(new ConnInfo
                {
                    Ip = clientIp,
                    Port = clientPort,
                    Time = DateTime.Now,
                    Kill = false
                });

                ComprehensiveLogger.WriteActivity($"Client เชื่อมต่อ: {clientIp}:{clientPort} [ConnId: {connId}]");
                return HandleResult.Ok;
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"[{connId}][Step:{debugStep}] OnAccept Error: {ex.Message}");
                return HandleResult.Error;
            }
        }

        private HandleResult OnSend(IntPtr connId, byte[] bytes)
        {
            return HandleResult.Ok;
        }

        private HandleResult OnPointerDataReceive(IntPtr connId, IntPtr pData, int length)
        {
            try
            {
                var clientInfo = connectionPool.Get(connId);
                if (clientInfo == null || clientInfo.Client == null || length <= 0)
                {
                    return HandleResult.Error;
                }

                var dataBuffer = new byte[length];
                Marshal.Copy(pData, dataBuffer, 0, length);
                clientInfo.Client.ProcessDataReceived(dataBuffer, length);

                return HandleResult.Ok;
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"[{connId}] Data Receive Error: {ex.Message}");
                return HandleResult.Ignore;
            }
        }

        private HandleResult OnClose(IntPtr connId, SocketOperation operation, int errorCode)
        {
            string debugStep = "0";
            try
            {
                var clientInfo = connectionPool.Get(connId);
                if (clientInfo != null && clientInfo.Client != null && clientInfo.Client.Player != null)
                {
                    debugStep = "1";

                    // Find and logout player
                    string playerToLogout = string.Empty;
                    foreach (var player in World.Players.Values)
                    {
                        if (player.UserId == clientInfo.Client.Player.userId &&
                            clientInfo.Client.Player.loginprocess == 2)
                        {
                            playerToLogout = player.UserId;
                            break;
                        }
                    }

                    debugStep = "2";
                    if (!string.IsNullOrEmpty(playerToLogout))
                    {
                        World.LogoutPlayer(playerToLogout);
                    }

                    clientInfo.Client.Dispose();
                }

                debugStep = "3";
                if (!connectionPool.Remove(connId))
                {
                    debugStep = "4";
                    ComprehensiveLogger.WriteError($"[{connId}] Remove จาก Connection Pool ล้มเหลว - Step:{debugStep}, OP:{operation}, CODE:{errorCode}");
                }
                else
                {
                    ComprehensiveLogger.WriteActivity($"[{connId}] Connection ปิดสำเร็จ - OP:{operation}, CODE:{errorCode}");
                }
            }
            catch (Exception ex)
            {
                ComprehensiveLogger.WriteError($"[{connId}] Close Error - Step:{debugStep}, OP:{operation}, CODE:{errorCode}, Exception:{ex.Message}");
            }

            return HandleResult.Ok;
        }

        private HandleResult OnShutdown()
        {
            ComprehensiveLogger.WriteSystem("Communication Component Service หยุดทำงาน");
            return HandleResult.Ok;
        }

        #endregion

        #region Helper Methods

        private void SetAppState(AppState state)
        {
            appState = state;
            World.SocketState = appState.ToString();
        }

        #endregion
    }
}