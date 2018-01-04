namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a code statememnt
    /// </summary>
	interface IStatement
	{
        /// <summary>
        /// The <see cref="ISourceLocation"/> of the <see cref="IStatement"/>
        /// </summary>
		ISourceLocation Location { get; }

        /// <summary>
        /// If this statement ends the current <see cref="IBlock"/>
        /// </summary>
		bool BlockTerminator { get; }
	}
}
