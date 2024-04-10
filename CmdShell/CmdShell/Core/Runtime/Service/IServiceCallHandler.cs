using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Runtime.Service;

internal interface IServiceCallHandler
{
    public void Handle(Command cmd);
}
