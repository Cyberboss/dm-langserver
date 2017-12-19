using System;
using System.Runtime.Serialization;

namespace DMLang.Server.Parser
{
	/// <summary>
	/// <see cref="LanguageException"/> thrown when a preprocessor error occurs
	/// </summary>
	[Serializable]
	sealed class PreprocessorException : LanguageException
	{
		/// <summary>
		/// Construct a <see cref="LanguageException"/>
		/// </summary>
		public PreprocessorException() : base("A preprocessor exception occurred!") { }
		
		/// <summary>
		/// Construct a <see cref="PreprocessorException"/>
		/// </summary>
		/// <param name="message">The preprocessor error message</param>
		public PreprocessorException(string message) : base(message) { }

		/// <summary>
		/// Construct a <see cref="PreprocessorException"/>
		/// </summary>
		/// <param name="message">The messsage for the <see cref="PreprocessorException"/></param>
		/// <param name="innerException">The inner exception that cause the <see cref="PreprocessorException"/></param>
		public PreprocessorException(string message, Exception innerException) : base(message, innerException) { }

		/// <summary>
		/// Construct a <see cref="PreprocessorException"/>
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> to build the <see cref="PreprocessorException"/> from</param>
		/// <param name="context">The <see cref="StreamingContext"/> for building the <see cref="PreprocessorException"/></param>
		private PreprocessorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
