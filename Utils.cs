using System;
using System.Collections.Generic;
using System.IO;

namespace BoggleCracker
{
	public static class Utils
	{
		public static IEnumerable<string> ReadWordsFromDictionary(string path, System.Text.Encoding encoding) {
			return File.ReadLines(path, encoding);
		}
	}
}

