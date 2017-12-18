using Antlr4.Runtime;
using LanguageServer;
using LanguageServer.Client;
using LanguageServer.Json;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Parameters.TextDocument;
using LanguageServer.Parameters.Workspace;
using System;
using System.IO;

namespace DMLang.Server
{
	/// <summary>
	/// Class used to implement <see cref="ServiceConnection"/>
	/// </summary>
	sealed class Server : ServiceConnection, IServer
	{
		/// <summary>
		/// Constructs a <see cref="Server"/>
		/// </summary>
		/// <param name="input">The input <see cref="Stream"/></param>
		/// <param name="output">The output <see cref="Stream"/></param>
		public Server(Stream input, Stream output) : base(input, output)
		{
			RunParser();
		}


		static void RunParser()
		{
			new AntlrInputStream("hello world\n");
		}

		protected override Result<InitializeResult, ResponseError<InitializeErrorData>> Initialize(InitializeParams parameters)
		{
			var capabilities = new ServerCapabilities
			{
				textDocumentSync = TextDocumentSyncKind.Full,
				definitionProvider = true
			};
			var result = new InitializeResult
			{
				capabilities = capabilities
			};
			return Result<InitializeResult, ResponseError<InitializeErrorData>>.Success(result);
		}

		protected override Result<ArrayOrObject<Location, Location>, ResponseError> GotoDefinition(TextDocumentPositionParams parameters)
		{
			return base.GotoDefinition(parameters);
		}
	}
}
