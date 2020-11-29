namespace WinformExamples.PythonTest
{
	partial class PythonTestDlg
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
			this.txtPythonDir = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnExecute = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtModuleDirPath = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtModuleName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtModelDirPath = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtPythonDir
			// 
			this.txtPythonDir.Location = new System.Drawing.Point(100, 21);
			this.txtPythonDir.Name = "txtPythonDir";
			this.txtPythonDir.Size = new System.Drawing.Size(327, 21);
			this.txtPythonDir.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "Python";
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(433, 21);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(98, 76);
			this.btnExecute.TabIndex = 2;
			this.btnExecute.Text = "Execute";
			this.btnExecute.UseVisualStyleBackColor = true;
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "Module Dir";
			// 
			// txtModuleDirPath
			// 
			this.txtModuleDirPath.Location = new System.Drawing.Point(100, 49);
			this.txtModuleDirPath.Name = "txtModuleDirPath";
			this.txtModuleDirPath.Size = new System.Drawing.Size(327, 21);
			this.txtModuleDirPath.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "Module Name";
			// 
			// txtModuleName
			// 
			this.txtModuleName.Location = new System.Drawing.Point(100, 76);
			this.txtModuleName.Name = "txtModuleName";
			this.txtModuleName.Size = new System.Drawing.Size(327, 21);
			this.txtModuleName.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(35, 106);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "Model Dir";
			// 
			// txtModelDirPath
			// 
			this.txtModelDirPath.Location = new System.Drawing.Point(100, 103);
			this.txtModelDirPath.Name = "txtModelDirPath";
			this.txtModelDirPath.Size = new System.Drawing.Size(327, 21);
			this.txtModelDirPath.TabIndex = 7;
			// 
			// PythonTestDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 146);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtModelDirPath);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtModuleName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtModuleDirPath);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPythonDir);
			this.Name = "PythonTestDlg";
			this.Text = "PythonTestDlg";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPythonDir;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtModuleDirPath;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtModuleName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtModelDirPath;
	}
}