using LanguageServer;
using LanguageServer.Client;
using LanguageServer.Json;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Parameters.TextDocument;
using LanguageServer.Parameters.Workspace;
using System.IO;

namespace DMLang.Server
{
	/// <summary>
	/// Class used to implement <see cref="ServiceConnection"/>
	/// </summary>
	sealed class Connection : ServiceConnection
	{
		public Connection(Stream input, Stream output) : base(input, output)
		{

		}
	}
}
