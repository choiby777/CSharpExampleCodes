namespace WinformExamples.UsbCameraTest
{
	partial class UsbCamera2TestDlg
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pbSnapshot = new System.Windows.Forms.PictureBox();
			this.btnSaveSnapshot = new System.Windows.Forms.Button();
			this.pbScreen = new System.Windows.Forms.PictureBox();
			this.btnStartCapture = new System.Windows.Forms.Button();
			this.cbDevice = new System.Windows.Forms.ComboBox();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
			this.btnStart2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbSnapshot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// pbSnapshot
			// 
			this.pbSnapshot.Location = new System.Drawing.Point(12, 471);
			this.pbSnapshot.Name = "pbSnapshot";
			this.pbSnapshot.Size = new System.Drawing.Size(656, 407);
			this.pbSnapshot.TabIndex = 7;
			this.pbSnapshot.TabStop = false;
			// 
			// btnSaveSnapshot
			// 
			this.btnSaveSnapshot.Location = new System.Drawing.Point(108, 12);
			this.btnSaveSnapshot.Name = "btnSaveSnapshot";
			this.btnSaveSnapshot.Size = new System.Drawing.Size(144, 40);
			this.btnSaveSnapshot.TabIndex = 6;
			this.btnSaveSnapshot.Text = "Save Snapshot";
			this.btnSaveSnapshot.UseVisualStyleBackColor = true;
			this.btnSaveSnapshot.Click += new System.EventHandler(this.btnSaveSnapshot_Click);
			// 
			// pbScreen
			// 
			this.pbScreen.Location = new System.Drawing.Point(12, 58);
			this.pbScreen.Name = "pbScreen";
			this.pbScreen.Size = new System.Drawing.Size(656, 407);
			this.pbScreen.TabIndex = 5;
			this.pbScreen.TabStop = false;
			// 
			// btnStartCapture
			// 
			this.btnStartCapture.Location = new System.Drawing.Point(12, 12);
			this.btnStartCapture.Name = "btnStartCapture";
			this.btnStartCapture.Size = new System.Drawing.Size(90, 40);
			this.btnStartCapture.TabIndex = 4;
			this.btnStartCapture.Text = "Start";
			this.btnStartCapture.UseVisualStyleBackColor = true;
			this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
			// 
			// cbDevice
			// 
			this.cbDevice.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.cbDevice.FormattingEnabled = true;
			this.cbDevice.Location = new System.Drawing.Point(274, 20);
			this.cbDevice.Name = "cbDevice";
			this.cbDevice.Size = new System.Drawing.Size(158, 25);
			this.cbDevice.TabIndex = 8;
			// 
			// videoSourcePlayer
			// 
			this.videoSourcePlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
			this.videoSourcePlayer.Location = new System.Drawing.Point(674, 58);
			this.videoSourcePlayer.Name = "videoSourcePlayer";
			this.videoSourcePlayer.Size = new System.Drawing.Size(656, 407);
			this.videoSourcePlayer.TabIndex = 9;
			this.videoSourcePlayer.Text = "videoSourcePlayer1";
			this.videoSourcePlayer.VideoSource = null;
			// 
			// btnStart2
			// 
			this.btnStart2.Location = new System.Drawing.Point(674, 12);
			this.btnStart2.Name = "btnStart2";
			this.btnStart2.Size = new System.Drawing.Size(90, 40);
			this.btnStart2.TabIndex = 10;
			this.btnStart2.Text = "Start";
			this.btnStart2.UseVisualStyleBackColor = true;
			this.btnStart2.Click += new System.EventHandler(this.btnStart2_Click);
			// 
			// UsbCamera2TestDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1340, 885);
			this.Controls.Add(this.btnStart2);
			this.Controls.Add(this.videoSourcePlayer);
			this.Controls.Add(this.cbDevice);
			this.Controls.Add(this.pbSnapshot);
			this.Controls.Add(this.btnSaveSnapshot);
			this.Controls.Add(this.pbScreen);
			this.Controls.Add(this.btnStartCapture);
			this.Name = "UsbCamera2TestDlg";
			this.Text = "UsbCamera2TestDlg";
			((System.ComponentModel.ISupportInitialize)(this.pbSnapshot)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbSnapshot;
		private System.Windows.Forms.Button btnSaveSnapshot;
		private System.Windows.Forms.PictureBox pbScreen;
		private System.Windows.Forms.Button btnStartCapture;
		private System.Windows.Forms.ComboBox cbDevice;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
		private System.Windows.Forms.Button btnStart2;
	}
}