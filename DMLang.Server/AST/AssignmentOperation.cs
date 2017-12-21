using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server.AST
{
	/// <summary>
	/// Operation to perform during an <see cref="IAssignment"/>
	/// </summary>
	enum AssignmentOperation
	{
		None,
		Addition,
		Subtraction,
		Multiplication,
		Division,
		Or,
		And,
		Xor,
		Modulo
	}
}
