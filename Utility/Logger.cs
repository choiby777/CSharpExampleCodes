using Extension;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web.Script.Serialization;

namespace Utility
{
	public class Logger
	{
		enum LogLevel
		{
			DEBUG = 0,
			INFO = 1,
			INPORTANT = 2,
			ERROR = 3,
		}

		private static Logger instance;
		private bool isStop = false;
		private JavaScriptSerializer jsonConvertor;
		private ConcurrentQueue<LogData> logDataQueue;
		private string logDirPath;
		private Thread logFileWriteThread;

		private Logger(string logDir = null)
		{
			if (logDir.IsNullOrEmpty())
			{
				string baseDirPath = AppDomain.CurrentDomain.BaseDirectory;
				baseDirPath = baseDirPath.TrimEnd(new char[] { '\\' });

				logDir = baseDirPath + @"\Log";
			}

			jsonConvertor = new JavaScriptSerializer();
			StartLogger(logDir);
		}

		public static void Debug(string log, params object[] objects)
		{
			if (instance == null) return;

			instance.Write(LogLevel.DEBUG, instance.GetLogString(log, objects));
		}

		public static void Error(string log, params object[] objects)
		{
			if (instance == null) return;

			instance.Write(LogLevel.ERROR, instance.GetLogString(log, objects));
		}

		public static void Exception(Exception exception)
		{
			if (instance == null) return;

			instance.Write(LogLevel.ERROR, exception.ToString());
		}

		public static void Important(string log, params object[] objects)
		{
			if (instance == null) return;

			instance.Write(LogLevel.INPORTANT, instance.GetLogString(log, objects));
		}

		public static void Infomation(string log, params object[] objects)
		{
			if (instance == null) return;

			instance.Write(LogLevel.INFO, instance.GetLogString(log, objects));
		}

		public static void InitInstance(string dirPath = null)
		{
			if (instance != null) return;
			instance = new Logger(dirPath);
		}

		public static void StopLogger()
		{
			instance.isStop = true;

			if (instance.logFileWriteThread != null)
			{
				instance.logFileWriteThread = null;
			}
		}

		public static void Trace(string log, params object[] objects)
		{
#if DEBUG
			System.Diagnostics.Trace.WriteLine(instance.GetLogString(log, objects));
#endif
		}

		private void DeleteOldLogFiles()
		{
			try
			{
				string[] dirs = Directory.GetDirectories(logDirPath);

				foreach (string dir in dirs)
				{
					DirectoryInfo dirInfo = new DirectoryInfo(dir);

					if (IsValidDate(dirInfo.Name))
					{
						if (GetDayLength(dirInfo.Name) > 30)
						{
							FileUtil.DeleteDirectorySafely(dir, true);
							Trace("Delete : " + dir);
						}
					}
				}
			}
			catch
			{
			}
		}

		private int GetDayLength(string dateValue)
		{
			DateTime dt;
			DateTime.TryParseExact(dateValue, "yyyyMMdd", null, DateTimeStyles.None, out dt);

			TimeSpan sp = DateTime.Now - dt;
			return sp.Days;
		}

		private string GetLogFilePath(LogData logdata)
		{
			FileUtil.CreateDirectorySafely(logDirPath);

			return string.Format("{0}\\{1}.log",
								logDirPath,
								logdata.GetDateString());
		}

		private string GetLogString(string log, object[] objects)
		{
			string logValue = string.Empty;

			try
			{
				if (objects != null && objects.Length > 0)
				{
					logValue = string.Format(log, objects);
				}
				else
				{
					logValue = log;
				}
			}
			catch
			{
				logValue = log;
			}

			return logValue;
		}

		private bool IsValidDate(string dateValue)
		{
			DateTime dt;
			return DateTime.TryParseExact(dateValue, "yyyyMMdd", null, DateTimeStyles.None, out dt);
		}

		private void LogFileWriteThreadProc()
		{
			while (true)
			{
				Thread.Sleep(10);

				if (isStop) break;

				try
				{
					if (logDataQueue.Count == 0) continue;

					LogData logdata = new LogData();

					if (!logDataQueue.TryDequeue(out logdata)) continue;

					WriteLogDataToFile(logdata);
				}
				catch (Exception ex)
				{
					Trace(ex.ToString());
				}
			}
		}

		private void StartLogger(string logDir)
		{
			logDirPath = logDir;

			if (Directory.Exists(logDirPath) == false)
			{
				Directory.CreateDirectory(logDirPath);
			}
			else
			{
				DeleteOldLogFiles();
			}

			logDataQueue = new ConcurrentQueue<LogData>();

			if (logFileWriteThread == null)
			{
				logFileWriteThread = new Thread(LogFileWriteThreadProc);
				logFileWriteThread.IsBackground = true;
			}

			logFileWriteThread.Start();
		}

		private void Write(LogLevel nLevel, string strMessage)
		{
#if DEBUG
			if (nLevel != LogLevel.DEBUG)
			{
				Trace(string.Format("[{0}] : {1}", nLevel, strMessage));
			}

#endif
			try
			{
				StackTrace stackTrace = new StackTrace();           // get call stack

				LogData logdata = new LogData();
				logdata.LogLevel = nLevel;
				logdata.Message = strMessage;
				logdata.LogTime = DateTime.Now;
				logdata.ThreadID = Thread.CurrentThread.ManagedThreadId;
				logdata.StackFrams = stackTrace.GetFrames();

				logDataQueue.Enqueue(logdata);
			}
			catch (Exception ex)
			{
				Trace(ex.ToString());
			}
		}

		private void WriteLogDataToFile(LogData logdata)
		{
			try
			{
				string LogFilePath = GetLogFilePath(logdata);

				string LogText = jsonConvertor.Serialize(new LogDataForFile(logdata));

				FileStream LogFileStream = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
				StreamWriter StreamWriter = new StreamWriter(LogFileStream);

				//StreamWriter.WriteLine(LogText);
				StreamWriter.WriteLine(LogText);

				StreamWriter.Close();
				LogFileStream.Close();
			}
			catch (Exception ex)
			{
				Exception(ex);
			}
		}

		private struct LogData
		{

			public LogLevel LogLevel { get; set; }
			public DateTime LogTime { get; set; }
			public string Message { get; set; }
			public StackFrame[] StackFrams { get; set; }
			public int ThreadID { get; set; }

			public string GetDateString()
			{
				return LogTime.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
			}

			private string GetCaller()
			{
				string Caller = "";
				for (int i = 0; i < StackFrams.Length; i++)
				{
					if (StackFrams[i].GetMethod().DeclaringType == GetType())
					{
						continue;
					}

					if (StackFrams[i].GetMethod().ReflectedType.FullName.Contains("System."))
					{
						return Caller;
					}

					if (Caller.Length > 0)
					{
						Caller = "-" + Caller;
					}

					string CallerInfo = string.Format("{0}:{1}",
						StackFrams[i].GetMethod().DeclaringType.Name,
						StackFrams[i].GetMethod().Name);

					Caller = CallerInfo + Caller;
				}

				return "Unknown";
			}

			private void GetClassMethodInfo(ref string ClassName, ref string MethodName)
			{
				for (int i = 0; i < StackFrams.Length; i++)
				{
					if (StackFrams[i].GetMethod().DeclaringType != GetType())
					{
						ClassName = StackFrams[i].GetMethod().DeclaringType.Name;
						MethodName = StackFrams[i].GetMethod().Name;
						return;
					}
				}
			}

			private string GetTimeData()
			{
				return string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
							LogTime.Hour.ToString("00"),
							LogTime.Minute.ToString("00"),
							LogTime.Second.ToString("00"),
							LogTime.Millisecond.ToString("000"));
			}

		}

		private class LogDataForFile
		{

			public LogDataForFile(LogData logdata)
			{
				LogLevel = logdata.LogLevel;
				LogTime = logdata.LogTime.ToString("yyyy/MM/dd HH:mm:ss.fff");
				Message = logdata.Message;
				StackFrams = GetCaller(logdata.StackFrams);
				ThreadID = logdata.ThreadID;
			}

			public LogLevel LogLevel { get; set; }
			public string LogTime { get; set; }
			public int ThreadID { get; set; }
			public string Message { get; set; }
			public string StackFrams { get; set; }

			private string GetCaller(StackFrame[] stackFrams)
			{
				string Caller = "";
				for (int i = 0; i < stackFrams.Length; i++)
				{
					if (stackFrams[i].GetMethod().DeclaringType == GetType())
					{
						continue;
					}

					if (stackFrams[i].GetMethod().ReflectedType.FullName.Contains("System."))
					{
						return Caller;
					}

					if (Caller.Length > 0)
					{
						Caller = "-" + Caller;
					}

					string CallerInfo = string.Format("{0}:{1}",
						stackFrams[i].GetMethod().DeclaringType.Name,
						stackFrams[i].GetMethod().Name);

					Caller = CallerInfo + Caller;
				}

				return "Unknown";
			}

		}

	}
}
