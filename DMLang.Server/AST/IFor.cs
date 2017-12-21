using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	interface IFor : IWhile
	{
		IStatement Initializer { get; }
		IExpression Advancer { get; }
	}
}
