using System.Collections.Generic;

namespace DMLang.Server.AST
{
	interface IAST
	{
		IReadOnlyDictionary<string, IVar> Vars { get; }
		IReadOnlyList<IDatum> RootDatums { get; }
		IReadOnlyDictionary<string, IProc> Procs { get; }

		IReadOnlyList<string> ResourcePaths { get; }
		IReadOnlyList<string> StringFormatters { get; }
	}
}
