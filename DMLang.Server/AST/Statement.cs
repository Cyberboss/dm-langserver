using System;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	abstract class Statement : IStatement
	{
		/// <inheritdoc />
		public ISourceLocation Location => location;
		/// <inheritdoc />
		public bool BlockTerminator => IsBlockTerminating();

		/// <summary>
		/// Backing field for <see cref="Location"/>
		/// </summary>
		readonly ISourceLocation location;

		/// <summary>
		/// Construct a <see cref="Statement"/>
		/// </summary>
		/// <param name="_location">The value of <see cref="Location"/></param>
		protected Statement(ISourceLocation _location)
		{
			location = _location ?? throw new ArgumentNullException(nameof(_location));
		}

		/// <summary>
		/// Whether or not this <see cref="Statement"/> is terminating for a <see cref="IBlock"/>
		/// </summary>
		/// <returns><see langword="true"/> if this <see cref="Statement"/> is terminal, <see langword="false"/> otherwise</returns>
		protected abstract bool IsBlockTerminating();
	}
}
