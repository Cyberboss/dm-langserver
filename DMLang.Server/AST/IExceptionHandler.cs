namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a try/catch <see cref="IStatement"/>
    /// </summary>
	interface IExceptionHandler : IStatement
	{
        /// <summary>
        /// The code inside the try
        /// </summary>
		IBlock Try { get; }

        /// <summary>
        /// The exception <see cref="IVar"/>, if any
        /// </summary>
		IVar Exception { get; }

        /// <summary>
        /// The code inside the catch
        /// </summary>
		IBlock Catch { get; }
	}
}
