namespace DMLang.Server.AST
{
	/// <summary>
	/// Represents a label for a <see cref="IGoto"/>
	/// </summary>
	interface ILabel : IStatement
	{
		/// <summary>
		/// The name of the label
		/// </summary>
		string Name { get; }
	}
}
