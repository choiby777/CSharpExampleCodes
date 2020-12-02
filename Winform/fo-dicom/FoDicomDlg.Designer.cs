namespace WinformExamples.fo_dicom
{
	partial class FoDicomDlg
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
			this.btnCreateSRDicom = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCreateSRDicom
			// 
			this.btnCreateSRDicom.Location = new System.Drawing.Point(12, 12);
			this.btnCreateSRDicom.Name = "btnCreateSRDicom";
			this.btnCreateSRDicom.Size = new System.Drawing.Size(120, 48);
			this.btnCreateSRDicom.TabIndex = 0;
			this.btnCreateSRDicom.Text = "Create SR Dicom";
			this.btnCreateSRDicom.UseVisualStyleBackColor = true;
			this.btnCreateSRDicom.Click += new System.EventHandler(this.btnCreateSRDicom_Click);
			// 
			// FoDicomDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(557, 364);
			this.Controls.Add(this.btnCreateSRDicom);
			this.Name = "FoDicomDlg";
			this.Text = "FoDicomDlg";
			this.Load += new System.EventHandler(this.FoDicomDlg_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCreateSRDicom;
	}
}