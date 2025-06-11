using System;
using System.Collections.Generic;
using System.IO;

namespace Utilities
{
    public static class ComprehensiveLogger
    {
        // Log directory structure: Category/Date
        private const string LOG_DIR = "Logs";
        private static readonly object _lockObject = new object();

        // Log type to folder mapping (�¡��������͹)
        private static readonly Dictionary<string, string> LogFolders = new Dictionary<string, string>
        {
            { "Error", "Error" },
            { "System", "System" },
            { "Auth", "Auth" },
            { "Network", "Network" },
            { "Security", "Security" },
            { "Activity", "Activity" },
            { "Admin", "Admin" },
            { "Performance", "Performance" },
            { "Database", "Database" },
            { "MultiClient", "MultiClient" },
            { "Debug", "Debug" },
            { "Packet", "Packet" }
        };

        // Retention policy for different log types
        private static readonly Dictionary<string, int> RetentionDays = new Dictionary<string, int>
        {
            { "Error", 30 },        // Error �� 30 �ѹ
            { "Security", 90 },     // Security �� 90 �ѹ (�Ӥѭ)
            { "Auth", 14 },         // Auth �� 14 �ѹ
            { "Activity", 7 },      // Activity �� 7 �ѹ
            { "System", 30 },       // System �� 30 �ѹ
            { "Network", 14 },      // Network �� 14 �ѹ
            { "Admin", 60 },        // Admin �� 60 �ѹ (�Ӥѭ)
            { "Performance", 7 },   // Performance �� 7 �ѹ
            { "Database", 30 },     // Database �� 30 �ѹ
            { "MultiClient", 30 },  // MultiClient �� 30 �ѹ
            { "Debug", 3 },         // Debug �� 3 �ѹ
            { "Packet", 1 }         // Packet �� 1 �ѹ
        };

        #region Critical Logs
        // System errors and crashes
        public static void WriteError(string message) => WriteLog("Error", "ERROR", message);

        // Security violations and attacks
        public static void WriteSecurity(string message) => WriteLog("Security", "SECURITY", message);

        // Multi-client detection and violations
        public static void WriteMultiClient(string message) => WriteLog("MultiClient", "MULTICLIENT", message);
        #endregion

        #region Important Logs
        // Authentication events (login/logout)
        public static void WriteAuth(string message) => WriteLog("Auth", "AUTH", message);

        // Administrative actions
        public static void WriteAdmin(string message) => WriteLog("Admin", "ADMIN", message);

        // Player activity and connections
        public static void WriteActivity(string message) => WriteLog("Activity", "ACTIVITY", message);
        #endregion

        #region Monitoring Logs
        // Performance metrics and server health
        public static void WritePerformance(string message) => WriteLog("Performance", "PERF", message);

        // Network events and connectivity
        public static void WriteNetwork(string message) => WriteLog("Network", "NETWORK", message);

        // Database operations and queries
        public static void WriteDatabase(string message) => WriteLog("Database", "DB", message);

        // System events and startup/shutdown
        public static void WriteSystem(string message) => WriteLog("System", "SYSTEM", message);
        #endregion

        #region Debug Logs (Development Only)
        // Debug information for development
        public static void WriteDebug(string message) => WriteLog("Debug", "DEBUG", message, isDebug: true);

        // Packet tracing and protocol analysis
        public static void WritePacket(string message) => WriteLog("Packet", "PACKET", message, isDebug: true);
        #endregion

        // Generic log writer with thread safety and categorization
        private static void WriteLog(string logType, string category, string message, bool isDebug = false)
        {
            try
            {
                // Skip debug logs in production (you can add a config flag here)
#if !DEBUG
                if (isDebug) return;
#endif

                lock (_lockObject)
                {
                    // ���ҧ�ç���ҧ������: Logs/Error/2024-06-12.log
                    string logFolder = Path.Combine(LOG_DIR, LogFolders[logType]);
                    EnsureLogDirectory(logFolder);

                    string fileName = $"{DateTime.Now:yyyy-MM-dd}.log";
                    string filePath = Path.Combine(logFolder, fileName);
                    string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{category}] {message}\r\n";

                    using (var writer = new StreamWriter(new FileStream(filePath,
                        FileMode.Append, FileAccess.Write, FileShare.Read)))
                    {
                        writer.Write(logEntry);
                    }
                }
            }
            catch
            {
                // Silent fail to prevent logging errors from crashing the application
            }
        }

        // Ensure log directory exists
        private static void EnsureLogDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        #region Convenience Methods with IP and User Context
        // Log with IP address context
        public static void WriteSecurityWithIP(string clientIP, string message)
        {
            WriteSecurity($"[IP: {clientIP}] {message}");
        }

        // Log with user context
        public static void WriteAuthWithUser(string username, string clientIP, string message)
        {
            WriteAuth($"[User: {username}] [IP: {clientIP}] {message}");
        }

        // Log with server performance metrics
        public static void WritePerformanceMetrics(int connections, int players, int queueSize, double memoryMB)
        {
            WritePerformance($"Connections: {connections}, Players: {players}, Queue: {queueSize}, Memory: {memoryMB:F1}MB");
        }

        // Log multi-client violation with details
        public static void WriteMultiClientViolation(string username, string boundAccount, int connectionCount, int limit)
        {
            WriteMultiClient($"User: {username}, Bound: {boundAccount}, Connections: {connectionCount}/{limit} - VIOLATION");
        }
        #endregion

        #region Legacy Compatibility (�ͧ�Ѻ�����)
        // Backward compatibility with old logger
        public static void FileTxtLog(string errTxt) => WriteError(errTxt);
        public static void FileTxtLog1(string errTxt) => WriteMultiClient(errTxt);
        public static void FileTxtLog2(string errTxt) => WriteActivity(errTxt);
        public static void FileTxtLog3(string errTxt) => WriteSecurity(errTxt);
        #endregion

        #region Log File Management (��Ѻ��ا����)
        // Clean up old log files with retention policy
        public static void CleanOldLogs()
        {
            try
            {
                if (!Directory.Exists(LOG_DIR)) return;

                foreach (var kvp in LogFolders)
                {
                    string logFolder = Path.Combine(LOG_DIR, kvp.Value);
                    if (!Directory.Exists(logFolder)) continue;

                    int retentionDays = RetentionDays.ContainsKey(kvp.Key) ? RetentionDays[kvp.Key] : 30;
                    var cutoffDate = DateTime.Now.AddDays(-retentionDays);
                    var logFiles = Directory.GetFiles(logFolder, "*.log");

                    foreach (var file in logFiles)
                    {
                        var fileInfo = new FileInfo(file);
                        if (fileInfo.CreationTime < cutoffDate)
                        {
                            File.Delete(file);
                            WriteSystem($"Deleted old log file: {kvp.Value}/{fileInfo.Name} (older than {retentionDays} days)");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError($"Error cleaning old logs: {ex.Message}");
            }
        }

        // Manual cleanup for specific log type
        public static void CleanOldLogsByType(string logType, int daysToKeep)
        {
            try
            {
                if (!LogFolders.ContainsKey(logType)) return;

                string logFolder = Path.Combine(LOG_DIR, LogFolders[logType]);
                if (!Directory.Exists(logFolder)) return;

                var cutoffDate = DateTime.Now.AddDays(-daysToKeep);
                var logFiles = Directory.GetFiles(logFolder, "*.log");

                foreach (var file in logFiles)
                {
                    var fileInfo = new FileInfo(file);
                    if (fileInfo.CreationTime < cutoffDate)
                    {
                        File.Delete(file);
                        WriteSystem($"Manual cleanup: Deleted {logType}/{fileInfo.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError($"Error cleaning {logType} logs: {ex.Message}");
            }
        }

        // Get log statistics (compatible with older .NET Framework)
        public static void LogStatistics()
        {
            try
            {
                WriteSystem("=== Log Statistics ===");

                foreach (var kvp in LogFolders)
                {
                    string logFolder = Path.Combine(LOG_DIR, kvp.Value);
                    if (!Directory.Exists(logFolder))
                    {
                        WriteSystem($"{kvp.Key}: 0 files, 0.00 MB");
                        continue;
                    }

                    var logFiles = Directory.GetFiles(logFolder, "*.log");
                    long totalSize = 0;

                    foreach (var file in logFiles)
                    {
                        totalSize += new FileInfo(file).Length;
                    }

                    double sizeMB = totalSize / (1024.0 * 1024.0);
                    WriteSystem($"{kvp.Key}: {logFiles.Length} files, {sizeMB:F2} MB");
                }
            }
            catch (Exception ex)
            {
                WriteError($"Error generating log statistics: {ex.Message}");
            }
        }
        #endregion

        #region Monitoring and Health Check
        // Check if logging system is healthy
        public static bool IsLoggingHealthy()
        {
            try
            {
                // Test write to each critical log type
                string testMessage = $"Health check at {DateTime.Now:HH:mm:ss}";

                WriteError($"TEST: {testMessage}");
                WriteSecurity($"TEST: {testMessage}");
                WriteSystem($"TEST: {testMessage}");

                return true;
            }
            catch
            {
                return false;
            }
        }

        // Initialize logging system
        public static void Initialize()
        {
            try
            {
                WriteSystem("=== Logging System Initialized ===");
                WriteSystem($"Log directory: {Path.GetFullPath(LOG_DIR)}");
                WriteSystem($"Log types configured: {LogFolders.Count}");

                // Clean old logs on startup
                CleanOldLogs();

                // Log retention policy
                WriteSystem("=== Retention Policy ===");
                foreach (var kvp in RetentionDays)
                {
                    WriteSystem($"{kvp.Key}: {kvp.Value} days");
                }

                WriteSystem("=== Logging System Ready ===");
            }
            catch (Exception ex)
            {
                // This is a critical error if we can't initialize logging
                Console.WriteLine($"CRITICAL: Failed to initialize logging system: {ex.Message}");
            }
        }
        #endregion
    }
}
