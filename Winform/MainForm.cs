using CLRExample;
using Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using WinformExamples.fo_dicom;
using WinformExamples.GUIControls;
using WinformExamples.PythonTest;
using WinformExamples.RestAPI;
using WinformExamples.UsbCameraTest;

namespace WinformExamples
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			StartPosition = FormStartPosition.CenterScreen;

			Logger.InitInstance();
			Logger.Debug("Test Log!!");

			string test = "123456";
			test = test.RemoveLastCharacter();
		}

		private void btnUsbCamera_Click(object sender, EventArgs e)
		{
			Logger.Infomation("Execute Function");

			UsbCameraTestDlg dlg = new UsbCameraTestDlg();
			dlg.ShowDialog();
		}

		private void btnPythonTest_Click(object sender, EventArgs e)
		{
			PythonTestDlg dlg = new PythonTestDlg();
			dlg.ShowDialog();
		}

		private void btnFoDiocom_Click(object sender, EventArgs e)
		{
			FoDicomDlg dlg = new FoDicomDlg();
			dlg.ShowDialog();
		}

		private void btnUsbCamera2_Click(object sender, EventArgs e)
		{
			UsbCamera2TestDlg dlg = new UsbCamera2TestDlg();
			dlg.ShowDialog();
		}

		private void btnRestSharp_Click(object sender, EventArgs e)
		{
			RestApiTestDlg dlg = new RestApiTestDlg();
			dlg.ShowDialog();
		}

		private void btnGuiControls_Click(object sender, EventArgs e)
		{
			GUIControlsExample dlg = new GUIControlsExample();
			dlg.ShowDialog();
		}

		private void btnCLRTest_Click(object sender, EventArgs e)
		{
			CLRUtil util = new CLRUtil();

			CLRUtil.Sample sample;
			sample.InputArr = new byte[10];

			for (int i = 0; i < sample.InputArr.Length; i++)
			{
				sample.InputArr[i] = (byte)i;
			}

			sample.test = 50;
			sample.stringValue = "Hello";

			string stringValue = string.Empty;
			int intValue = 0;
			double doubleValue = 0;

			byte[] inputArr = new byte[255];
			byte[] outputArr = null;
			for (int i = 0; i < inputArr.Length; i++)
			{
				inputArr[i] = (byte)i;
			}

			util.FunctionTest(
				ref stringValue,
				ref intValue,
				ref doubleValue,
				inputArr,
				ref outputArr,
				sample);

			Console.WriteLine($"stringValue : {stringValue} , intValue : {intValue} , doubleValue : {doubleValue} , .stringValue : {sample.stringValue}");
		}
	}
}
