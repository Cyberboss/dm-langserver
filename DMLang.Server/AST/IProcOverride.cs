using System.Collections.Generic;

namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents an override of a <see cref="IProc"/>
    /// </summary>
    interface IProcOverride
    {
        /// <summary>
        /// List of <see cref="IVar"/>s representing proc arguments
        /// </summary>
		IReadOnlyList<IVar> Arguments { get; }

        /// <summary>
        /// The owner <see cref="IDatum"/> if any
        /// </summary>
        IDatum Owner { get; }

        /// <summary>
        /// The <see cref="IProcOverride"/> that overides this one if any
        /// </summary>
		IProcOverride Override { get; }

        /// <summary>
        /// The code in the proc
        /// </summary>
		IBlock Contents { get; }
    }
}
