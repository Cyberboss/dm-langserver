using System.Collections.Generic;

namespace DMLang.Server.AST
{
	interface IProc : IPathable
	{
		string Name { get; }

		IReadOnlyList<IVar> Arguments { get; }
	
		IDatum Owner { get; }
		IProc Override { get; }

		IBlock Contents { get; }
	}
}
