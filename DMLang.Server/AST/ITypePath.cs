using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	interface ITypePath : IValue
	{
		RootType RootType { get; }

		IDatum Datum { get; }
	}
}
