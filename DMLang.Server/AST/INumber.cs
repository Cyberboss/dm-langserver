namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a number
    /// </summary>
	interface INumber : IConstantValue
	{
        /// <summary>
        /// The value of the <see cref="INumber"/>
        /// </summary>
		float Number { get; }
	}
}
