using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <summary>
	/// DM abstract syntax tree
	/// </summary>
	interface IAST
	{
		/// <summary>
		/// Global vars
		/// </summary>
		IReadOnlyDictionary<string, IVar> Vars { get; }
		IReadOnlyList<IDatum> RootDatums { get; }
		IReadOnlyDictionary<string, IProc> Procs { get; }

		IReadOnlyList<string> ResourcePaths { get; }
		IReadOnlyList<string> StringFormatters { get; }
	}
}
