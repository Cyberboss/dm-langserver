namespace DMLang.Server.AST
{
	/// <summary>
	/// A var not guaranteed to exist at runtime
	/// </summary>
	interface IUnsafeVar
	{
		/// <summary>
		/// The name of the <see cref="IUnsafeVar"/>
		/// </summary>
		string Name { get; }

		/// <summary>
		/// The <see cref="IUnsafeVar"/> used to retrieve this <see cref="IUnsafeVar"/>. <see langword="null"/> if none
		/// </summary>
		IUnsafeVar Owner { get; }
	}
}
