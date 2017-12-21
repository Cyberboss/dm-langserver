using System;
namespace DMLang.Server.AST
{
	interface IAdjustOperation : IExpression
	{
		IExpression InnerExpression { get; }
		bool IsAddition { get; }
		bool IsPre { get; }
	}
}
