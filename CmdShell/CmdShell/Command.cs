using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell;

public abstract class Command
{
    public abstract string Signature { get; }

    public string? Title { get; set; } = null;

    public virtual string Description { get; set; } = string.Empty;
    public virtual string Help { get; set; } = string.Empty;


    public abstract void Execute();
}
