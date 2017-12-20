using System.Collections.Generic;

namespace DMLang.Server.AST
{
	interface IProcCall : IExpression
	{
		IUnsafeVar Owner { get; }

		string Name { get; }
		
		IReadOnlyList<IArgument> Arguments { get; }
	}
}
