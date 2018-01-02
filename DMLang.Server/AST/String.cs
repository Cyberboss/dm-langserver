using System;
using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	class String : Statement, IString
	{
		/// <inheritdoc />
		public string Formatter => formatter;
		/// <inheritdoc />
		public IReadOnlyList<IExpression> Expressions => expressions;

		/// <summary>
		/// Backing field for <see cref="Formatter"/>
		/// </summary>
		readonly string formatter;
		/// <summary>
		/// Backing field for <see cref="Expressions"/>
		/// </summary>
		readonly List<IExpression> expressions;

		/// <summary>
		/// Create a <see cref="String"/>
		/// </summary>
		/// <param name="_formatter">The value of <see cref="Formatter"/></param>
		/// <param name="_expressions">The embedded <see cref="IExpression"/>s in <paramref name="_formatter"/></param>
		/// <param name="_location">The value of <see cref="Statement.Location"/></param>
		public String(string _formatter, IEnumerable<IExpression> _expressions, ISourceLocation _location) : base(_location)
		{
			if (_expressions == null)
				throw new ArgumentNullException(nameof(_expressions));
			formatter = _formatter ?? throw new ArgumentNullException(nameof(_formatter));
			expressions = new List<IExpression>();
			expressions.AddRange(_expressions);
		}

		/// <inheritdoc />
		protected override bool IsBlockTerminating()
		{
			return false;
		}
	}
}
