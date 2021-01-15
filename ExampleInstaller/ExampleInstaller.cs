using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExampleInstaller
{
	[RunInstaller(true)]
	public partial class ExampleInstaller : System.Configuration.Install.Installer
	{
		public ExampleInstaller()
		{
			InitializeComponent();
		}


		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
		public override void Commit(IDictionary savedState)
		{
			base.Commit(savedState);

			// Add some code

			// /PATH="[TARGETDIR]\" /ProductName="[ProductName]" /TYPE="TYPE1"

			if (Context.Parameters == null) return;
			if (Context.Parameters.Count == 0) return;
			if (!Context.Parameters.ContainsKey("path")) return;
			if (!Context.Parameters.ContainsKey("ProductName")) return;
			if (!Context.Parameters.ContainsKey("TYPE")) return;

			string targetDirPath = Context.Parameters["path"].ToString();
			string productName = Context.Parameters["ProductName"].ToString();
			string type = Context.Parameters["TYPE"].ToString();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(targetDirPath);
			sb.AppendLine(productName);
			sb.AppendLine(type);

			MessageBox.Show(sb.ToString());
		}


		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
		public override void Install(IDictionary stateSaver)
		{
			base.Install(stateSaver);
		}

		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
		public override void Rollback(IDictionary savedState)
		{
			base.Rollback(savedState);
		}

		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
		public override void Uninstall(IDictionary savedState)
		{
			base.Uninstall(savedState);
		}

		protected override void OnAfterInstall(IDictionary savedState)
		{
			base.OnAfterInstall(savedState);
		}

		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
		protected override void OnBeforeInstall(IDictionary stateSaver)
		{
			base.OnBeforeInstall(stateSaver);
		}
	}
}
