using System;
using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	sealed class Block : IBlock
	{
		/// <summary>
		/// An empty <see cref="Block"/>
		/// </summary>
		public static readonly Block Empty = new Block(new List<Statement>());

		/// <inheritdoc />
		public IReadOnlyList<IStatement> Statements => statements;

		/// <summary>
		/// Backing field for <see cref="Statements"/>
		/// </summary>
		readonly List<IStatement> statements;

		/// <summary>
		/// Construct a <see cref="Block"/>
		/// </summary>
		/// <param name="_statements">The <see cref="IStatement"/>s in the <see cref="Block"/></param>
		public Block(IEnumerable<IStatement> _statements)
		{
			if (_statements == null)
				throw new ArgumentNullException(nameof(_statements));
			statements = new List<IStatement>();
			statements.AddRange(_statements);
		}
	}
}
