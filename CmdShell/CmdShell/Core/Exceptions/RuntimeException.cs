using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Exceptions;

internal class RuntimeException : CmdShellException
{
    public const string CMD_NOT_FOUND = "Command not found";
    public const string CMD_ARG_NOT_SUPPORTED = "Command does not support an argument";
    public const string CMD_ARG_IS_REQUIRED = "Command argument is required: ";
    public RuntimeException(string? message) 
        : base(message)
    {}
}
