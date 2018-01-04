using System.Collections.Generic;

namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a call to a <see cref="IProc"/>
    /// </summary>
	interface IProcCall : IExpression
	{
        /// <summary>
        /// The owner of the <see cref="IProc"/>, if any
        /// </summary>
		IUnsafeVar Owner { get; }

        /// <summary>
        /// The name of the <see cref="IProc"/> being called
        /// </summary>
		string Name { get; }

        /// <summary>
        /// A reference to the <see cref="IProc"/> being called if it can be resolved
        /// </summary>
        IProc HardReference { get; }
		
        /// <summary>
        /// The <see cref="IArgument"/>s for the call
        /// </summary>
		IReadOnlyList<IArgument> Arguments { get; }
	}
}
