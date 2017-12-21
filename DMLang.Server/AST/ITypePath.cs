using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	interface ITypePath : IValue
	{
		bool IsProcTypePath { get; }
		IDatum Datum { get; }
		IProc Proc { get; }
	}
}
