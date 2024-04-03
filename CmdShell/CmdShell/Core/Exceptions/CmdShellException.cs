using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Exceptions;

public class CmdShellException: Exception
{
    public CmdShellException(string? message)
        : base(message)
    { }
}
