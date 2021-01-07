using System;
using System.Collections.Generic;
using System.IO;
using Extension;

namespace Utility
{
	public static class FileUtil
	{
		static int MaxLeght_Path = 260;

		enum MachineType : ushort
		{
			IMAGE_FILE_MACHINE_UNKNOWN = 0x0,
			IMAGE_FILE_MACHINE_AM33 = 0x1d3,
			IMAGE_FILE_MACHINE_AMD64 = 0x8664,
			IMAGE_FILE_MACHINE_ARM = 0x1c0,
			IMAGE_FILE_MACHINE_EBC = 0xebc,
			IMAGE_FILE_MACHINE_I386 = 0x14c,
			IMAGE_FILE_MACHINE_IA64 = 0x200,
			IMAGE_FILE_MACHINE_M32R = 0x9041,
			IMAGE_FILE_MACHINE_MIPS16 = 0x266,
			IMAGE_FILE_MACHINE_MIPSFPU = 0x366,
			IMAGE_FILE_MACHINE_MIPSFPU16 = 0x466,
			IMAGE_FILE_MACHINE_POWERPC = 0x1f0,
			IMAGE_FILE_MACHINE_POWERPCFP = 0x1f1,
			IMAGE_FILE_MACHINE_R4000 = 0x166,
			IMAGE_FILE_MACHINE_SH3 = 0x1a2,
			IMAGE_FILE_MACHINE_SH3DSP = 0x1a3,
			IMAGE_FILE_MACHINE_SH4 = 0x1a6,
			IMAGE_FILE_MACHINE_SH5 = 0x1a8,
			IMAGE_FILE_MACHINE_THUMB = 0x1c2,
			IMAGE_FILE_MACHINE_WCEMIPSV2 = 0x169,
		}

		public static string[] FileSearch(string strDir, string strMatch, bool bSubDir)
		{
			if (Directory.Exists(strDir) == false || strMatch.Length <= 0)
				return null;

			using (FindFiles.FileSystemEnumerator fse = new FindFiles.FileSystemEnumerator(strDir, strMatch, bSubDir))
			{
				IEnumerator<FileInfo> ien = fse.Matches().GetEnumerator();
				ien.Dispose();

				int nSearched = 0;
				int index = 0;
				string[] strResult = null;
				foreach (FileInfo fi in fse.Matches())
				{
					nSearched++;
				}
				if (nSearched > 0)
				{
					strResult = new string[nSearched];
					foreach (FileInfo fi in fse.Matches())
					{
						strResult[index++] = fi.FullName;
					}
				}
				return strResult;
			}
		}

		public static bool IsExist(string path)
		{
			if (IsDirectory(path)) return Directory.Exists(path);
			else return File.Exists(path);
		}

		public static bool IsDirectory(string path)
		{
			if (path.Length >= MaxLeght_Path) return false;
			DirectoryInfo dirInfo = new DirectoryInfo(path);
			return dirInfo.Attributes.ToString().ToLower() == "Directory".ToLower();
		}

		public static bool CreateDirectorySafely(string strDir)
		{
			bool bSuccess = false;

			try
			{
				if (Directory.Exists(strDir) == false)
					Directory.CreateDirectory(strDir);

				bSuccess = true;
			}
			catch (Exception ex)
			{
				//Logger.Exception(ex);
			}

			return bSuccess;
		}

		public static bool IsFileLocked(string filePath)
		{
			return IsFileLocked(new FileInfo(filePath));
		}

		public static bool IsFileLocked(FileInfo file)
		{
			try
			{
				using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
				{
					stream.Close();
				}
			}
			catch (IOException)
			{
				//the file is unavailable because it is:
				//still being written to
				//or being processed by another thread
				//or does not exist (has already been processed)
				return true;
			}

			//file is not locked
			return false;
		}

		public static bool CopyFileSafely(string strSrcFile, string strDstFile, bool bOverwrite = true)
		{
			bool bSuccess = false;

			try
			{
				string strErrMsg = string.Empty;

				if (File.Exists(strSrcFile) == false)
				{
					strErrMsg = string.Format("{0} Not Exist", strSrcFile);
					//Logger.Error("CopyFileSafely Error : " + strErrMsg);
					return false;
				}

				File.Copy(strSrcFile, strDstFile, bOverwrite);
				bSuccess = true;
			}
			catch (Exception ex)
			{
				//Logger.Exception(ex);
			}

			return bSuccess;
		}

		public static bool DeleteDirectorySafely(string strDir, bool bRecursive)
		{
			bool bSuccess = false;

			try
			{
				if (Directory.Exists(strDir))
					Directory.Delete(strDir, bRecursive);
				bSuccess = true;
			}
			catch (Exception ex)
			{
				//Logger.Exception(ex);
			}

			return bSuccess;
		}

		public static bool DeleteFileSafely(string strDelFile)
		{
			bool bReturn = false;

			if (File.Exists(strDelFile) == false)
			{
				//Logger.Debug(_LOGLEVEL.ACTION, "UtilMngr", "DeleteFileSafely", string.Format("DeleteFileSafely File not found\r\nFileName : {0}", strDelFile));
				return true;
			}

			try
			{
				File.Delete(strDelFile);
				bReturn = true;
			}
			catch (Exception ex)
			{
				System.Threading.Thread.Sleep(100);
				FileInfo fInfo = new FileInfo(strDelFile);
				fInfo.Attributes = FileAttributes.Normal;
				try
				{
					File.Delete(strDelFile);
					bReturn = true;
				}
				catch (Exception eex)
				{
					bReturn = false;

					System.Threading.Thread.Sleep(100);
					fInfo = new FileInfo(strDelFile);
					fInfo.Attributes = FileAttributes.Normal;
					try
					{
						File.Delete(strDelFile);
						bReturn = true;
					}
					catch (Exception eeex)
					{
						bReturn = false;
					}
				}
			}

			return bReturn;
		}

		public static bool DeleteAllFilesAndFoldersInDirectorySafely(string dirPath, bool isRecursive)
		{
			bool isSuccess = false;

			DirectoryInfo dirInfo = new DirectoryInfo(dirPath);

			try
			{
				if (Directory.Exists(dirPath))
				{
					foreach (FileInfo file in dirInfo.GetFiles())
					{
						DeleteFileSafely(file.FullName);
					}

					foreach (DirectoryInfo dir in dirInfo.GetDirectories())
					{
						DeleteDirectorySafely(dir.FullName, isRecursive);
					}

				}
				isSuccess = true;
			}
			catch (Exception ex)
			{
				//Logger.Exception(ex);
			}
			return isSuccess;
		}


		public static bool GetFileLengthSafely(string strFilePath, ref long length)
		{
			bool bSuccess = false;

			try
			{
				if (File.Exists(strFilePath) == false)
					return false;

				FileInfo fi = new FileInfo(strFilePath);
				length = fi.Length;
				bSuccess = true;
			}
			catch (Exception ex)
			{
				//Logger.Exception(ex);
			}

			return bSuccess;
		}

		public static bool IsEmptyDirectory(string dirPath)
		{
			if (Directory.Exists(dirPath) == false)
			{
				return false;
			}// else

			System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(dirPath);

			DirectoryInfo[] dirList = dirInfo.GetDirectories();

			FileInfo[] fileList = dirInfo.GetFiles();

			if (dirList.HasValue()) return false;
			if (fileList.HasValue()) return false;

			return true;
		}

		public static bool IsExistSubDirectory(string dirPath)
		{
			if (Directory.Exists(dirPath) == false)
			{
				return false;
			}// else

			DirectoryInfo[] subDirs = GetSubDirectoryList(dirPath);

			if (subDirs == null || subDirs.Length == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public static DirectoryInfo[] GetSubDirectoryList(string dirPath)
		{
			if (Directory.Exists(dirPath) == false)
			{
				return null;
			}// else

			System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(dirPath);

			return dirInfo.GetDirectories();
		}

		public static FileInfo[] GetFileList(string dirPath)
		{
			if (Directory.Exists(dirPath) == false)
			{
				return null;
			}// else

			System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(dirPath);

			return dirInfo.GetFiles();
		}

		public static bool ByteArrayToFile(string fileName, byte[] byteArray)
		{
			try
			{
				using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
				{
					fs.Write(byteArray, 0, byteArray.Length);
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool Is64BitDll(string dllPath)
		{
			switch (GetDllMachineType(dllPath))
			{
				case MachineType.IMAGE_FILE_MACHINE_AMD64:
				case MachineType.IMAGE_FILE_MACHINE_IA64:
					return true;
				case MachineType.IMAGE_FILE_MACHINE_I386:
					return false;
				default:
					return false;
			}
		}

		private static MachineType GetDllMachineType(string dllPath)
		{
			// See http://www.microsoft.com/whdc/system/platform/firmware/PECOFF.mspx
			// Offset to PE header is always at 0x3C.
			// The PE header starts with "PE\0\0" =  0x50 0x45 0x00 0x00,
			// followed by a 2-byte machine type field (see the document above for the enum).
			//
			FileStream fs = new FileStream(dllPath, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);
			fs.Seek(0x3c, SeekOrigin.Begin);
			Int32 peOffset = br.ReadInt32();
			fs.Seek(peOffset, SeekOrigin.Begin);
			UInt32 peHead = br.ReadUInt32();

			if (peHead != 0x00004550) // "PE\0\0", little-endian
				throw new Exception("Can't find PE header");

			MachineType machineType = (MachineType)br.ReadUInt16();
			br.Close();
			fs.Close();
			return machineType;
		}
	}
}
