using CmdShell.Core.Runtime;
using CmdShell.Core.Runtime.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Bootstrap
{
    internal class AppBootstrapper : IBootsrapper
    {
        public void Register()
        {
            AppServiceProvider.Services.AddSingleton<AppController>();
            AppServiceProvider.Services.AddSingleton<ServiceCallTracker>();

            AppServiceProvider.Services.AddSingleton<ICommandStateLoader, CommandStateLoader>();
            AppServiceProvider.Services.AddSingleton<IErrorHandler, DefaultErrorHandler>();
        }
        public void Boot()
        {
            



        }

        
    }
}
