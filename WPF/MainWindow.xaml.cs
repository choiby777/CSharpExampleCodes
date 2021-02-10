using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Examples
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private static readonly ILog logger = LogManager.GetLogger(typeof(App));

		public MainWindow()
		{
			InitializeComponent();

			logger.Info("=============== MainWindow Created =============");
			logger.Debug("Debug Log!!");
			logger.Error("Error Log!!");
			logger.Fatal("Fatal Log!!");

			btnPrinterTest.Click += BtnPrinterTest_Click;
			btnContentTemplateTest.Click += BtnContentTemplateTest_Click;
			btnUiTest.Click += BtnUiTest_Click;
		}

		private void BtnUiTest_Click(object sender, RoutedEventArgs e)
		{
			UITest dlg = new UITest();
			dlg.ShowDialog();
		}

		private void BtnContentTemplateTest_Click(object sender, RoutedEventArgs e)
		{
			ContentTemplateTest dlg = new ContentTemplateTest();
			dlg.ShowDialog();
		}

		private void BtnPrinterTest_Click(object sender, RoutedEventArgs e)
		{
			PrinterTest dlg = new PrinterTest();
			dlg.ShowDialog();
		}
	}
}
