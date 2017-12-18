using System.IO;

namespace DMLang.Server
{
	/// <summary>
	/// Factory for creating an <see cref="IServer"/>
	/// </summary>
	interface IServerFactory
	{
		/// <summary>
		/// Creates a <see cref="IServer"/>
		/// </summary>
		/// <param name="input">The input <see cref="Stream"/></param>
		/// <param name="output">The output <see cref="Stream"/></param>
		/// <returns>A new <see cref="IServer"/></returns>
		IServer CreateServer(Stream input, Stream output);
	}
}
