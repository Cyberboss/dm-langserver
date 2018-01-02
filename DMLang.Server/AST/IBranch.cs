namespace DMLang.Server.AST
{
	/// <summary>
	/// Represents an if statement
	/// </summary>
	interface IBranch : IStatement
	{
		/// <summary>
		/// The if <see cref="IExpression"/>
		/// </summary>
		IExpression Condition { get; }
		/// <summary>
		/// The <see cref="IBlock"/> if <see cref="Condition"/> is <see langword="true"/>
		/// </summary>
		IBlock True { get; }
		/// <summary>
		/// The <see cref="IBlock"/> if <see cref="Condition"/> is <see langword="false"/>
		/// </summary>
		IBlock False { get; }
	}
}
