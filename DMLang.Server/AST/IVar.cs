namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a DM var
    /// </summary>
	interface IVar : IPathable, IUnsafeVar
	{
        /// <summary>
        /// The <see cref="VarQualifier"/> for the <see cref="IVar"/>
        /// </summary>
		VarQualifier Qualifier { get; }

        /// <summary>
        /// The initializing <see cref="IExpression"/>, if any
        /// </summary>
		IExpression Initializer { get; }
	}
}
