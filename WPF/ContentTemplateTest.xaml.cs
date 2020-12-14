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
	/// Interaction logic for ContentTemplateTest.xaml
	/// </summary>
	public partial class ContentTemplateTest : Window
	{
		public ContentTemplateTest()
		{
			InitializeComponent();

			this.Loaded += ContentTemplateTest_Loaded;
		}

		private void ContentTemplateTest_Loaded(object sender, RoutedEventArgs e)
		{
			ContentPresenter presenter = FindVisualChild<ContentPresenter>(chkRUPremolars1);
			DataTemplate template = presenter.ContentTemplate;
			Image foundControl = template.FindName("imgThumb", presenter) as Image;
			foundControl.Source = new BitmapImage(new Uri("D:\\aaa.bmp"));
		}

		private static childItem FindVisualChild<childItem>(DependencyObject obj)
			where childItem : DependencyObject
		{
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild(obj, i);
				if (child != null && child is childItem)
					return (childItem)child;
				else
				{
					childItem childOfChild = FindVisualChild<childItem>(child);
					if (childOfChild != null)
						return childOfChild;
				}
			}
			return null;
		}
	}
}
