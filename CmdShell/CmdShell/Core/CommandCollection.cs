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

    public void Find(string title)
    {
        
    }
}
