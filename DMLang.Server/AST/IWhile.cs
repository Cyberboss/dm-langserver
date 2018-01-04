namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a DM <see langword="while"/> loop
    /// </summary>
	interface IWhile : IStatement
	{
        /// <summary>
        /// The condition of the <see cref="IWhile"/>
        /// </summary>
		IExpression Condition { get; }
        /// <summary>
        /// The body of the <see cref="IWhile"/>
        /// </summary>
		IBlock Body { get; }
        /// <summary>
        /// <see langword="true"/> if this is a do-<see cref="IWhile"/> loop, <see langword="false"/> otherwise
        /// </summary>
        bool AlwaysRunOnce { get; }
	}
}
