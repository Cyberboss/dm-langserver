using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	interface IBranch : IStatement
	{
		IExpression Condition { get; }
		IBlock True { get; }
		IBlock False { get; }
	}
}
