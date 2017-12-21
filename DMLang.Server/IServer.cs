using System.Threading.Tasks;

namespace DMLang.Server
{
	/// <summary>
	/// DM Langserver
	/// </summary>
	interface IServer
	{
		/// <summary>
		/// Start the langserver
		/// </summary>
		/// <returns>A <see cref="Task"/> resulting in the <see cref="ExitCode"/> of the <see cref="IServer"/></returns>
		Task<ExitCode> Run();
	}
}
