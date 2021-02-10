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
			this.btnPythonTest = new System.Windows.Forms.Button();
			this.btnFoDiocom = new System.Windows.Forms.Button();
			this.btnUsbCamera2 = new System.Windows.Forms.Button();
			this.btnRestSharp = new System.Windows.Forms.Button();
			this.btnGuiControls = new System.Windows.Forms.Button();
			this.btnCLRTest = new System.Windows.Forms.Button();
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
			// btnPythonTest
			// 
			this.btnPythonTest.Location = new System.Drawing.Point(122, 12);
			this.btnPythonTest.Name = "btnPythonTest";
			this.btnPythonTest.Size = new System.Drawing.Size(104, 40);
			this.btnPythonTest.TabIndex = 1;
			this.btnPythonTest.Text = "Python";
			this.btnPythonTest.UseVisualStyleBackColor = true;
			this.btnPythonTest.Click += new System.EventHandler(this.btnPythonTest_Click);
			// 
			// btnFoDiocom
			// 
			this.btnFoDiocom.Location = new System.Drawing.Point(232, 12);
			this.btnFoDiocom.Name = "btnFoDiocom";
			this.btnFoDiocom.Size = new System.Drawing.Size(104, 40);
			this.btnFoDiocom.TabIndex = 2;
			this.btnFoDiocom.Text = "fo-dicom";
			this.btnFoDiocom.UseVisualStyleBackColor = true;
			this.btnFoDiocom.Click += new System.EventHandler(this.btnFoDiocom_Click);
			// 
			// btnUsbCamera2
			// 
			this.btnUsbCamera2.Location = new System.Drawing.Point(12, 58);
			this.btnUsbCamera2.Name = "btnUsbCamera2";
			this.btnUsbCamera2.Size = new System.Drawing.Size(104, 40);
			this.btnUsbCamera2.TabIndex = 3;
			this.btnUsbCamera2.Text = "Usb Camera (AForge)";
			this.btnUsbCamera2.UseVisualStyleBackColor = true;
			this.btnUsbCamera2.Click += new System.EventHandler(this.btnUsbCamera2_Click);
			// 
			// btnRestSharp
			// 
			this.btnRestSharp.Location = new System.Drawing.Point(342, 12);
			this.btnRestSharp.Name = "btnRestSharp";
			this.btnRestSharp.Size = new System.Drawing.Size(104, 40);
			this.btnRestSharp.TabIndex = 4;
			this.btnRestSharp.Text = "RestSharp";
			this.btnRestSharp.UseVisualStyleBackColor = true;
			this.btnRestSharp.Click += new System.EventHandler(this.btnRestSharp_Click);
			// 
			// btnGuiControls
			// 
			this.btnGuiControls.Location = new System.Drawing.Point(122, 58);
			this.btnGuiControls.Name = "btnGuiControls";
			this.btnGuiControls.Size = new System.Drawing.Size(104, 40);
			this.btnGuiControls.TabIndex = 5;
			this.btnGuiControls.Text = "GUI Controls";
			this.btnGuiControls.UseVisualStyleBackColor = true;
			this.btnGuiControls.Click += new System.EventHandler(this.btnGuiControls_Click);
			// 
			// btnCLRTest
			// 
			this.btnCLRTest.Location = new System.Drawing.Point(232, 58);
			this.btnCLRTest.Name = "btnCLRTest";
			this.btnCLRTest.Size = new System.Drawing.Size(104, 40);
			this.btnCLRTest.TabIndex = 6;
			this.btnCLRTest.Text = "CLR Test";
			this.btnCLRTest.UseVisualStyleBackColor = true;
			this.btnCLRTest.Click += new System.EventHandler(this.btnCLRTest_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(669, 550);
			this.Controls.Add(this.btnCLRTest);
			this.Controls.Add(this.btnGuiControls);
			this.Controls.Add(this.btnRestSharp);
			this.Controls.Add(this.btnUsbCamera2);
			this.Controls.Add(this.btnFoDiocom);
			this.Controls.Add(this.btnPythonTest);
			this.Controls.Add(this.btnUsbCamera);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnUsbCamera;
		private System.Windows.Forms.Button btnPythonTest;
		private System.Windows.Forms.Button btnFoDiocom;
		private System.Windows.Forms.Button btnUsbCamera2;
		private System.Windows.Forms.Button btnRestSharp;
		private System.Windows.Forms.Button btnGuiControls;
		private System.Windows.Forms.Button btnCLRTest;
	}
}

