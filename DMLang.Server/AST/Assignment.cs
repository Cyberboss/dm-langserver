using System;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	sealed class Assignment : Statement, IAssignment
	{
		/// <inheritdoc />
		public IUnsafeVar LeftHand => leftHand;
		/// <inheritdoc />
		public AssignmentOperation AssignmentOperation => assignmentOperation;
		/// <inheritdoc />
		public IExpression RightHand => rightHand;

		/// <summary>
		/// Backing field for <see cref="LeftHand"/>
		/// </summary>
		readonly IUnsafeVar leftHand;
		/// <summary>
		/// Backing field for <see cref="AssignmentOperation"/>
		/// </summary>
		readonly AssignmentOperation assignmentOperation;
		/// <summary>
		/// Backing field for <see cref="RightHand"/>
		/// </summary>
		readonly IExpression rightHand;

		/// <summary>
		/// Construct an <see cref="Assignment"/>
		/// </summary>
		/// <param name="_leftHand">The value of <see cref="LeftHand"/></param>
		/// <param name="_rightHand">The value of <see cref="RightHand"/></param>
		/// <param name="_location">The value of <see cref="Statement.Location"/></param>
		/// <param name="_assignmentOperation">The value of <see cref="AssignmentOperation"/></param>
		public Assignment(IUnsafeVar _leftHand, IExpression _rightHand, ISourceLocation _location, AssignmentOperation _assignmentOperation =  AssignmentOperation.None) : base(_location)
		{
			leftHand = _leftHand ?? throw new ArgumentNullException(nameof(_leftHand));
			rightHand = _rightHand ?? throw new ArgumentNullException(nameof(_rightHand));
			assignmentOperation = _assignmentOperation;
		}

		/// <inheritdoc />
		protected override bool IsBlockTerminating()
		{
			return false;
		}
	}
}
