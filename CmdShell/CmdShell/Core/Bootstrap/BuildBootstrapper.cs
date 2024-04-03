using CmdShell.Core.Build;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Bootstrap
{
    internal class BuildBootstrapper : IBootsrapper
    {
        public CommandCollection CommandCollection { get; set; }
        public BuildBootstrapper(CommandCollection commands)
        {
            CommandCollection = commands;
        }
        public void Register()
        {
            AppServiceProvider.Services.AddSingleton<IBuilder<string>, TitleBuilder>();
            AppServiceProvider.Services.AddSingleton<IBuilder<CommandArgument>, ArgumentBuilder>();


            AppServiceProvider.Services.AddSingleton<CommandInitializer>();
        }
        public void Boot()
        {
            CommandInitializer ci = AppServiceProvider.GetRequiredService<CommandInitializer>();

            CommandCollection.Commands.ForEach(cmd =>
            {
                ci.Build(cmd);
            });
        }        
    }
}
