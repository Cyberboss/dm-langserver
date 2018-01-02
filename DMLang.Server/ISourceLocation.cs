namespace DMLang.Server
{
	interface ISourceLocation
	{
		string FilePath { get; }
		int Line { get; }
		int Column { get; }
	}
}
