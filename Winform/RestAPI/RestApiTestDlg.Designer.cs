namespace WinformExamples.RestAPI
{
	partial class RestApiTestDlg
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
			this.btnGetNews = new System.Windows.Forms.Button();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.dgvNews = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvNews)).BeginInit();
			this.SuspendLayout();
			// 
			// btnGetNews
			// 
			this.btnGetNews.Location = new System.Drawing.Point(12, 12);
			this.btnGetNews.Name = "btnGetNews";
			this.btnGetNews.Size = new System.Drawing.Size(130, 36);
			this.btnGetNews.TabIndex = 0;
			this.btnGetNews.Text = "Get News";
			this.btnGetNews.UseVisualStyleBackColor = true;
			this.btnGetNews.Click += new System.EventHandler(this.btnGetNews_Click);
			// 
			// txtResult
			// 
			this.txtResult.Location = new System.Drawing.Point(12, 54);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.Size = new System.Drawing.Size(869, 130);
			this.txtResult.TabIndex = 1;
			// 
			// dgvNews
			// 
			this.dgvNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvNews.Location = new System.Drawing.Point(12, 190);
			this.dgvNews.Name = "dgvNews";
			this.dgvNews.RowTemplate.Height = 23;
			this.dgvNews.Size = new System.Drawing.Size(869, 455);
			this.dgvNews.TabIndex = 2;
			// 
			// RestApiTestDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(893, 657);
			this.Controls.Add(this.dgvNews);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.btnGetNews);
			this.Name = "RestApiTestDlg";
			this.Text = "RestApiTestDlg";
			((System.ComponentModel.ISupportInitialize)(this.dgvNews)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnGetNews;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.DataGridView dgvNews;
	}
}