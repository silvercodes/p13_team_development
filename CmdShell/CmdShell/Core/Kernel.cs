using CmdShell.Core.Bootstrap;
using CmdShell.Core.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core;

internal abstract class Kernel
{
    protected List<IBootsrapper> Bootsrappers { get; set; }
    protected CommandCollection Commands { get; set; }

    public Kernel(CommandCollection commands)
    {
        Commands = commands;

        Bootsrappers = new List<IBootsrapper>();

        SetupBootstrappers();

        Bootstrap();
        
    }

    protected abstract void SetupBootstrappers();

    private void Bootstrap()
    {
        ExecuteRegisterMethods();

        AppServiceProvider.BuildProvider();

        ExecuteBootMethods();
    }

    private void ExecuteRegisterMethods()
    {
        Bootsrappers.ForEach(bootstrapper => bootstrapper.Register());
    }

    private void ExecuteBootMethods()
    {
        Bootsrappers.ForEach(bootstrapper => bootstrapper.Boot());
    }

    // TODO: return int ???
    public void Handle()
    {
        AppController controller = AppServiceProvider.GetRequiredService<AppController>();

        controller.StartProcessing(Commands);
    }


}
