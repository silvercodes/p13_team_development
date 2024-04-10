using CmdShell.Core.IO;
using CmdShell.Core.Parsing;
using CmdShell.Core.Runtime.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Runtime;

internal class AppController
{
	private const string TITLE_PATTERN = @"^[a-z]+";

	private IInputDriver inputDriver;
	private IParser parser;
	private IErrorHandler errorHandler;
	private ServiceCallTracker serviceCallTracker;
	private ICommandStateLoader commandStateLoader;

	public AppController
	(
		IInputDriver inputDriver,
		IParser parser,
		IErrorHandler errorHandler,
		ServiceCallTracker serviceCallTracker,
		ICommandStateLoader	commandStateLoader
	)
	{
		this.inputDriver = inputDriver;
		this.parser = parser;
		this.errorHandler = errorHandler;
		this.serviceCallTracker = serviceCallTracker;
		this.commandStateLoader = commandStateLoader;
	}
    public void StartProcessing(CommandCollection commands)
    {
        while(true)
        {
			try
			{
				// get input
				string? input = inputDriver.Read();

				if (string.IsNullOrEmpty(input))
					continue;

				input = input.Trim();

				// find command
				Command cmd = DetectCommand(commands, input);

				// check service calling
				if (! serviceCallTracker.Manage(cmd, input))
				{
					commandStateLoader.LoadState(cmd, input);

                    cmd.Execute();
                }
			}
			catch (Exception ex)
			{
				errorHandler.Handle(ex);
			}
        }
    }

	private Command DetectCommand(CommandCollection commands, string input)
	{
		string title = parser.ExtractMatch(input, TITLE_PATTERN);

		return commands.Find(title);
	}
}
