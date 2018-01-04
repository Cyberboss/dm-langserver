using System;

namespace DMLang.Server.AST
{
	/// <inheritdoc />
	class UnsafeVar : IUnsafeVar
	{
		/// <inheritdoc />
		public string Name => name;
		/// <inheritdoc />
		public IUnsafeVar Owner => owner;

		/// <summary>
		/// Backing field for <see cref="Name"/>
		/// </summary>
		readonly string name;
		/// <summary>
		/// Backing field for <see cref="Owner"/>
		/// </summary>
		readonly IUnsafeVar owner;

		/// <summary>
		/// Construct an <see cref="UnsafeVar"/>
		/// </summary>
		/// <param name="_name">The value of <see cref="Name"/></param>
		/// <param name="_owner">The value of <see cref="Owner"/></param>
		public UnsafeVar(string _name, IUnsafeVar _owner)
		{
			name = _name ?? throw new ArgumentNullException(nameof(_name));
			owner = _owner;
		}
	}
}
