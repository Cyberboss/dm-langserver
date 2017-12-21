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
		public ITypePath TypePath => typePath;

		/// <summary>
		/// Backing field for <see cref="Qualifier"/>
		/// </summary>
		readonly VarQualifier qualifier;
		/// <summary>
		/// Backing field for <see cref="Initializer"/>
		/// </summary>
		readonly IExpression initializer;
		/// <summary>
		/// Backing field for <see cref="TypePath"/>
		/// </summary>
		readonly ITypePath typePath;

		/// <summary>
		/// Construct a <see cref="Var"/>
		/// </summary>
		/// <param name="name">The value of <see cref="UnsafeVar.Name"/></param>
		/// <param name="owner">The value of <see cref="UnsafeVar.Owner"/></param>
		/// <param name="_qualifier">The value of <see cref="Qualifier"/></param>
		/// <param name="_initializer">The value of <see cref="Initializer"/></param>
		/// <param name="_typePath">The value of <see cref="TypePath"/></param>
		public Var(string name, IUnsafeVar owner, VarQualifier _qualifier, IExpression _initializer, ITypePath _typePath) : base(name, owner)
		{
			qualifier = _qualifier;
			initializer = _initializer;
			typePath = _typePath ?? throw new ArgumentNullException(nameof(_typePath));
		}
	}
}
