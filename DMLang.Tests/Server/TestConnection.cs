using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DMLang.Server.Tests
{
	/// <summary>
	/// Tests for <see cref="Server"/>
	/// </summary>
	[TestClass]
	public sealed class TestConnection
	{
		[TestMethod]
		public void TestInstatiation()
		{
			new Server(new MemoryStream(), new MemoryStream());
		}
	}
}
