using CmdShell.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core;

public class CommandCollection
{
    internal List<Command> Commands { get; set; }

    public CommandCollection()
    {
        Commands = new List<Command>();
    }

    public void Add(Command command)
    {
        Commands.Add(command);
    }

    public Command Find(string title)
    {
        if (!Commands.Any(cmd => cmd.Title == title))
            throw new RuntimeException(RuntimeException.CMD_NOT_FOUND);

        return Commands.First(cmd => cmd.Title == title);
    }
}
