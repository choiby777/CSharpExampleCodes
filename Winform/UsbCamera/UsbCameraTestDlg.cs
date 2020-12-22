using GitHub.secile.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformExamples.UsbCameraTest
{
	public partial class UsbCameraTestDlg : Form
	{
		private bool isSnapshotRequested;
		private UsbCamera camera;

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
			camera = new UsbCamera(cameraIndex, formats[0]);
			camera.Start();

			// get image.
			// Immediately after starting the USB camera,
			// GetBitmap() fails because image buffer is not prepared yet.
			var bmp = camera.GetBitmap();

			// show image in PictureBox.
			var timer = new System.Timers.Timer(5) { SynchronizingObject = this };
			//timer.Elapsed += (s, ev) => pbxScreen.Image = camera.GetBitmap();
			timer.Elapsed += Timer_Elapsed;
			timer.Start();

			// release resource when close.
			this.FormClosing += (s, ev) => timer.Stop();
			this.FormClosing += (s, ev) => camera.Stop();
		}

		private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Bitmap bmp = camera.GetBitmap();
			pbxScreen.Image = bmp;

			if (isSnapshotRequested)
			{
				isSnapshotRequested = false;

				//string savePath = $@"C:\Temp\{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_Snapshot.bmp";
				//bmp.Save(savePath);
				pbSnapshot.Image = bmp;
			}
		}


		private void btnSaveSnapshot_Click(object sender, EventArgs e)
		{
			isSnapshotRequested = true;
		}
	}
}
