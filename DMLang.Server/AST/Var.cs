using System;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	sealed class Var : UnsafeVar, IVar
	{
		/// <inheritdoc />
		public VarQualifier Qualifier => qualifier;
		/// <inheritdoc />
		public IExpression Initializer => initializer;
		/// <inheritdoc />
		public ITypeSpecifier TypeSpecifier => typeSpecifier;

		/// <summary>
		/// Backing field for <see cref="Qualifier"/>
		/// </summary>
		readonly VarQualifier qualifier;
		/// <summary>
		/// Backing field for <see cref="Initializer"/>
		/// </summary>
		readonly IExpression initializer;
		/// <summary>
		/// Backing field for <see cref="TypeSpecifier"/>
		/// </summary>
		readonly ITypeSpecifier typeSpecifier;

		/// <summary>
		/// Construct a <see cref="Var"/>
		/// </summary>
		/// <param name="name">The value of <see cref="UnsafeVar.Name"/></param>
		/// <param name="owner">The value of <see cref="UnsafeVar.Owner"/></param>
		/// <param name="_qualifier">The value of <see cref="Qualifier"/></param>
		/// <param name="_initializer">The value of <see cref="Initializer"/></param>
		/// <param name="_typeSpecifier">The value of <see cref="TypeSpecifier"/></param>
		public Var(string name, IUnsafeVar owner, VarQualifier _qualifier, IExpression _initializer, ITypeSpecifier _typeSpecifier) : base(name, owner)
		{
			qualifier = _qualifier;
			initializer = _initializer;
			typeSpecifier = _typeSpecifier ?? throw new ArgumentNullException(nameof(_typeSpecifier));
		}
	}
}
