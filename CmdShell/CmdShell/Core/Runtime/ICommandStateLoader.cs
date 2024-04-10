using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Runtime;

internal interface ICommandStateLoader
{
    public void LoadState(Command cmd, string input);
}
