﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformExamples.PythonTest;
using WinformExamples.UsbCameraTest;

namespace WinformExamples
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnUsbCamera_Click(object sender, EventArgs e)
		{
			UsbCameraTestDlg dlg = new UsbCameraTestDlg();
			dlg.ShowDialog();
		}

		private void btnPythonTest_Click(object sender, EventArgs e)
		{
			PythonTestDlg dlg = new PythonTestDlg();
			dlg.ShowDialog();
		}
	}
}
