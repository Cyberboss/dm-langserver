using LanguageServer;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Parameters.Workspace;
using LanguageServer.Parameters.TextDocument;
using System.IO;
using System.Threading.Tasks;

namespace DMLang.Server
{
	/// <summary>
	/// Class used to implement <see cref="ServiceConnection"/>
	/// </summary>
	sealed class Server : ServiceConnection, IServer
	{
		ExitCode exitCode;

		/// <summary>
		/// Constructs a <see cref="Server"/>
		/// </summary>
		/// <param name="input">The input <see cref="Stream"/></param>
		/// <param name="output">The output <see cref="Stream"/></param>
		public Server(Stream input, Stream output) : base(input, output)
		{
			exitCode = ExitCode.BadStop;
		}

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

		public async Task<ExitCode> Run()
		{
			try
			{
				await Listen();
				return exitCode;
			}
			catch
			{
				return ExitCode.InternalError;
			}
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

		protected override VoidResult<ResponseError> Shutdown()
		{
			exitCode = ExitCode.NoExit;
			return VoidResult<ResponseError>.Success();
		}

		protected override void Exit()
		{
			exitCode = exitCode == ExitCode.BadStop ? ExitCode.NoShutdown : ExitCode.Success;
		}
	}
}
