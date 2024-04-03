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

        private IParser parser;

        public ArgumentBuilder(IParser parser)
        {
            this.parser = parser;
        }
        public CommandArgument Build(string signature)
        {
            string argSignature = DetectArgumentSignature(signature);


            Console.WriteLine();

            return null;


        }

        private string DetectArgumentSignature(string signature)
        {
            return parser.ExtractFirstGroupValue(signature, ARG_SIGNATURE_PATTERN);
        }
    }
}
