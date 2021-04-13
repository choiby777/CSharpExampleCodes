using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CommandPattern
{
	class SendImageCommand : ICommand
	{
		public void Execute(Image image)
		{
			Console.WriteLine($"{image.Name} - Execute SendImage");
		}
	}
}
