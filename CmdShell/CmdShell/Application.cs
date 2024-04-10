using CmdShell.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell;

public class Application
{
    private Kernel kernel = null!;
    public CommandCollection Commands { get; set; }

    public Application()
    {
        Commands = new CommandCollection();
    }

    public void Run()
    {
        // TODO: by condition ???
        kernel = new ConsoleKernel(Commands);           // Этап инициализации

        kernel.Handle();                                // этап рантайма
    }
}
