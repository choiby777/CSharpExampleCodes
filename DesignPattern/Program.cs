using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	class Program
	{
		static void Main(string[] args)
		{
			CommandPatternTest();
		}

		/// <summary>
		/// 일반적으로 메뉴나 여러 작업을 트랜잭션 형태로 수행을 해야 하는 경우와 다양한 콜백을 구현을 하는 경우등에서 사용됨
		/// </summary>
		private static void CommandPatternTest()
		{
			CommandPattern.Main main = new CommandPattern.Main();
			main.AddImage("Dog");
			main.AddImage("Cat");
			main.AddImage("Horse");

			main.ExecuteCommand(CommandPattern.ImageCommand.DisplayImage);
			main.ExecuteCommand(CommandPattern.ImageCommand.RotateImage);
			main.ExecuteCommand(CommandPattern.ImageCommand.SendImage);

			Console.ReadLine();
		}
	}
}
