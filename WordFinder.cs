using System;
using System.Collections.Generic;
using System.Linq;

namespace BoggleCracker
{
	public static class WordFinder
	{
		public static List<string> FindWords(BoggleBoard board, TrieNode dictionaryTrieRoot) {
			var res = new List<string>();

			for (int i = 0; i < 16; i++) {
				FindWords(board, dictionaryTrieRoot, i, "", res);	
			}

			return res;
		}

		private static void FindWords(BoggleBoard board, TrieNode previousTrieNode, int boardPosition, string currentPrefix, List<string> results) {
			if(! board.IsUnusedAndWithinBoard(boardPosition)) {
				// this board position was most likely used before
				return;
			}

			var curCharacter = board.GetCharacter(boardPosition);

			if (!previousTrieNode.Children.ContainsKey(curCharacter)) {
				// there are no possible words continuing with the character in the current board position
				return;
			}

			board.Use(boardPosition);
			string currentWord = currentPrefix + curCharacter;
			var currentTrieNode = previousTrieNode.Children[curCharacter];

			if (currentTrieNode.ContainsWord) {
				results.Add(currentWord);
			}

			foreach (var idx in board.GetUnusedNeighbors(boardPosition)) {
				FindWords(board, currentTrieNode, idx, currentWord, results);
			}

			board.Unuse(boardPosition);
		}
	}
}

