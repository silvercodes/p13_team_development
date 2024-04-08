using CmdShell.Core.Exceptions;
using CmdShell.Core.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core.Build
{
    internal class OptionsBuilder : IBuilder<List<CommandOption>?>
    {
        private const string OPT_TITLE_GROUP_KEY = "title";
        private const string OPT_SHORTCUT_GROUP_KEY = "shortcut";

        private const string OPT_SIGNATURE_PATTERN = @"\{--(.*?)\}";
        private const string OPT_TITLE_PATTERN =
            @"^(?<" + OPT_TITLE_GROUP_KEY + @">[a-z]{2,})|^[a-zA-Z]{1}\|(?<" + OPT_TITLE_GROUP_KEY + @">[a-z]{2,})";
        private const string OPT_SHORTCUT_PATTERN =
            @"^[a-z]{2,}\|(?<" + OPT_SHORTCUT_GROUP_KEY + @">[a-zA-Z]{1})|^(?<" + OPT_SHORTCUT_GROUP_KEY + @">[a-zA-Z]{1})\|";
        private const string OPT_IS_BOOLEAN_PATTERN = @"^[^=]+$";
        private const string OPT_IS_VALUE_REQUIRED_PATTERN = @"=(-->|$)";
        private const string OPT_DEFAULT_VALUE_PATTERN = @"=`(.*?)`";
        private const string OPT_DESCRIPTION_PATTERN = @"-->(.*?)$";


        private IParser parser;

        public OptionsBuilder(IParser parser)
        {
            this.parser = parser;
        }
        public List<CommandOption>? Build(string signature)
        {
            List<string> optSignatures = DetectOptionSignatures(signature);

            if (optSignatures.Count == 0)
                return null;

            List<CommandOption> options = new List<CommandOption>();

            optSignatures.ForEach(s =>
            {
                options.Add(
                    new CommandOption()
                    {
                        Title = DetectTitle(s),
                        Shortcut = DetectShortcut(s),
                        IsBoolean = DetectIsBoolean(s),
                        IsValueRequired = DetectIsValueRequired(s),
                        DefaultValue = DetectDefaultValue(s),
                        Description = DetectDescription(s),
                    }
                );
            });

            return options;
        }

        public List<string> DetectOptionSignatures(string signature)
        {
            return parser.ExtractAllFirstGroupValues(signature, OPT_SIGNATURE_PATTERN);
        }

        private string DetectTitle(string optSignature)
        {
            string? title = parser.ExtractNamedGroupValue(optSignature, OPT_TITLE_PATTERN, OPT_TITLE_GROUP_KEY);

            if (string.IsNullOrEmpty(title))
                throw new BuildException(BuildException.BUILD_OPT_INVALID_TITLE);

            return title;
        }

        private string? DetectShortcut(string optSignature)
        {
            string? shortcut = parser.ExtractNamedGroupValue(optSignature, OPT_SHORTCUT_PATTERN, OPT_SHORTCUT_GROUP_KEY);

            return string.IsNullOrEmpty(shortcut) ? null : shortcut;
        }

        private bool DetectIsBoolean(string optSignature)
        {
            return parser.Check(optSignature, OPT_IS_BOOLEAN_PATTERN);
        }

        private bool DetectIsValueRequired(string optSignature)
        {
            return parser.Check(optSignature, OPT_IS_VALUE_REQUIRED_PATTERN);
        }

        private string? DetectDefaultValue(string optSignature) 
        {
            string defaultValue = parser.ExtractFirstGroupValue(optSignature, OPT_DEFAULT_VALUE_PATTERN);

            return string.IsNullOrEmpty(defaultValue) ? null : defaultValue;
        }

        private string? DetectDescription(string optSignature)
        {
            string description = parser.ExtractFirstGroupValue(optSignature, OPT_DESCRIPTION_PATTERN);

            return string.IsNullOrEmpty(description) ? null : description;
        }
    }
}
