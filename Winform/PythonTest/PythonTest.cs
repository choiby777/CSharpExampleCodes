using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformExamples.PythonTest
{
	class PythonTest
	{
		private string pythonDirPath;
		private string moduleDirPath;
		private string modelDirPath;

		public PythonTest(string pythonDirPath, string moduleDirPath, string modelDirPath)
		{
			this.pythonDirPath = pythonDirPath;
			this.moduleDirPath = moduleDirPath;
			this.modelDirPath = modelDirPath;
		}

		public void SetEnvironmentPath()
		{
			var pythonHome = Environment.ExpandEnvironmentVariables(pythonDirPath);
			var pythonSite = Environment.ExpandEnvironmentVariables($@"{pythonDirPath}\Lib\site-packages");

			// 환경 변수 설정
			AddEnvPath(pythonHome);
			AddEnvPath(pythonSite);
			AddEnvPath(moduleDirPath);
			AddEnvPath(modelDirPath);
			AddEnvPath(@"C:\Workspace\Xmaru Pro\[Output]\Debug\Bin\IMPManager_x64\ABS\TSpine\weights");

			// Python 홈 설정.
			PythonEngine.PythonHome = pythonHome;

			// 모듈 패키지 설정
			PythonEngine.PythonPath = string.Join(
				System.IO.Path.PathSeparator.ToString(),
				new string[] {
						PythonEngine.PythonPath,
						System.IO.Path.Combine(pythonHome, @"Lib\site-packages"),	// pip하면 설치되는 패키지 폴더.
						modelDirPath,
						@"C:\Workspace\Xmaru Pro\[Output]\Debug\Bin\IMPManager_x64\ABS\TSpine\weights"
				});
		}

		private void AddEnvPath(params string[] paths)
		{
			// PC에 설정되어 있는 환경 변수를 가져온다.
			var envPaths = Environment.GetEnvironmentVariable("PATH").Split(System.IO.Path.PathSeparator).ToList();
			
			// 중복 환경 변수가 없으면 list에 넣는다.
			envPaths.InsertRange(0, paths.Where(x => x.Length > 0 && !envPaths.Contains(x)).ToArray());
			
			// 환경 변수를 재설정
			Environment.SetEnvironmentVariable("PATH", string.Join(System.IO.Path.PathSeparator.ToString(), envPaths), EnvironmentVariableTarget.Process);
			Environment.SetEnvironmentVariable("PYTHONPATH", string.Join(System.IO.Path.PathSeparator.ToString(), envPaths), EnvironmentVariableTarget.Process);
		}



		public void StartPythonEnv(string moduleName)
		{
			try
			{
				PythonEngine.Initialize();

				using (Py.GIL())
				{
					dynamic tspinePyFile = Py.Import(moduleName);

					string dicomFilePath = @"D:\T-Spine LAT.dcm";

					dynamic TSpint = tspinePyFile.TSpine();

					TSpint.logTest();

					dynamic result = TSpint.analysys(dicomFilePath);

					Console.WriteLine(result.ToString());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
