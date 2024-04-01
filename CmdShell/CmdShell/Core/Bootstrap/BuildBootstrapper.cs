﻿using CmdShell.Core.Build;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Bootstrap
{
    internal class BuildBootstrapper : IBootsrapper
    {
        public void Register()
        {
            AppServiceProvider.Services.AddSingleton<IBuilder<string>, TitleBuilder>();



            AppServiceProvider.Services.AddSingleton<CommandInitializer>();
        }
        public void Boot()
        {
            
        }        
    }
}