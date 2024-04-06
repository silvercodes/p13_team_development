using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Parsing;

internal interface IParser
{
    public bool Check(string input, string pattern);
    public string ExtractMatch(string input, string pattern);
    public string ExtractFirstGroupValue(string input, string pattern);             // TODO: refactor method title      
    public List<string> ExtractAllFirstGroupValues(string input, string pattern);   // TODO: refactor method title      
    public string ExtractNamedGroupValue(string input, string pattern, string groupKey);
}
