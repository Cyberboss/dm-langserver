using System;
using System.Collections.Generic;
using System.Linq;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	sealed class TypeSpecifier : ITypeSpecifier
	{
		/// <inheritdoc />
		public PathType Type => Datum != null ? PathType.Datum : Proc != null ? PathType.Proc : PathType.Unresolved;
		/// <inheritdoc />
		public IDatum Datum => datum;
		/// <inheritdoc />
		public IProc Proc => proc;

		readonly IReadOnlyList<string> fullPath;

		/// <summary>
		/// Backing field for <see cref="Datum"/>
		/// </summary>
		IDatum datum;
		/// <summary>
		/// Backing field for <see cref="Proc"/>
		/// </summary>
		IProc proc;

		/// <summary>
		/// Construct a <see cref="TypeSpecifier"/>
		/// </summary>
		/// <param name="_fullPath">List of identifiers to the target path</param>
		public TypeSpecifier(IEnumerable<string> _fullPath)
		{
			if (fullPath == null)
				throw new ArgumentNullException(nameof(_fullPath));
			var asList = new List<string>();
			asList.AddRange(fullPath);
		}

		/// <inheritdoc />
		public PathType Resolve(IAST ast)
		{
			if (fullPath.Count == 0)
				// TODO
				throw new NotImplementedException();

			if (fullPath.Any(x => x == nameof(proc)))
				CheckProcs(ast);
			else
				CheckDatums(ast);
			return Type;
		}

		/// <summary>
		/// Resolves the <see cref="TypeSpecifier"/> using the <see cref="IDatum"/>s of an <see cref="IAST"/>
		/// </summary>
		/// <param name="ast">The <see cref="IAST"/> to use for resolution</param>
		void CheckDatums(IAST ast)
		{
			IReadOnlyList<IDatum> currentList = ast.RootDatums;
			IDatum found = null;
			for (var I = 1; I < fullPath.Count; ++I)
			{
				if (found != null)
				{
					currentList = found.Children;
					found = null;
				}

				var search = fullPath[I];
				foreach (var J in currentList)
					if (J.Name == search)
					{
						found = J;
						break;
					}

				if (found == null)
					// TODO
					throw new NotImplementedException();
			}

			datum = found;
		}
	}
}
