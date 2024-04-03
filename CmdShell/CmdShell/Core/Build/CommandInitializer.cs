using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Build;

internal class CommandInitializer
{
    private IBuilder<string> titleBuilder;
    private IBuilder<CommandArgument> argumentBuilder;

    public CommandInitializer(
        IBuilder<string> titleBuilder,
        IBuilder<CommandArgument> argumentBuilder
    )
    {
        this.titleBuilder = titleBuilder;
        this.argumentBuilder = argumentBuilder;
    }

    public void Build(Command command)
    {
        string signature = command.Signature.Trim();

        command.Title = titleBuilder.Build(signature);
        command.Argument = argumentBuilder.Build(signature);
        // opts

        Console.WriteLine();
    }
}
