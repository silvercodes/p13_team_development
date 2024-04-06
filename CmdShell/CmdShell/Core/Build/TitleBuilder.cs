using CmdShell.Core.Exceptions;
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
        private const string TITLE_PATTERN = @"^[a-z]+";
        private IParser parser;

        public TitleBuilder(IParser parser)
        {
            this.parser = parser;
        }
        public string? Build(string signature)
        {
            string? title = parser.ExtractMatch(signature, TITLE_PATTERN);

            if (string.IsNullOrEmpty(title))
                throw new BuildException(BuildException.BUILD_CMD_INVALID_TITLE);

            return title;
        }
    }
}
