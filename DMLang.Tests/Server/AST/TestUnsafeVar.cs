using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DMLang.Server.AST.Tests
{
	/// <summary>
	/// Tests for <see cref="UnsafeVar"/>
	/// </summary>
	[TestClass]
	public sealed class TestUnsafeVar
	{
		[TestMethod]
		public void TestConstruction()
		{
			var first = new UnsafeVar("Name", null);
			Assert.AreEqual("Name", first.Name);
			Assert.IsNull(first.Owner);
			var second = new UnsafeVar("Name", first);
			Assert.AreSame(first, second.Owner);
			Assert.ThrowsException<ArgumentNullException>(() => new UnsafeVar(null, null));
			Assert.ThrowsException<ArgumentNullException>(() => new UnsafeVar(null, first));
		}
	}
}
