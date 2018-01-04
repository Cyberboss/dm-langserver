namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents an operation on two <see cref="IExpression"/>s
    /// </summary>
	interface IOperationExpression : IExpression
	{
        /// <summary>
        /// The left side of the operation
        /// </summary>
		IExpression Left { get; }

        /// <summary>
        /// The <see cref="NumericOperation"/> to perform
        /// </summary>
		NumericOperation Operation { get; }
        
        /// <summary>
        /// The right side of the operation
        /// </summary>
        IExpression Right { get; }
	}
}
