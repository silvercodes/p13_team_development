using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Runtime;

internal interface IErrorHandler
{
    public void Handle(Exception ex);
}
