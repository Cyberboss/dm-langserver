namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a <see langword="for"/> loop
    /// </summary>
	interface IFor : IWhile
	{
        /// <summary>
        /// The initialization <see cref="IStatement"/>
        /// </summary>
		IStatement Initializer { get; }
        /// <summary>
        /// The <see cref="IExpression"/> run on loop completion
        /// </summary>
		IExpression Advancer { get; }
	}
}
