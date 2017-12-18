using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DMLang.Server.Parser
{
	/// <summary>
	/// Represents a #define statement in DM
	/// </summary>
	sealed class PreprocessorReplacement
	{
		public string Macro => macro;
		public int ArgumentCount => argumentReplacements.Count;

		readonly IReadOnlyList<PreprocessorRegex> argumentReplacements;
		readonly string macro;
		readonly string replacement;

		public PreprocessorReplacement(string _macro, IEnumerable<string> arguments, string _replacement)
		{
			macro = _macro;
			replacement = _replacement;

			var replacements = new List<PreprocessorRegex>();
			foreach (var I in arguments)
				replacements.Add(new PreprocessorRegex(I));

			argumentReplacements = replacements;
		}

		public string Run(IEnumerable<string> arguments)
		{
			string result = replacement;
			if(arguments == null)
			{
				if(ArgumentCount > 0)
					throw new PreprocessorException(String.Format(CultureInfo.CurrentCulture, "Bad invocation of macro {0}! Expected {1} arguments, got none!", Macro, argumentReplacements.Count));
				return result;
			}

			foreach (var I in arguments.Zip(argumentReplacements, (argument, regex) => new { Argument = argument, Regex = regex }))
			{
				if (I.Regex == null || I.Argument == null)
					throw new PreprocessorException(String.Format(CultureInfo.CurrentCulture, "Bad invocation of macro {0}! Expected {1} arguments, got {2}!", Macro, argumentReplacements.Count, arguments.Count()));

				result = I.Regex.Replace(result, I.Argument);
			}
			return result;
		}
	}
}
