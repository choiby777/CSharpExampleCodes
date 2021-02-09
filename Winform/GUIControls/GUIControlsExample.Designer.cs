namespace WinformExamples.GUIControls
{
	partial class GUIControlsExample
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
			this.dgvStudentList = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvStudentList)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvStudentList
			// 
			this.dgvStudentList.AllowUserToAddRows = false;
			this.dgvStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStudentList.Location = new System.Drawing.Point(12, 12);
			this.dgvStudentList.Name = "dgvStudentList";
			this.dgvStudentList.RowTemplate.Height = 23;
			this.dgvStudentList.Size = new System.Drawing.Size(636, 482);
			this.dgvStudentList.TabIndex = 0;
			// 
			// GUIControlsExample
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(667, 506);
			this.Controls.Add(this.dgvStudentList);
			this.Name = "GUIControlsExample";
			this.Text = "GUIControlsExample";
			this.Load += new System.EventHandler(this.GUIControlsExample_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvStudentList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvStudentList;
	}
}