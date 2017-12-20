using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	interface IString : IValue
	{
		string Flatten { get; }
		string Formatter { get; }

		IReadOnlyList<IExpression> Expressions { get; }
	}
}
