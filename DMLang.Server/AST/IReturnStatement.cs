namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a <see langword="return"/> <see cref="IStatement"/>
    /// </summary>
	interface IReturnStatement : IStatement
	{
        /// <summary>
        /// The <see cref="IExpression"/> being returned if any
        /// </summary>
		IExpression Expression { get; }
	}
}
