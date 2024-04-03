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
        public BuildException(string? message) 
            :base(message)
        {
        }
    }
}
