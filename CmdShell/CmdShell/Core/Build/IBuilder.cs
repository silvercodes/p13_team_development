using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Build;

internal interface IBuilder<T>
{
    public T Build(string signature);
}
