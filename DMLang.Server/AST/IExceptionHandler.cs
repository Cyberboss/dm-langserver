using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	interface IExceptionHandler : IStatement
	{
		IBlock Try { get; }

		IVar Exception { get; }

		IBlock Catch { get; }
	}
}
