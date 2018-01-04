namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a mathematicalish operation
    /// </summary>
	enum NumericOperation
	{
        /// <summary>
        /// !=
        /// </summary>
		NotEquals,
        /// <summary>
        /// ==
        /// </summary>
		Equals,
        /// <summary>
        /// +
        /// </summary>
		Addition,
        /// <summary>
        /// -
        /// </summary>
		Subtraction,
        /// <summary>
        /// *
        /// </summary>
		Multiplication,
        /// <summary>
        /// /
        /// </summary>
		Division,
        /// <summary>
        /// &amp;&amp;
        /// </summary>
		LogicalAnd,
        /// <summary>
        /// ||
        /// </summary>
		LogicalOr,
        /// <summary>
        /// &amp;
        /// </summary>
		BinaryAnd,
        /// <summary>
        /// |
        /// </summary>
		BinaryOr,
        /// <summary>
        /// ^
        /// </summary>
		Xor,
        /// <summary>
        /// %
        /// </summary>
		Modulo,
        /// <summary>
        /// in
        /// </summary>
		In
	}
}
