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
			btnPrintEx.Click += BtnPrintEx_Click;
			btnPrintImageBox.Click += BtnPrintImageBox_Click;
		}

		private void PrintVisual(Visual v)
		{
			System.Windows.FrameworkElement e = v as System.Windows.FrameworkElement;
			if (e == null)
				return;

			PrintDialog pd = new PrintDialog();
			if (pd.ShowDialog() == true)
			{
				//store original scale
				Transform originalScale = e.LayoutTransform;
				//get selected printer capabilities
				System.Printing.PrintCapabilities capabilities = pd.PrintQueue.GetPrintCapabilities(pd.PrintTicket);

				//get scale of the print wrt to screen of WPF visual
				double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / e.ActualWidth, capabilities.PageImageableArea.ExtentHeight /
							   e.ActualHeight);

				//Transform the Visual to scale
				e.LayoutTransform = new ScaleTransform(scale, scale);

				//get the size of the printer page
				System.Windows.Size sz = new System.Windows.Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

				//update the layout of the visual to the printer page size.
				e.Measure(sz);
				e.Arrange(new System.Windows.Rect(new System.Windows.Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));

				//now print the visual to printer to fit on the one page.
				pd.PrintVisual(v, "My Print");

				//apply the original transform.
				e.LayoutTransform = originalScale;
			}
		}

		private void BtnPrintImageBox_Click(object sender, RoutedEventArgs e)
		{
			Visual v = imgPrintImage as Visual;

			PrintVisual(v);
		}


		private void BtnPrintEx_Click(object sender, RoutedEventArgs e)
		{
			PrintDialog dialog = new PrintDialog();
			if (dialog.ShowDialog() != true) return;

			StackPanel myPanel = new StackPanel();
			myPanel.Margin = new Thickness(10);

			Image myImage = new Image();
			myImage.Width = 128;
			myImage.Stretch = Stretch.Uniform;
			myImage.Source = new BitmapImage(new Uri(txtImageFilePath.Text, UriKind.Absolute));

			myPanel.Children.Add(myImage);

			//TextBlock myBlock = new TextBlock();
			//myBlock.Text = "A Great Image.";
			//myBlock.TextAlignment = TextAlignment.Center;

			//myPanel.Children.Add(myBlock);

			myPanel.Measure(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));
			myPanel.Arrange(new Rect(new Point(0, 0), myPanel.DesiredSize));

			dialog.PrintVisual(myPanel, "A Great Image.");
		}

		private void BtnPrint_Click(object sender, RoutedEventArgs e)
		{
			PrintDialog printDlg = new PrintDialog();

			if (printDlg.ShowDialog() == true)
			{
				ImageSource printImage = GetImageSource(txtImageFilePath.Text);

				var visual = new DrawingVisual();
				var dc = visual.RenderOpen();
				dc.DrawImage(printImage, new Rect { Width = printImage.Width, Height = printImage.Height });
				dc.Close();

				printDlg.PrintVisual(visual, "Print Test");
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
