using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <summary>
	/// (x to y)
	/// FUCK THIS FUCKING WEIRDASS MAGICAL BULLSHIT WHAT IS IT??!?!?!?!
	/// </summary>
	interface IRange : IConstantValue
	{
        /// <summary>
        /// IDK I GUESS ITS A LIST OF CONTANT VALUES OR SOME SHIT ITS FUCKING RETARDED
        /// </summary>
		IReadOnlyList<IConstantValue> Items { get; }
	}
}
