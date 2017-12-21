namespace DMLang.Server.AST
{
	/// <summary>
	/// Indicates what basic 
	/// </summary>
	enum PathType
	{
		/// <summary>
		/// The <see cref="ITypeSpecifier"/> has not been resolved
		/// </summary>
		Unresolved,
		/// <summary>
		/// The <see cref="ITypeSpecifier"/> refers to a <see cref="IProc"/>
		/// </summary>
		Proc,
		/// <summary>
		/// The <see cref="ITypeSpecifier"/> refers to a <see cref="IDatum"/>
		/// </summary>
		Datum
	}
}
