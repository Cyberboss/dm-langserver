using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.Parser
{
	/// <summary>
	/// <see cref="LanguageException"/> thrown when a preprocessor error occurs
	/// </summary>
	public sealed class PreprocessorException : LanguageException
	{
		/// <summary>
		/// Construct a <see cref="PreprocessorException"/>
		/// </summary>
		/// <param name="message">The preprocessor error message</param>
		public PreprocessorException(string message) : base(message) { }
	}
}
