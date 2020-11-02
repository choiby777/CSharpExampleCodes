using GitHub.secile.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformExamples.UsbCameraTest
{
	public partial class UsbCameraTestDlg : Form
	{
		public UsbCameraTestDlg()
		{
			InitializeComponent();
		}

		private void btnStartCapture_Click(object sender, EventArgs e)
		{
			// [How to use]
			// check USB camera is available.
			string[] devices = UsbCamera.FindDevices();
			if (devices.Length == 0) return; // no camera.

			// check format.
			int cameraIndex = 0;
			UsbCamera.VideoFormat[] formats = UsbCamera.GetVideoFormat(cameraIndex);
			for (int i = 0; i < formats.Length; i++) Console.WriteLine("{0}:{1}", i, formats[i]);

			// create usb camera and start.
			var camera = new UsbCamera(cameraIndex, formats[0]);
			camera.Start();

			// get image.
			// Immediately after starting the USB camera,
			// GetBitmap() fails because image buffer is not prepared yet.
			var bmp = camera.GetBitmap();

			// show image in PictureBox.
			var timer = new System.Timers.Timer(5) { SynchronizingObject = this };
			timer.Elapsed += (s, ev) => pbxScreen.Image = camera.GetBitmap();
			timer.Start();

			// release resource when close.
			this.FormClosing += (s, ev) => timer.Stop();
			this.FormClosing += (s, ev) => camera.Stop();
		}
	}
}
