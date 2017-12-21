using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	sealed class AST : IAST
	{
		/// <inheritdoc />
		public IReadOnlyDictionary<string, IVar> GlobalVars => globalVars;

		/// <inheritdoc />
		public IReadOnlyList<IDatum> RootDatums => rootDatums;

		/// <inheritdoc />
		public IReadOnlyDictionary<string, IProc> GlobalProcs => globalProcs;

		/// <inheritdoc />
		public IReadOnlyList<string> ResourcePaths => resourcePaths;

		/// <inheritdoc />
		public IReadOnlyList<string> StringFormatters => stringFormatters;

		/// <summary>
		/// Backing field for <see cref="GlobalVars"/>
		/// </summary>
		readonly Dictionary<string, IVar> globalVars;
		/// <summary>
		/// Backing field for <see cref="RootDatums"/>
		/// </summary>
		readonly List<IDatum> rootDatums;
		/// <summary>
		/// Backing field for <see cref="GlobalProcs"/>
		/// </summary>
		readonly Dictionary<string, IProc> globalProcs;
		/// <summary>
		/// Backing field for <see cref="ResourcePaths"/>
		/// </summary>
		readonly List<string> resourcePaths;
		/// <summary>
		/// Backing field for <see cref="StringFormatters"/>
		/// </summary>
		readonly List<string> stringFormatters;

		/// <summary>
		/// Construct an <see cref="AST"/>
		/// </summary>
		public AST()
		{
			globalVars = new Dictionary<string, IVar>();
			rootDatums = new List<IDatum>();
			globalProcs = new Dictionary<string, IProc>();
			resourcePaths = new List<string>();
			stringFormatters = new List<string>();
		}
	}
}
