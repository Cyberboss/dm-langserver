namespace DMLang.Server.AST
{
	interface IGoto : IStatement
	{
		ILabel Target { get; }
	}
}
