using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core;

public class CommandArgument
{
    public string? Title { get; set; } = null;
    public bool IsRequired { get; set; } = true;
    public string? DefaultValue { get; set; } = null;
    public string? Value { get; set; } = null;
}
