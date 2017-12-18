using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DMLang.Server.Tests
{
	/// <summary>
	/// Tests for <see cref="Connection"/>
	/// </summary>
	[TestClass]
	public sealed class TestConnection
	{
		[TestMethod]
		public void TestInstatiation()
		{
			new Connection(new MemoryStream(), new MemoryStream());
		}
	}
}
