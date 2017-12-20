using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	interface IOperationExpression : IExpression
	{
		IExpression Left { get; }

		NumericOperation Operation { get; }

		IExpression Right { get; }
	}
}
