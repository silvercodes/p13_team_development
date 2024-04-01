using CmdShell.Core.Build;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Bootstrap
{
    internal class CommandBootstrapper : IBootsrapper
    {
        public CommandCollection CommandCollection { get; set; }
        public CommandBootstrapper(CommandCollection commands)
        {
            CommandCollection = commands;
        }

        public void Register()
        {
            
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
