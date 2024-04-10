using CmdShell.Core.IO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Bootstrap;

internal class IOBootstrapper : IBootsrapper
{
    public void Register()
    {
        AppServiceProvider.Services.AddSingleton<IInputDriver, ConsoleInputDriver>();
    }
    public void Boot()
    {
        
    }
}
