using System;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	sealed class Argument : IArgument
	{
		/// <inheritdoc />
		public string Name => name;
		/// <inheritdoc />
		public IExpression Value => value;

		/// <summary>
		/// Backing field for <see cref="Name"/>
		/// </summary>
		readonly string name;
		/// <summary>
		/// Backing field for <see cref="Value"/>
		/// </summary>
		readonly IExpression value;

		/// <summary>
		/// Construct an <see cref="Argument"/>
		/// </summary>
		/// <param name="_name">The value of <see cref="Name"/></param>
		/// <param name="_value">The value of <see cref="Value"/></param>
		public Argument(string _name, IExpression _value)
		{
			name = _name;
			value = _value ?? throw new ArgumentNullException(nameof(_value));
		}
	}
}
