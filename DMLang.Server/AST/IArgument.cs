namespace DMLang.Server.AST
{
	/// <summary>
	/// A <see cref="IProcCall"/> argument
	/// </summary>
	interface IArgument
	{
		/// <summary>
		/// Name of named <see cref="IArgument"/>. <see langword="null"/> if unamed
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Value of the <see cref="IArgument"/>
		/// </summary>
		IExpression Value { get; }
	}
}
