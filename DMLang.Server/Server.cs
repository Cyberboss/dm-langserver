using LanguageServer;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using System.IO;
using LanguageServer.Parameters.Workspace;
using LanguageServer.Parameters.TextDocument;

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
		public Server(Stream input, Stream output) : base(input, output) { }

		protected override Result<InitializeResult, ResponseError<InitializeErrorData>> Initialize(InitializeParams parameters)
		{
			var capabilities = new ServerCapabilities
			{
				textDocumentSync = TextDocumentSyncKind.Incremental,
			};
			var result = new InitializeResult
			{
				capabilities = capabilities
			};
			return Result<InitializeResult, ResponseError<InitializeErrorData>>.Success(result);
		}

		protected override void DidChangeWatchedFiles(DidChangeWatchedFilesParams @params)
		{
			base.DidChangeWatchedFiles(@params);
		}

		protected override void DidChangeTextDocument(DidChangeTextDocumentParams @params)
		{
			base.DidChangeTextDocument(@params);
		}

		protected override void DidOpenTextDocument(DidOpenTextDocumentParams @params)
		{
			base.DidOpenTextDocument(@params);
		}
	}
}
