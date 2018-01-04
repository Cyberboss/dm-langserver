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
		public void TestTGWorldNew()
		{
			var tokens = GetTokensForResource(DMFiles.TGWorldNew);

			var expectedTokens = new List<int> { DMParser.SLASH, DMParser.WORLD, DMParser.SLASH, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.LCURL, DMParser.ID, DMParser.LPAREN, DMParser.DQUOTE, DMParser.ID, DMParser.ID, DMParser.ID, DMParser.LBRACE, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.RBRACE, DMParser.DQUOTE, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.LPAREN, DMParser.DQUOTE, DMParser.ID, DMParser.SLASH, DMParser.ID, DMParser.SLASH, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.DQUOTE, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.NEW, DMParser.SLASH, DMParser.DATUM, DMParser.SLASH, DMParser.ID, DMParser.SLASH, DMParser.ID, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.SLASH, DMParser.DATUM, DMParser.SLASH, DMParser.ID, DMParser.SLASH, DMParser.ID, DMParser.RPAREN, DMParser.SEMI, DMParser.IF, DMParser.LPAREN, DMParser.GLOBAL, DMParser.DOT, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.LPAREN, DMParser.SLASH, DMParser.DATUM, DMParser.SLASH, DMParser.ID, DMParser.SLASH, DMParser.ID, DMParser.SLASH, DMParser.ID, DMParser.RPAREN, DMParser.RPAREN, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.LPAREN, DMParser.ID, DMParser.LPAREN, DMParser.NUMBER, DMParser.COMMA, DMParser.DQUOTE, DMParser.ID, DMParser.DQUOTE, DMParser.RPAREN, DMParser.RPAREN, DMParser.STAR, DMParser.NUMBER, DMParser.SEMI, DMParser.IF, DMParser.LPAREN, DMParser.ID, DMParser.LPAREN, DMParser.ID, DMParser.RPAREN, DMParser.RPAREN, DMParser.LCURL, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.EQUALS, DMParser.ID, DMParser.LPAREN, DMParser.ID, DMParser.LPAREN, DMParser.ID, DMParser.LPAREN, DMParser.ID, DMParser.RPAREN, DMParser.RPAREN, DMParser.RPAREN, DMParser.SEMI, DMParser.ID, DMParser.LPAREN, DMParser.ID, DMParser.RPAREN, DMParser.SEMI, DMParser.RCURL, DMParser.ID, DMParser.DOT, DMParser.ID, DMParser.LPAREN, DMParser.NUMBER, DMParser.COMMA, DMParser.ID, DMParser.RPAREN, DMParser.SEMI, DMParser.RCURL, DMParser.Eof };

			Assert.AreEqual(tokens.Count, expectedTokens.Count);
			for (var I = 0; I < expectedTokens.Count; ++I)
				Assert.AreEqual(expectedTokens[I], tokens[I].Type);
		}
	}
}
