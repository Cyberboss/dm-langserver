using System.Collections.Generic;

namespace DMLang.Server.AST
{
	interface IDatum : IPathable
	{
		string Name { get; }

		IReadOnlyList<ISourceLocation> Locations { get; }

		IReadOnlyList<IDatum> Children { get; }
		IReadOnlyList<IVar> Vars { get; }

		/// <summary>
		/// Refers to the parentmost procs by name
		/// </summary>
		IReadOnlyList<IProc> Procs { get; }
	}
}
