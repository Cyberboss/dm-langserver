using System.Collections.Generic;

namespace DMLang.Server.AST
{
	interface IDatum : IPathable
	{
        /// <summary>
        /// The topmost name of the datum
        /// </summary>
		string Name { get; }

        /// <summary>
        /// List of <see cref="ISourceLocation"/>s containing definitions of the <see cref="IDatum"/>
        /// </summary>
		IReadOnlyList<ISourceLocation> Locations { get; }

        /// <summary>
        /// <see cref="IDatum"/>s that inherit from this one
        /// </summary>
		IReadOnlyList<IDatum> Children { get; }
        /// <summary>
        /// <see cref="IVar"/>s defined on this <see cref="IDatum"/>. Does not include inherited <see cref="IVar"/>s
        /// </summary>
		IReadOnlyList<IVar> Vars { get; }

		/// <summary>
		/// <see cref="IProc"/>s defined on this <see cref="IDatum"/>. Does not include inherited <see cref="IProc"/>s
		/// </summary>
		IReadOnlyList<IProc> Procs { get; }
	}
}
