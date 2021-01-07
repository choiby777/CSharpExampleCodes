﻿using System;
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
using WinformExamples.PythonTest;
using WinformExamples.UsbCameraTest;

namespace WinformExamples
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			Logger.InitInstance();
			Logger.Debug("Test Log!!");
		}

		private void btnUsbCamera_Click(object sender, EventArgs e)
		{
			Logger.Infomation("Execute UsbCamera");

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
	}
}
