namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents something that uses a <see cref="ITypeSpecifier"/>
    /// </summary>
	interface IPathable
	{
        /// <summary>
        /// The <see cref="ITypeSpecifier"/> of the <see cref="IPathable"/>
        /// </summary>
		ITypeSpecifier TypeSpecifier { get; }
	}
}
