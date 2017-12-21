using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMLang.Tests;
using System.Collections.Generic;

namespace DMLang.Server.Parser.Tests
{
	[TestClass]
	public sealed class TestDMLexer
	{
		static IList<IToken> GetTokensForResource(byte[] resource)
		{
			var cts = Helpers.GetCommonTokenStream(resource, (i) => new DMLexer(i));
			cts.Fill();
			return cts.GetTokens();
		}

		[TestMethod]
		public void TestGlobalProcPrototype()
		{
			var tokens = GetTokensForResource(DMFiles.GlobalProcPrototype);

			var expectedTokens = new List<int> { DMParser.SLASH, DMParser.PROC, DMParser.SLASH, DMParser.ID, DMParser.LPAREN, DMParser.VAR, DMParser.SLASH, DMParser.ID, DMParser.COMMA, DMParser.VAR, DMParser.SLASH, DMParser.LIST, DMParser.SLASH, DMParser.ID, DMParser.COMMA, DMParser.DATUM, DMParser.SLASH, DMParser.ID, DMParser.RPAREN, DMParser.Eof };

			Assert.AreEqual(tokens.Count, expectedTokens.Count);
			for (var I = 0; I < expectedTokens.Count; ++I)
				Assert.AreEqual(expectedTokens[I], tokens[I].Type);
		}

		[TestMethod]
		public void TestListener()
		{

		}
	}
}
