using System;

namespace DMLang.Server.AST
{
    /// <inheritdoc />
	sealed class Label : Statement, ILabel
    {
        /// <inheritdoc />
        public string Name => name;

        /// <summary>
        /// Backing field for <see cref="Name"/>
        /// </summary>
		readonly string name;

        /// <summary>
        /// Construct a <see cref="Label"/>
        /// </summary>
        /// <param name="_name">The value for <see cref="Name"/></param>
        /// <param name="location">The value for <see cref="Statement.Location"/></param>
		public Label(string _name, ISourceLocation location) : base(location)
		{
			name = _name ?? throw new ArgumentNullException(nameof(_name));
		}

        /// <inheritdoc />
        protected override bool IsBlockTerminating()
		{
			return false;
		}
	}
}
