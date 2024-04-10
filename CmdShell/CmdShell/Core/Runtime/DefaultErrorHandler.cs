using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Runtime;

internal class DefaultErrorHandler : IErrorHandler
{
    public void Handle(Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: {ex.Message}");
        Console.ResetColor();
    }
}
