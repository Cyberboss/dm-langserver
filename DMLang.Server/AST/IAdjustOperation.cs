using System;
namespace DMLang.Server.AST
{
	interface IAdjustOperation : IExpression
	{
		IUnsafeVar Target { get; }
		bool IsAddition { get; }
		bool IsPre { get; }
	}
}
