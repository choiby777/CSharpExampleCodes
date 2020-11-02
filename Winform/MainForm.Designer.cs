namespace WinformExamples
{
	partial class MainForm
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
			this.btnUsbCamera = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnUsbCamera
			// 
			this.btnUsbCamera.Location = new System.Drawing.Point(12, 12);
			this.btnUsbCamera.Name = "btnUsbCamera";
			this.btnUsbCamera.Size = new System.Drawing.Size(104, 40);
			this.btnUsbCamera.TabIndex = 0;
			this.btnUsbCamera.Text = "Usb Camera";
			this.btnUsbCamera.UseVisualStyleBackColor = true;
			this.btnUsbCamera.Click += new System.EventHandler(this.btnUsbCamera_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(669, 550);
			this.Controls.Add(this.btnUsbCamera);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnUsbCamera;
	}
}

