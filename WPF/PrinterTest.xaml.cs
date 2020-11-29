using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Examples
{
	/// <summary>
	/// Interaction logic for PrinterTest.xaml
	/// </summary>
	public partial class PrinterTest : Window
	{
		public PrinterTest()
		{
			InitializeComponent();

			btnSelectFile.Click += BtnSelectFile_Click;
			btnPrint.Click += BtnPrint_Click;
		}

		private void BtnPrint_Click(object sender, RoutedEventArgs e)
		{
			PrintDialog pringDlg = new PrintDialog();

			if (pringDlg.ShowDialog() == true)
			{
				ImageSource printImage = GetImageSource(txtImageFilePath.Text);

				var visual = new DrawingVisual();
				var dc = visual.RenderOpen();
				dc.DrawImage(printImage, new Rect { Width = printImage.Width, Height = printImage.Height });
				dc.Close();

				pringDlg.PrintVisual(visual , "Print Test");
			}
		}

		private ImageSource GetImageSource(string imageFilePath)
		{
			var bi = new BitmapImage();
			bi.BeginInit();
			bi.CacheOption = BitmapCacheOption.OnLoad;
			bi.UriSource = new Uri(imageFilePath, UriKind.Relative);
			bi.EndInit();

			return bi;
		}

		private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Multiselect = false;
			openFileDialog.Filter = "Image files (*.bmp , *.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
			openFileDialog.Title = "Select Image file using a window";

			if (openFileDialog.ShowDialog() == true)
			{
				txtImageFilePath.Text = openFileDialog.FileName;

				ImageSource imageSource = new BitmapImage(new Uri(openFileDialog.FileName));
				imgPrintImage.Source = imageSource;
			}
		}
	}
}
