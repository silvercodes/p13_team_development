using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.IO;

internal class ConsoleInputDriver : IInputDriver
{
    public string? Read()
    {
        Console.Write("> ");

        return Console.ReadLine();
    }
}
