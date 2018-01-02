using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <summary>
	/// A Block of <see cref="IStatement"/>s
	/// </summary>
	interface IBlock
	{
		/// <summary>
		/// Ordered list of <see cref="IStatement"/>s in the <see cref="IBlock"/>
		/// </summary>
		IReadOnlyList<IStatement> Statements { get; }
	}
}
