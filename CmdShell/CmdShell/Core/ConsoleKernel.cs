using CmdShell.Core.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core;

internal class ConsoleKernel : Kernel
{
    public ConsoleKernel(CommandCollection commands) 
        : base(commands)
    {}

    protected override void SetupBootstrappers()
    {
        Bootsrappers.Add(new BuildBootstrapper(Commands));
        Bootsrappers.Add(new ParsingBootstrapper());
        Bootsrappers.Add(new IOBootstrapper());

        Bootsrappers.Add(new AppBootstrapper());
        //
        //
        //
    }
}
