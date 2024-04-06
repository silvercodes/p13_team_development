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

    public string ExtractFirstGroupValue(string input, string pattern)
    {
        Regex regex = new Regex(pattern);

        return regex.Match(input).Groups[1].Value;
    }

    public List<string> ExtractAllFirstGroupValues(string input, string pattern)
    {
        List<string> results = new List<string>();

        Regex regex = new Regex(pattern);

        foreach(Match m in regex.Matches(input))
            results.Add(m.Groups[1].Value);

        return results;
    }

    public string ExtractNamedGroupValue(string input, string pattern, string groupKey)
    {
        Regex regex = new Regex(pattern);

        return regex.Match(input).Groups[groupKey].Value;
    }
}
