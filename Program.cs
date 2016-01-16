using System;
using System.Linq;

namespace BoggleCracker
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if (args.Length < 1) {
				Console.WriteLine("you need to provide the dictionary location");
			}
			var root = new TrieNode(false);

			var words = Utils.ReadWordsFromDictionary(args.First(), System.Text.Encoding.GetEncoding("windows-1250"));
			foreach (var word in words) {
				//Console.WriteLine(word);	
				root.InsertWord(word);
			}

			//root.Print();
			while (true) {
				Console.WriteLine("please provide board representation");	
				var boardLetters = Console.ReadLine();
				var board = new BoggleBoard(boardLetters);
				board.PrintRepresentation();
				var foundWords = WordFinder.FindWords(board, root);
				foreach (var foundWord in foundWords) {
					Console.WriteLine(foundWord);
				}
			}
		}
	}
}
