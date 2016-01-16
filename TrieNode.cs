using System;
using System.Collections.Generic;

namespace BoggleCracker
{
	public class TrieNode
	{
		public bool ContainsWord { get; set; }

		public Dictionary<char, TrieNode> Children { get; set; } 

		public TrieNode(bool containsWord)
		{
			Children = new Dictionary<char, TrieNode>();
			this.ContainsWord = containsWord;
		}

		public TrieNode GetOrInsertChild(char childsCharacter) {
			if(Children.ContainsKey(childsCharacter)) {
				return Children[childsCharacter];
			}

			var ret = new TrieNode(false);
			Children.Add(childsCharacter, ret);
			return ret;
		}

		public void InsertWord(string word) {
			var curNode = this;
			foreach (var chr in word) {
				curNode = curNode.GetOrInsertChild(chr);	
			}
			curNode.ContainsWord = true;
		}

		public void Print() {
			Print(0);
		}

		private void Print(int level) {
			var indent = new String('-', level);
			foreach (var kv in Children) {
				var c = kv.Key;
				var node = kv.Value;

				Console.Write(indent);
				Console.Write(c);
				if (node.ContainsWord) {
					Console.Write(" *");
				}
				Console.WriteLine();

				node.Print(level + 1);
			}	
		}
	}
}

