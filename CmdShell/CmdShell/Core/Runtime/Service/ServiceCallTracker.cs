using CmdShell.Core.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Runtime.Service;

internal class ServiceCallTracker
{
    private enum ServiceOption
    {
        Help,
        Signature,
    }

    private IParser parser;

    private Dictionary<ServiceOption, string> serviceOptionPatterns = new Dictionary<ServiceOption, string>()
    {
        { ServiceOption.Help, @"^[a-z]{2,}\s--help$" },
        { ServiceOption.Signature, @"^[a-z]{2,}\s--signature" }

    };

    public ServiceCallTracker(IParser parser)
    {
        this.parser = parser;
    }

    // TODO: refactoring !!!
    public bool Manage(Command cmd, string input)
    {
        ServiceOption? serviceOption = DetectServiceOption(input);

        if (serviceOption is null)
            return false;

        switch(serviceOption)
        {
            case ServiceOption.Help:
                if (cmd is IHelpRenderable helpRenderable)
                {
                    helpRenderable.RenderHelp();
                    return true;
                }
                break;
        }

        IServiceCallHandler handler = serviceOption switch
        {
            ServiceOption.Help => new HelpCallHandler(),
            ServiceOption.Signature => new SignatureCallHandler(),

            _ => throw new NotImplementedException()                    // TODO: temp
        };

        handler.Handle(cmd);

        return true;
    }

    private ServiceOption? DetectServiceOption(string input)
    {
        foreach(KeyValuePair<ServiceOption, string> item in serviceOptionPatterns)
        {
            if (parser.Check(input, item.Value))
                return item.Key;
        }

        return null;
    }
}
