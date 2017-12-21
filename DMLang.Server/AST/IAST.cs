using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <summary>
	/// DM abstract syntax tree
	/// </summary>
	interface IAST
	{
		IReadOnlyDictionary<string, IVar> GlobalVars { get; }
		IReadOnlyList<IDatum> RootDatums { get; }
		IReadOnlyDictionary<string, IProc> GlobalProcs { get; }

		IReadOnlyList<string> ResourcePaths { get; }
		IReadOnlyList<string> StringFormatters { get; }
	}
}
