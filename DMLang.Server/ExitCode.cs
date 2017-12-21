namespace DMLang.Server
{
	enum ExitCode : int
	{
		InternalError = -1,
		Success = 0,
		NoShutdown = 1,
		NoExit = 2,
		BadStop = 3
	}
}