using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server
{
	interface ISourceLocation
	{
		string FilePath { get; }
		int LineNumber { get; }
	}
}
