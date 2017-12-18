using System;
using System.IO;

namespace DMLang.Server
{
	/// <inheritdoc />
	public sealed class ServerFactory : IServerFactory
	{
		/// <inheritdoc />
		public IServer CreateServer(Stream input, Stream output)
		{
			return new Server(input, output);
		}
	}
}
