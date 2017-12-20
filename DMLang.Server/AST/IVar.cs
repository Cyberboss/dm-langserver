namespace DMLang.Server.AST
{
	interface IVar : ITypePath, IUnsafeVar
	{
		bool Static { get; }

		IExpression Initializer { get; }
	}
}
