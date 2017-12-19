using DMLang.Server;
using System;
using System.Text;

namespace DMLang.Console
{
	static class Program
	{
		static void Main()
		{
			System.Diagnostics.Debugger.Launch();
			System.Console.OutputEncoding = Encoding.UTF8;
			var factory = new ServerFactory();
			var app = factory.CreateServer(System.Console.OpenStandardInput(), System.Console.OpenStandardOutput());
			try
			{
				app.Listen().Wait();
			}
			catch (AggregateException)
			{
				Environment.Exit(-1);
			}
		}
	}
}
