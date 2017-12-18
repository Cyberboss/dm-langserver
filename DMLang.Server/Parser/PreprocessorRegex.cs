using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DMLang.Server.Parser
{
	sealed class PreprocessorRegex
	{
		readonly Regex explicitReplacement;
		readonly Regex stringifiedReplacement;
		readonly Regex replacement;

		public PreprocessorRegex(string argument)
		{
			explicitReplacement = new Regex(String.Format(CultureInfo.InvariantCulture, "##{0}", argument));
			stringifiedReplacement = new Regex(String.Format(CultureInfo.InvariantCulture, "#{0}", argument));
			replacement = new Regex(argument);
		}

		public string Replace(string input, string replacementText)
		{
			return replacement.Replace(stringifiedReplacement.Replace(explicitReplacement.Replace(input, replacementText), String.Format(CultureInfo.InvariantCulture, "\"{0}\"", replacementText)), replacementText);
		}
	}
}
