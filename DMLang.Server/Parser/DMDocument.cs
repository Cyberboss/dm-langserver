using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace DMLang.Server.Parser
{
	sealed class DMDocument
	{
		/// <summary>
		/// The path to the .dm from the workspace root
		/// </summary>
		public string FilePath { get; set; }
		/// <summary>
		/// The content of the .dm file
		/// </summary>
		public IReadOnlyList<string> Lines { get; set; }

		static readonly Regex WordRegex = new Regex(@"\b[\s,\.-:;]*");

		static void RunPreprocessorHandler(StringBuilder builder, IEnumerable<string> macroArguments, int currentIndex, ref PreprocessorReplacement preprocessorReplacement, ref int indexTracker)
		{
			builder.Append(preprocessorReplacement.Run(macroArguments));
			preprocessorReplacement = null;
			indexTracker = currentIndex + 1;
		}

		public DMDocument(string filePath, string text)
		{
			FilePath = filePath;
			var lines = new List<string>();
			using (var sr = new StringReader(text))
				for (string L = sr.ReadLine(); L != null; L = sr.ReadLine())
					lines.Add(L);
			Lines = lines;
		}

		public string Preprocess(IDictionary<string, PreprocessorReplacement> replacements)
		{
			var builder = new StringBuilder();

			var lastIndex = 0;
			var commentStartLine = 0;
			PreprocessorReplacement nextReplacement = null;
			var expectingRightParen = false;
			var inComment = false;
			bool lastTokenWasBackslash, firstInLine;
			IList<string> macroArguments = null;

			for (var N = 0; N < Lines.Count; ++N)
			{
				var Line = Lines[N];
				lastTokenWasBackslash = false;
				firstInLine = true;
				const string include = "include";
				const string define = "define";
				bool expectingDefOrInclude = false, expectingDefine = false, expectingInclude = false;
				foreach (Match I in WordRegex.Matches(Line))
				{
					if (inComment)
					{
						if (I.Value == "*/")
							inComment = false;
						continue;
					}
					else if (I.Value == "/*")
					{
						inComment = true;
						commentStartLine = N;
						continue;
					}

					if (firstInLine && I.Value == "#")
						expectingDefOrInclude = true;
					firstInLine = false;
					if (expectingDefOrInclude)
					{
						if (expectingInclude || expectingDefine)
						{
							expectingDefOrInclude = false;

						}
						else if (I.Value == include)
							expectingInclude = true;
						else if (I.Value != define)
							expectingDefine = true;
						else
							throw new PreprocessorException(String.Format(CultureInfo.CurrentCulture, "Expected {0} or {1}!", include, define)) { FilePath = FilePath, LineNumber = N + 1 };
					}
					else if (I.Value.Contains("//"))    //rest of line is comment
						break;
					else if (I.Value == "\\")
						lastTokenWasBackslash = true;
					else if (nextReplacement != null)
					{
						if (expectingRightParen)
						{
							if (I.Value == ")")
							{
								RunPreprocessorHandler(builder, macroArguments, I.Index, ref nextReplacement, ref lastIndex);
								expectingRightParen = false;
							}
							else if (I.Value != ",")
								macroArguments.Add(I.Value);
						}
						//expecting left paren
						else if (I.Value == "(")
							expectingRightParen = true;
						else
							throw new PreprocessorException(String.Format(CultureInfo.CurrentCulture, "Missing argument list for macro {0}", nextReplacement.Macro)) { FilePath = FilePath, LineNumber = N + 1 };
					}
					else if (replacements.TryGetValue(I.Value, out nextReplacement))
					{
						builder.Append(Line.Substring(lastIndex, I.Index));
						//if no arguments are required, do the replacement now
						if (nextReplacement.ArgumentCount == 0)
							RunPreprocessorHandler(builder, macroArguments, I.Index, ref nextReplacement, ref lastIndex);
						else
							macroArguments = new List<string>();
					}
				}

				if (!lastTokenWasBackslash)
				{
					if (expectingRightParen)
						throw new PreprocessorException(String.Format(CultureInfo.CurrentCulture, "Unterminated macro invocation of {0}", nextReplacement.Macro)) { FilePath = FilePath, LineNumber = N + 1 };
					if(expectingDefOrInclude)
						throw new PreprocessorException(String.Format(CultureInfo.CurrentCulture, "Expected {0} or {1}!", include, define)) { FilePath = FilePath, LineNumber = N + 1 };
					if (expectingDefine)
						throw new PreprocessorException(String.Format(CultureInfo.CurrentCulture, "Expected macro definition!")) { FilePath = FilePath, LineNumber = N + 1 };
					if (expectingInclude)
						throw new PreprocessorException(String.Format(CultureInfo.CurrentCulture, "Expected include definition!")) { FilePath = FilePath, LineNumber = N + 1 };
					builder.Append(Environment.NewLine);
				}
			}

			if(inComment)
				throw new PreprocessorException(String.Format(CultureInfo.CurrentCulture, "Unterminated multiline comment!")) { FilePath = FilePath, LineNumber = commentStartLine };

			return builder.ToString();
		}
	}
}
