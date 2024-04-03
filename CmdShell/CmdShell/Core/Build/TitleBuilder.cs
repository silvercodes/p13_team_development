using CmdShell.Core.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Build
{
    internal class TitleBuilder : IBuilder<string>
    {
        private IParser parser;

        public TitleBuilder(IParser parser)
        {
            this.parser = parser;
        }
        public string Build(string signature)
        {
            




        }
    }
}
