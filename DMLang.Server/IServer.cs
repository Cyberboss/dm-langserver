using System.Threading.Tasks;

namespace DMLang.Server
{
	/// <summary>
	/// DM Langserver
	/// </summary>
	public interface IServer
	{
		/// <summary>
		/// Start listening on the server
		/// </summary>
		/// <returns>A <see cref="Task"/> representing the operation</returns>
		Task Listen();
	}
}
