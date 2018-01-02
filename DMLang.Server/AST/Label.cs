using System;

namespace DMLang.Server.AST
{
	sealed class Label : Statement, ILabel
	{
		public string Name => name;

		readonly string name;

		public Label(string _name, ISourceLocation location) : base(location)
		{
			name = _name ?? throw new ArgumentNullException(nameof(_name));
		}

		protected override bool IsBlockTerminating()
		{
			return false;
		}
	}
}
