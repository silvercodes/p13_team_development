using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Exceptions
{
    internal class BuildException : CmdShellException
    {
        public const string BUILD_CMD_INVALID_TITLE = "Command title is invalid or not found";
        public const string BUILD_ARG_INVALID_TITLE = "Command argument title is invalid or not found";
        public const string BUILD_ARG_INVALID_SYNTAX = "Command argument syntax is invalid";
        public BuildException(string? message) 
            :base(message)
        {
        }
    }
}
