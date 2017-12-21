using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

		[TestMethod]
		public void TestAddByondBuiltinsCantBeCalledMoreThanOnce()
		{
			var ast = new AST();
			ast.AddByondBuiltins();
			Assert.ThrowsException<InvalidOperationException>(() => ast.AddByondBuiltins());
		}

		[TestMethod]
		public void TestAddStdDefCantBeCalledMoreThanOnce()
		{
			var ast = new AST();
			ast.AddStdDef();
			Assert.ThrowsException<InvalidOperationException>(() => ast.AddStdDef());
		}
	}
}