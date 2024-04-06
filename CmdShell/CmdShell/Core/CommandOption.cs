using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core;

public class CommandOption
{
    public string? Title { get; set; } = null;
    public string? Shortcut { get; set; } = null;
    public bool IsBoolean { get; set; } = true;
    public bool IsValueRequired { get; set; } = false;
    public string? DefaultValue { get; set; } = null;
    public string? Description { get; set; } = null;
    public string? Value { get; set; } = null;



}
