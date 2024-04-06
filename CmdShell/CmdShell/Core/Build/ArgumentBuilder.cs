using CmdShell.Core.Exceptions;
using CmdShell.Core.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Build
{
    internal class ArgumentBuilder : IBuilder<CommandArgument>
    {
        private const string ARG_SIGNATURE_PATTERN = @"\{([^-].*?)\}";
        private const string ARG_TITLE_PATTERN = @"^[a-z]+";
        private const string ARG_IS_REQUIRED_PATERN = @"^[a-z]+$";
        private const string ARG_NOT_REQUIRED_SYNTAX_PATTERN = @"^[a-z]+[\?=]";
        private const string ARG_DEFAULT_VALUE_PATTERN = @"^[a-z]+=(.+$)";

        private IParser parser;

        public ArgumentBuilder(IParser parser)
        {
            this.parser = parser;
        }
        public CommandArgument? Build(string signature)
        {
            string argSignature = DetectArgumentSignature(signature);

            if (string.IsNullOrEmpty(argSignature))
                return null;

            CommandArgument argument = new CommandArgument();

            argument.Title = DetectTitle(argSignature);
            argument.IsRequired = DetectIsRequired(argSignature);

            if (! argument.IsRequired)
            {
                if (!CheckNotRequiredSyntax(argSignature))
                    throw new BuildException(BuildException.BUILD_ARG_INVALID_SYNTAX);

                argument.DefaultValue = DetectDefaultValue(argSignature);
            }
                

            return argument;
        }

        private string DetectArgumentSignature(string signature)
        {
            return parser.ExtractFirstGroupValue(signature, ARG_SIGNATURE_PATTERN);
        }

        private string DetectTitle(string argSignature)
        {
            string? title = parser.ExtractMatch(argSignature, ARG_TITLE_PATTERN);

            if (string.IsNullOrEmpty(title))
                throw new BuildException(BuildException.BUILD_ARG_INVALID_TITLE);

            return title;
        }

        private bool DetectIsRequired(string argSignature)
        {
            return parser.Check(argSignature, ARG_IS_REQUIRED_PATERN);
        }

        private bool CheckNotRequiredSyntax(string argSignature)
        {
            return parser.Check(argSignature, ARG_NOT_REQUIRED_SYNTAX_PATTERN);
        }

        private string? DetectDefaultValue(string argSignature)
        {
            string defaultValue = parser.ExtractFirstGroupValue(argSignature, ARG_DEFAULT_VALUE_PATTERN);

            return string.IsNullOrEmpty(defaultValue) ? null : defaultValue;
        }
    }
}
