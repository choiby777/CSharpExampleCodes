using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CommandPattern
{
	class Image
	{
		public string Name { get; }
		public int ImageWidth { get; }
		public int ImageHeight { get; }

		public Image(string name, int width, int height)
		{
			Name = name;
			ImageWidth = width;
			ImageHeight = height;
		}
	}
}
