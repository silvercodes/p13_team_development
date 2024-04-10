using CmdShell.Core.Exceptions;
using CmdShell.Core.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Runtime;

internal class CommandStateLoader : ICommandStateLoader
{
    private const string LOAD_ARG_PATTERN = @"^[a-z]+\s(?<argument>.*?)( -[a-z]| --[a-zA-Z]{2,}|$)";
    private IParser parser;
    public CommandStateLoader(IParser parser)
    {
        this.parser = parser;
    }
    public void LoadState(Command cmd, string input)
    {
        LoadArgument(cmd.Argument, input);
        LoadOptions(cmd.Options, input);
    }

    private void LoadArgument(CommandArgument? argument, string input)
    {
        string value = parser.ExtractNamedGroupValue(input, LOAD_ARG_PATTERN, "argument"); // TODO: hardcode

        
        if (argument is null)
        {
            if (!string.IsNullOrEmpty(value))
                throw new RuntimeException(RuntimeException.CMD_ARG_NOT_SUPPORTED);

            return;
        }

        if (!string.IsNullOrEmpty(value))
            argument.Value = value;
        else
        {
            if (argument.IsRequired)
                throw new RuntimeException($"{RuntimeException.CMD_ARG_IS_REQUIRED}{argument.Title}");
            else
                argument.Value = argument.DefaultValue;
        }
    }

    private void LoadOptions(List<CommandOption>? options, string input)
    {

    }
}
