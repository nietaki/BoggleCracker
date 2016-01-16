using System;
using System.Linq;
using System.Globalization;

namespace BoggleCracker
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if (args.Length < 2) {
				Console.WriteLine("you need to provide 2 arguments: the culture (like pl-PL) and the path to the word dictionary");
			}

			Utils.CurrentCultureInfo = CultureInfo.CreateSpecificCulture(args.First());

			var root = new TrieNode(false);

			var words = Utils.ReadWordsFromDictionary(args[1], System.Text.Encoding.GetEncoding("windows-1250"));
			foreach (var word in words) {
				//Console.WriteLine(word);	
				root.InsertWord(word);
			}

			//root.Print();
			while (true) {
				Console.WriteLine("Please provide board representation (one line, 16 characters):");	
				var boardLetters = Console.ReadLine();
				if (boardLetters.Length == 16) {
					var board = new BoggleBoard(boardLetters);
					board.PrintRepresentation();

					var foundWords = WordFinder.FindWords(board, root);

					var longEnoughWords = foundWords.Where(w => w.Length > 2).Distinct().ToList();
					Utils.SortByLengthAndAlphabet(longEnoughWords);

					foreach (var foundWord in longEnoughWords.Select(w => w.ToUpper(Utils.CurrentCultureInfo))) {
						Console.WriteLine(foundWord);
					}
				}
			}
		}
	}
}
