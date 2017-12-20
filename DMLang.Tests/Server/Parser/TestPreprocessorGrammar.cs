using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMLang.Tests;

namespace DMLang.Server.Parser.Tests
{
	[TestClass]
    public sealed class TestPreprocessorGrammar
    {
		[TestMethod]
		public void TestLexer()
		{
			var cts = Helpers.GetCommonTokenStream(TestFiles.Basic, (i) => new PreprocessorLexer(i));
			cts.Fill();
		}

		[TestMethod]
		public void TestListener()
		{
			var cts = Helpers.GetCommonTokenStream(TestFiles.Basic, (i) => new PreprocessorLexer(i));

		}
    }
}
