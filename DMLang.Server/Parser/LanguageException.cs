using System;
using System.Runtime.Serialization;

namespace DMLang.Server.Parser
{
	/// <summary>
	/// <see cref="Exception"/> that occurs when a <see cref="DMDocument"/> fails parsing
	/// </summary>
	[Serializable]
	public class LanguageException : Exception
	{
		/// <summary>
		/// The file that caused the <see cref="LanguageException"/>
		/// </summary>
		public string FilePath { get; set; }
		/// <summary>
		/// The line of <see cref="FilePath"/> that caused the <see cref="LanguageException"/>
		/// </summary>
		public int LineNumber { get; set; }

		/// <summary>
		/// Construct a <see cref="LanguageException"/>
		/// </summary>
		public LanguageException() : base("A language exception occurred") { }

		/// <summary>
		/// Construct a <see cref="LanguageException"/>
		/// </summary>
		/// <param name="message">The messsage for the <see cref="LanguageException"/></param>
		public LanguageException(string message) : base(message) { }

		/// <summary>
		/// Construct a <see cref="LanguageException"/>
		/// </summary>
		/// <param name="message">The messsage for the <see cref="LanguageException"/></param>
		/// <param name="innerException">The inner exception that cause the <see cref="LanguageException"/></param>
		public LanguageException(string message, Exception innerException) : base(message, innerException) { }

		/// <summary>
		/// Construct a <see cref="LanguageException"/>
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> to build the <see cref="LanguageException"/> from</param>
		/// <param name="context">The <see cref="StreamingContext"/> for building the <see cref="LanguageException"/></param>
		protected LanguageException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			FilePath = info.GetString(nameof(FilePath));
			LineNumber = info.GetInt32(nameof(LineNumber));
		}

		/// <summary>
		/// Serialize the <see cref="LanguageException"/>
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> used for serialization</param>
		/// <param name="context">The <see cref="StreamingContext"/> used for serialization</param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
				throw new ArgumentNullException(nameof(info));

			info.AddValue(nameof(FilePath), FilePath);
			info.AddValue(nameof(LineNumber), LineNumber);

			base.GetObjectData(info, context);
		}
	}
}
