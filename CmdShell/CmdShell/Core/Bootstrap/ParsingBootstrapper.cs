using CmdShell.Core.Parsing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Bootstrap;

internal class ParsingBootstrapper : IBootsrapper
{
    public void Register()
    {
        AppServiceProvider.Services.AddSingleton<IParser, RegexParser>();
    }
    public void Boot()
    {
        
    }

    
}
