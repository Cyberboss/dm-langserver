using System;
using System.Collections.Generic;
using System.Globalization;

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

		bool addedBuiltins;
		bool addedStdDef;

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

		public void AddByondBuiltins()
		{
			if (addedBuiltins)
				throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, "Can only {0} once!", nameof(AddByondBuiltins)));


			addedBuiltins = true;
		}

		public void AddStdDef()
		{
			if (addedStdDef)
				throw new InvalidOperationException(String.Format(CultureInfo.InvariantCulture, "Can only {0} once!", nameof(AddStdDef)));


			addedStdDef = true;
		}
	}
}
