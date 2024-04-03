using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Build;

internal class CommandInitializer
{
    private IBuilder<string> titleBuilder;

    public CommandInitializer(
        IBuilder<string> titleBuilder
    )
    {
        this.titleBuilder = titleBuilder;
    }

    public void Build(Command command)
    {
        string signature = command.Signature.Trim();

        command.Title = titleBuilder.Build(signature);
        // arg
        // opts

        Console.WriteLine();
    }
}
