namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a <see langword="goto"/> <see cref="IStatement"/>
    /// </summary>
	interface IGoto : IStatement
	{
        /// <summary>
        /// The <see cref="ILabel"/> the <see cref="IGoto"/> goes to
        /// </summary>
		ILabel Target { get; }
	}
}
