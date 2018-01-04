using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMLang.Tests;

namespace DMLang.Server.Parser.Tests
{
	[TestClass]
    public sealed class TestPreprocessorLexer
    {
		[TestMethod]
		public void TestLexer()
		{
			var cts = Helpers.GetCommonTokenStream(PreprocessorFiles.Basic, (i) => new PreprocessorLexer(i));
			cts.Fill();
		}
    }
}
