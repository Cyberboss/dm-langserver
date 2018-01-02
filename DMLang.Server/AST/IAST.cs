using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <summary>
	/// DM abstract syntax tree
	/// </summary>
	interface IAST
	{
		IReadOnlyList<IVar> GlobalVars { get; }
		IReadOnlyList<IDatum> RootDatums { get; }
		IReadOnlyList<IProc> GlobalProcs { get; }

		IReadOnlyList<string> ResourcePaths { get; }
		IReadOnlyList<string> StringFormatters { get; }

		/// <summary>
		/// Adds the builtin BYOND <see cref="IVar"/>s, <see cref="IDatum"/>s, <see cref="IProc"/>s, and string formatters
		/// </summary>
		void AddByondBuiltins();

		/// <summary>
		/// Adds the <see cref="IVar"/>s, <see cref="IDatum"/>s, <see cref="IProc"/>s, and string formatters from stddef.dm
		/// </summary>
		void AddStdDef();
	}
}
