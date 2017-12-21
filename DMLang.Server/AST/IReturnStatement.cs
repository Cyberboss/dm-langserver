namespace DMLang.Server.AST
{
	interface IReturnStatement : IStatement
	{
		IExpression Expression { get; }
	}
}
