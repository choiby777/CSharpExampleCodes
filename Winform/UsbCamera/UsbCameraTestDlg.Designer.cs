namespace WinformExamples.UsbCameraTest
{
	partial class UsbCameraTestDlg
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
			this.btnStartCapture = new System.Windows.Forms.Button();
			this.pbxScreen = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbxScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// btnStartCapture
			// 
			this.btnStartCapture.Location = new System.Drawing.Point(578, 12);
			this.btnStartCapture.Name = "btnStartCapture";
			this.btnStartCapture.Size = new System.Drawing.Size(90, 40);
			this.btnStartCapture.TabIndex = 0;
			this.btnStartCapture.Text = "Start";
			this.btnStartCapture.UseVisualStyleBackColor = true;
			this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
			// 
			// pbxScreen
			// 
			this.pbxScreen.Location = new System.Drawing.Point(12, 58);
			this.pbxScreen.Name = "pbxScreen";
			this.pbxScreen.Size = new System.Drawing.Size(656, 407);
			this.pbxScreen.TabIndex = 1;
			this.pbxScreen.TabStop = false;
			// 
			// UsbCameraTestDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(680, 477);
			this.Controls.Add(this.pbxScreen);
			this.Controls.Add(this.btnStartCapture);
			this.Name = "UsbCameraTestDlg";
			this.Text = "UsbCameraTestDlg";
			((System.ComponentModel.ISupportInitialize)(this.pbxScreen)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnStartCapture;
		private System.Windows.Forms.PictureBox pbxScreen;
	}
}