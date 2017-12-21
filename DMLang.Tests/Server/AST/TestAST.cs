using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DMLang.Server.AST.Tests
{
	/// <summary>
	/// Tests for <see cref="AST"/>
	/// </summary>
	[TestClass]
	public sealed class TestAST
	{
		[TestMethod]
		public void TestConstruction()
		{
			new AST();
		}
	}
}