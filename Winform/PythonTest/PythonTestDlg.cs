using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformExamples.PythonTest
{
	public partial class PythonTestDlg : Form
	{
		public PythonTestDlg()
		{
			InitializeComponent();

			txtPythonDir.Text = @"C:\Workspace\Xmaru Pro\[Output]\Debug\Bin\IMPManager_x64\Python";
			//txtPythonDir.Text = @"C:\Users\v10821\AppData\Local\Programs\Python\Python36";


			txtModuleDirPath.Text = @"C:\Workspace\Xmaru Pro\[Output]\Debug\Bin\IMPManager_x64\ABS\TSpine";
			txtModuleName.Text = "TSpine";
			txtModelDirPath.Text = @"C:\Workspace\Xmaru Pro\[Output]\Debug\Bin\IMPManager_x64\ABS\TSpine\model";
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
			PythonTest pythonTest = new PythonTest(txtPythonDir.Text , txtModuleDirPath.Text, txtModelDirPath.Text);
			pythonTest.SetEnvironmentPath();
			pythonTest.StartPythonEnv(txtModuleName.Text);
		}
	}
}
