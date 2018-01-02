using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	sealed class ConstantString : String, IConstantString
	{
		/// <summary>
		/// Construct a <see cref="ConstantString"/>
		/// </summary>
		/// <param name="value"></param>
		/// <param name="_location"></param>
		public ConstantString(string value, ISourceLocation _location) : base(value, new List<IExpression>(), _location) { }
	}
}
