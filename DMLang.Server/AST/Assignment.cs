using System;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	sealed class Assignment : IAssignment
	{
		/// <inheritdoc />
		public IUnsafeVar LeftHand => leftHand;
		/// <inheritdoc />
		public AssignmentOperation AssignmentOperation => assignmentOperation;
		/// <inheritdoc />
		public IExpression RightHand => rightHand;
		/// <inheritdoc />
		public ISourceLocation Location => location;
		/// <inheritdoc />
		public bool BlockTerminator => false;

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
		/// Backing field for <see cref="Location"/>
		/// </summary>
		readonly ISourceLocation location;

		/// <summary>
		/// Construct an <see cref="Assignment"/>
		/// </summary>
		/// <param name="_leftHand">The value of <see cref="LeftHand"/></param>
		/// <param name="_rightHand">The value of <see cref="RightHand"/></param>
		/// <param name="_location">The value of <see cref="Location"/></param>
		/// <param name="_assignmentOperation">The value of <see cref="AssignmentOperation"/></param>
		public Assignment(IUnsafeVar _leftHand, IExpression _rightHand, ISourceLocation _location, AssignmentOperation _assignmentOperation =  AssignmentOperation.None)
		{
			leftHand = _leftHand ?? throw new ArgumentNullException(nameof(_leftHand));
			rightHand = _rightHand ?? throw new ArgumentNullException(nameof(_rightHand));
			location = _location ?? throw new ArgumentNullException(nameof(_location));
			assignmentOperation = _assignmentOperation;
		}
	}
}
