using Antlr4.Runtime;
using System;
using System.Text;

namespace DMLang.Tests
{
	static class Helpers
	{
		static string ResToString(byte[] resource)
		{
			return Encoding.Default.GetString(resource);
		}

		public static CommonTokenStream GetCommonTokenStream(byte[] resource, Func<AntlrInputStream, Lexer> lexerFactory)
		{
			var ais = new AntlrInputStream(ResToString(resource));
			var lexer = lexerFactory(ais);
			return new CommonTokenStream(lexer);
		}
	}
}
