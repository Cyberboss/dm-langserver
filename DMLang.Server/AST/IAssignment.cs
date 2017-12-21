namespace DMLang.Server.AST
{
	/// <summary>
	/// An assignemnt <see cref="IStatement"/>
	/// </summary>
	interface IAssignment : IStatement, IExpression
	{
		/// <summary>
		/// The left hand side of the <see cref="IAssignment"/>
		/// </summary>
		IUnsafeVar LeftHand { get; }

		/// <summary>
		/// The <see cref="DMLang.Server.AST.AssignmentOperation"/> occurring during the <see cref="IAssignment"/>
		/// </summary>
		AssignmentOperation AssignmentOperation { get; }

		/// <summary>
		/// The right hand side of the <see cref="IAssignment"/>
		/// </summary>
		IExpression RightHand { get; }
	}
}
