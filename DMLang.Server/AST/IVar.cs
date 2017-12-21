namespace DMLang.Server.AST
{
	interface IVar : IPathable, IUnsafeVar
	{
		VarQualifier Qualifier { get; }

		IExpression Initializer { get; }
	}
}
