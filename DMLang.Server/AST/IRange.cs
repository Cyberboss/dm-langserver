using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <summary>
	/// (x to y)
	/// FUCK THIS FUCKING WEIRDASS MAGICAL BULLSHIT WHAT IS IT??!?!?!?!
	/// </summary>
	interface IRange : IConstantValue
	{
		IReadOnlyList<IConstantValue> Items { get; }
	}
}
