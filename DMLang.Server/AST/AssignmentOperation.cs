namespace DMLang.Server.AST
{
	/// <summary>
	/// Operation to perform during an <see cref="IAssignment"/>
	/// </summary>
	enum AssignmentOperation
	{
        /// <summary>
        /// =
        /// </summary>
		None,
        /// <summary>
        /// +=
        /// </summary>
		Addition,
        /// <summary>
        /// -=
        /// </summary>
		Subtraction,
        /// <summary>
        /// *=
        /// </summary>
		Multiplication,
        /// <summary>
        /// /=
        /// </summary>
		Division,
        /// <summary>
        /// |=
        /// </summary>
		Or,
        /// <summary>
        /// &amp;=
        /// </summary>
		And,
        /// <summary>
        /// ^=
        /// </summary>
		Xor,
        /// <summary>
        /// %=
        /// </summary>
		Modulo
	}
}
