using System.Collections.Generic;

namespace DMLang.Server.AST
{
	/// <summary>
	/// FUCK THIS FUCKING WEIRDASS MAGICAL BULLSHIT WHAT IS IT??!?!?!?!
	/// </summary>
	interface IRange : IConstantValue, IExpression
	{
		IReadOnlyList<IConstantValue> Items { get; }
	}
}
