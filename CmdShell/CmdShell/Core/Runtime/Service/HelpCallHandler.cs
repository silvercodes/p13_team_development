using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Runtime.Service;

internal class HelpCallHandler : IServiceCallHandler
{
    public void Handle(Command cmd)
    {
        Console.WriteLine($"COMMAND {cmd.Title}:");
        Console.WriteLine(cmd.Description);

        cmd.Options?.ForEach(o =>
        {
            Console.WriteLine($"{o.Title} {o.Description}");
        });
    }
}
