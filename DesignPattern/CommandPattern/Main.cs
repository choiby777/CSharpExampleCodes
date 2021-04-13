using DesignPattern.CommandPattern.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CommandPattern
{
	enum ImageCommand
	{
		DisplayImage,
		RotateImage,
		SendImage
	}

	class Main
	{
		ImageManager imgManager = new ImageManager();
		Dictionary<ImageCommand, ICommand> commands = new Dictionary<ImageCommand, ICommand>();

		public Main()
		{
			commands.Add(ImageCommand.DisplayImage , new DisplayImageCommand());
			commands.Add(ImageCommand.RotateImage , new RotateImageCommand());
			commands.Add(ImageCommand.SendImage , new SendImageCommand());
		}

		public void AddImage(string name)
		{
			imgManager.AddImage(name, 100, 100);
		}

		public void ExecuteCommand(ImageCommand command)
		{
			ICommand executeCommand;

			if (!commands.TryGetValue(command, out executeCommand)) return;

			imgManager.ExecuteCommandToAllImage(executeCommand);
		}
	}
}
