using System.Collections.Generic;

namespace DMLang.Server.AST
{
    /// <summary>
    /// Represents a DM <see langword="switch"/> <see cref="IStatement"/>
    /// </summary>
	interface ISwitch : IStatement
	{
        /// <summary>
        /// The <see cref="IExpression"/> being switched on
        /// </summary>
		IExpression Condition { get; }
        /// <summary>
        /// The default <see cref="IBlock"/>
        /// </summary>
		IBlock Default { get; }

        /// <summary>
        /// Map of <see cref="IConstantValue"/>s to the <see cref="IBlock"/>s they invoke
        /// </summary>
		IDictionary<IConstantValue, IBlock> Cases { get; }
	}
}
