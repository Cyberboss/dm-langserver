using System.Collections.Generic;

namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a DM string
    /// </summary>
	interface IString : IValue
	{
        /// <summary>
        /// The C# formatter <see cref="string"/> for the statements. i.e. "ASD {0} FKS {1}"
        /// </summary>
		string Formatter { get; }

        /// <summary>
        /// The <see cref="IExpression"/>s for formatting the <see cref="IString"/>
        /// </summary>
		IReadOnlyList<IExpression> Expressions { get; }
	}
}
