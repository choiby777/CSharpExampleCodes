using AForge.Video;
using AForge.Video.DirectShow;
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
	/// <summary>
	/// Using AForge API
	/// http://www.aforgenet.com/
	/// </summary>
	public partial class UsbCamera2TestDlg : Form
	{
		private FilterInfoCollection fic;
		private VideoCaptureDevice vcd;
		private bool isSnapshotRequested;
		public UsbCamera2TestDlg()
		{
			InitializeComponent();

			this.Load += UsbCamera2TestDlg_Load;
		}

		private void UsbCamera2TestDlg_Load(object sender, EventArgs e)
		{
			fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);

			for (int i = 0; i < fic.Count; i++)
			{
				cbDevice.Items.Add(fic[i].Name);
			}

			if (cbDevice.Items.Count > 0) cbDevice.SelectedIndex = 0;
			btnStartCapture.Enabled = (cbDevice.Items.Count > 0);

			videoSourcePlayer.NewFrame += VideoSourcePlayer_NewFrame;
		}

		private void btnStartCapture_Click(object sender, EventArgs e)
		{
			if (btnStartCapture.Text == "Start")
			{
				btnStartCapture.Text = "Stop";
				StartCameraCapture();
			}
			else
			{
				StopCameraCaoture();
				btnStartCapture.Text = "Start";
			}
		}

		private void btnSaveSnapshot_Click(object sender, EventArgs e)
		{
			isSnapshotRequested = true;
		}

		private void StartCameraCapture()
		{
			if (vcd == null || !vcd.IsRunning)
			{
				FilterInfo filterInfo = fic[cbDevice.SelectedIndex];
				vcd = new VideoCaptureDevice(filterInfo.MonikerString);
				vcd.NewFrame += videoCaptureDevice_NewFrame;
				vcd.Start();
			}
		}

		private void StopCameraCaoture()
		{
			if (vcd != null && vcd.IsRunning)
			{
				vcd.NewFrame -= videoCaptureDevice_NewFrame;
				vcd.SignalToStop();
				vcd.WaitForStop();
				vcd = null;
			}
		}

		private void videoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			Bitmap image = eventArgs.Frame;
			this.Invoke(new DisplayImageDelegate(DisplayImage), image);
		}

		private delegate void DisplayImageDelegate(Bitmap image);
		private void DisplayImage(Bitmap image)
		{
			pbScreen.Image = image;
			pbScreen.Update();

			if (isSnapshotRequested)
			{
				isSnapshotRequested = false;

				pbSnapshot.Image = image;
				pbSnapshot.Update();
			}
		}

		private void btnStart2_Click(object sender, EventArgs e)
		{
			FilterInfo filterInfo = fic[cbDevice.SelectedIndex];
			vcd = new VideoCaptureDevice(filterInfo.MonikerString);

			OpenVideoSource(vcd);
		}

		public void OpenVideoSource(IVideoSource source)
		{
			try
			{
				// stop current video source
				CloseCurrentVideoSource();

				// start new video source
				videoSourcePlayer.VideoSource = source;
				videoSourcePlayer.Start();
			}
			catch { }
		}

		public void CloseCurrentVideoSource()
		{
			try
			{

				if (videoSourcePlayer.VideoSource != null)
				{
					videoSourcePlayer.SignalToStop();

					// wait ~ 3 seconds
					for (int i = 0; i < 30; i++)
					{
						if (!videoSourcePlayer.IsRunning)
							break;
						System.Threading.Thread.Sleep(100);
					}

					if (videoSourcePlayer.IsRunning)
					{
						videoSourcePlayer.Stop();
					}

					videoSourcePlayer.VideoSource = null;
				}
			}
			catch { }
		}


		private void VideoSourcePlayer_NewFrame(object sender, ref Bitmap image)
		{
			this.Invoke(new DisplayImageDelegate(DisplayImage), image);
		}

	}
}
