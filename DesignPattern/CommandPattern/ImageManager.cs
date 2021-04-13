using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CommandPattern
{
	class ImageManager
	{
		List<Image> images = new List<Image>();

		public void AddImage(string name , int width , int height)
		{
			images.Add(new Image(name, width, height));
		}

		public void ExecuteCommandToAllImage(ICommand command)
		{
			foreach (var image in images)
			{
				command.Execute(image);
			}
		}
	}
}
