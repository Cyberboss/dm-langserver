using System.Collections.Generic;

namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a proc
    /// </summary>
	interface IProc : IProcOverride, IPathable
	{
        /// <summary>
        /// The top level name of the <see cref="IProc"/>
        /// </summary>
		string Name { get; }
	}
}
