using System;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	sealed class Branch : Statement, IBranch
	{
		/// <inheritdoc />
		public IExpression Condition => condition;
		/// <inheritdoc />
		public IBlock True => trueBlock;
		/// <inheritdoc />
		public IBlock False => falseBlock;

		/// <summary>
		/// Backing field for <see cref="Condition"/>
		/// </summary>
		readonly IExpression condition;
		/// <summary>
		/// Backing field for <see cref="True"/>
		/// </summary>
		readonly IBlock trueBlock;
		/// <summary>
		/// Backing field for <see cref="False"/>
		/// </summary>
		readonly IBlock falseBlock;

		/// <summary>
		/// Construct a <see cref="Branch"/>
		/// </summary>
		/// <param name="_condition">Value of <see cref="Condition"/></param>
		/// <param name="_location">Value of <see cref="Statement.Location"/></param>
		/// <param name="_trueBlock">Value of <see cref="True"/></param>
		/// <param name="_falseBlock">Value of <see cref="False"/></param>
		public Branch(IExpression _condition, ISourceLocation _location, IBlock _trueBlock, IBlock _falseBlock) : base(_location)
		{
			condition = _condition ?? throw new ArgumentNullException(nameof(_condition));
			trueBlock = _trueBlock ?? Block.Empty;
			falseBlock = _falseBlock ?? Block.Empty;
		}

		/// <inheritdoc />
		protected override bool IsBlockTerminating()
		{
			return false;
		}
	}
}
