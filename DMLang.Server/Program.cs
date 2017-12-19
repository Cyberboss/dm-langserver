using System.Text;
using System.Threading.Tasks;

namespace DMLang.Server
{
	static class Program
	{
		static readonly IServerFactory factory = new ServerFactory();

		static async Task<int> Main()
		{
			System.Diagnostics.Debugger.Launch();
			System.Console.OutputEncoding = Encoding.UTF8;
			var app = factory.CreateServer(System.Console.OpenStandardInput(), System.Console.OpenStandardOutput());
			return (int)await app.Run();
		}
	}
}
