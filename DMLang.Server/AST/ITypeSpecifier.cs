namespace DMLang.Server.AST
{
	interface ITypeSpecifier
	{
		PathType Type { get; }
		IDatum Datum { get; }
		IProc Proc { get; }

		PathType Resolve(IAST ast);
	}
}
