using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	interface IDatum
	{
		string Name { get; }
		ITypePath Type { get; }

		IReadOnlyList<ISourceLocation> Locations { get; }

		IReadOnlyList<IDatum> Children { get; }
		IReadOnlyDictionary<string, IVar> Vars { get; }

		/// <summary>
		/// Refers to the parentmost procs by name
		/// </summary>
		IReadOnlyDictionary<string, IProc> Procs { get; }
	}
}
