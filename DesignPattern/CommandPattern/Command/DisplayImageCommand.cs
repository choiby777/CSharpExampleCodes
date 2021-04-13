using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CommandPattern.Command
{
	class DisplayImageCommand : ICommand
	{
		public void Execute(Image image)
		{
			Console.WriteLine($"{image.Name} - Execute DisplayImage");
		}
	}
}
