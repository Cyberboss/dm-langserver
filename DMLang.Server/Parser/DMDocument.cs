using System.Collections.Generic;
using System.IO;

namespace DMLang.Server.Parser
{
	/// <summary>
	/// Contains the path and content of a .dm file
	/// </summary>
	sealed class DMDocument
	{
		/// <summary>
		/// The path to the .dm from the workspace root
		/// </summary>
		public string FilePath { get; set; }
		/// <summary>
		/// The content of the .dm file
		/// </summary>
		public IReadOnlyList<string> Lines { get; set; }

		/// <summary>
		/// Construct a <see cref="DMDocument"/>
		/// </summary>
		/// <param name="filePath">The path to the document file from the workspace root</param>
		/// <param name="text">The text of the file</param>
		public DMDocument(string filePath, string text)
		{
			FilePath = filePath;
			var lines = new List<string>();
			using (var sr = new StringReader(text))
				for (string L = sr.ReadLine(); L != null; L = sr.ReadLine())
					lines.Add(L);
			Lines = lines;
		}
	}
}
