using Antlr4.Runtime;
using System;
using System.IO;

namespace DMLang.Tests
{
	static class Helpers
	{
		static string ResToString(byte[] resource)
		{
			using (var memoryStream = new MemoryStream(resource))
				return new StreamReader(memoryStream).ReadToEnd();
		}

		public static CommonTokenStream GetCommonTokenStream(byte[] resource, Func<AntlrInputStream, Lexer> lexerFactory)
		{
			var ais = new AntlrInputStream(ResToString(resource));
			var lexer = lexerFactory(ais);
			return new CommonTokenStream(lexer);
		}
	}
}
