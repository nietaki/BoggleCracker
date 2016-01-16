using System;
using System.Linq;

namespace BoggleCracker
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if (args.Length < 1) {
				Console.WriteLine("you need to provide the dictionary location as the program argument");
			}

			var root = new TrieNode(false);

			var words = Utils.ReadWordsFromDictionary(args.First(), System.Text.Encoding.GetEncoding("windows-1250"));
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

					foreach (var foundWord in longEnoughWords.Select(w => w.ToUpper(Utils.PolishCultureInfo))) {
						Console.WriteLine(foundWord);
					}
				}
			}
		}
	}
}
