using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
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
			btnPrintEx2.Click += BtnPrintEx2_Click;
		}

		private void BtnPrintEx2_Click(object sender, RoutedEventArgs e)
		{
			PrintAsFitonPaperSize(txtImageFilePath.Text);
		}

		public void PrintAsFitonPaperSize(string FileName, bool isAutoPaperOrientation = true)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(FileName)) return; // Prevents execution of below statements if filename is not selected.

				PrintDocument pd = new PrintDocument();
				pd.DocumentName = "Xmaru";

				//Disable the printing document pop-up dialog shown during printing.
				PrintController printController = new StandardPrintController();
				pd.PrintController = printController;

				if (!pd.PrinterSettings.IsValid) throw new Exception("PrinterSetting is not valid");
				if (!pd.PrinterSettings.IsDefaultPrinter) throw new Exception("Default printer is not valid");

				//For testing only: Hardcoded set paper size to particular paper.
				//pd.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("Custom 6x4", 720, 478);
				//pd.DefaultPageSettings.PaperSize = new PaperSize("Custom 6x4", 720, 478);

				pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
				pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

				System.Drawing.Image image = System.Drawing.Image.FromFile(FileName);

				bool isLandscapeImage = image.Width > image.Height;
				bool isLandscapeConfig = pd.DefaultPageSettings.Landscape;

				if (isAutoPaperOrientation)
				{
					if (isLandscapeImage != isLandscapeConfig)
					{
						pd.DefaultPageSettings.Landscape = isLandscapeImage;
					}
				}
				
				pd.PrintPage += (sender, args) =>
				{
					//Adjust the size of the image to the page to print the full image without loosing any part of the image.
					System.Drawing.Rectangle m = args.MarginBounds;

					//Logic below maintains Aspect Ratio.
					if ((double)image.Width / (double)image.Height > (double)m.Width / (double)m.Height) // image is wider
					{
						m.Height = (int)((double)image.Height / (double)image.Width * (double)m.Width);
					}
					else
					{
						m.Width = (int)((double)image.Width / (double)image.Height * (double)m.Height);
					}

					m.Y = (int)((((System.Drawing.Printing.PrintDocument)(sender)).DefaultPageSettings.Bounds.Height - m.Height) / 2);
					m.X = (int)((((System.Drawing.Printing.PrintDocument)(sender)).DefaultPageSettings.Bounds.Width- m.Width) / 2);

					args.Graphics.DrawImage(image, m);
				};

				pd.Print();
			}
			catch (Exception ex)
			{
			}
			finally
			{
			}
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
				double scale = Math.Min(
					capabilities.PageImageableArea.ExtentWidth / e.ActualWidth, 
					capabilities.PageImageableArea.ExtentHeight / e.ActualHeight);

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

			System.Printing.PrintCapabilities capabilities = dialog.PrintQueue.GetPrintCapabilities(dialog.PrintTicket);

			StackPanel myPanel = new StackPanel();
			myPanel.Margin = new Thickness(10);

			Image myImage = new Image();
			myImage.Width = 1000;
			myImage.Height = 1000;
			myImage.Stretch = Stretch.Uniform;
			myImage.Source = new BitmapImage(new Uri(txtImageFilePath.Text, UriKind.Absolute));

			double scale = Math.Min(
				capabilities.PageImageableArea.ExtentWidth / myImage.Width,
				capabilities.PageImageableArea.ExtentHeight / myImage.Height);

			myImage.LayoutTransform = new ScaleTransform(scale, scale);

			myPanel.Children.Add(myImage);

			//TextBlock myBlock = new TextBlock();
			//myBlock.Text = "A Great Image.";
			//myBlock.TextAlignment = TextAlignment.Center;

			//myPanel.Children.Add(myBlock);

			//get the size of the printer page
			System.Windows.Size sz = new System.Windows.Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

			myPanel.Measure(sz);
			myPanel.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));

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
				imgPrintImage.Stretch = Stretch.Uniform;
				imgPrintImage.Source = imageSource;
			}
		}
	}
}
