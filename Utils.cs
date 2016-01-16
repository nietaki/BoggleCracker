using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace BoggleCracker
{
	public static class Utils
	{
		public static IEnumerable<string> ReadWordsFromDictionary(string path, System.Text.Encoding encoding) {
			return File.ReadLines(path, encoding);
		}

		public static readonly CultureInfo PolishCultureInfo = CultureInfo.CreateSpecificCulture("pl-PL");

		public static void SortByLengthAndAlphabet(List<string> words) {
			words.Sort((x, y) => {
				var lengthDiff = y.Length - x.Length;
				if (lengthDiff != 0) {
					return lengthDiff;
				} 
				return x.CompareTo(y);
			});
		}
	}
}

