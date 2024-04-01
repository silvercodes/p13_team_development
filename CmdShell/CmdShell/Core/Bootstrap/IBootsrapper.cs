using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Bootstrap;

internal interface IBootsrapper
{
    public void Register();
    public void Boot();
}
