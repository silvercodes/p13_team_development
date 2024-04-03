using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CmdShell.Core.Parsing;

internal class RegexParser : IParser
{
    public bool Check(string input, string pattern)
    {
        Regex regex = new Regex(pattern);

        return regex.IsMatch(input);
    }

    public string ExtractMatch(string input, string pattern)
    {
        Regex regex = new Regex(pattern);

        return regex.Match(input).Value;
    }
}
