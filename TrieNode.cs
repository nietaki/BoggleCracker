using System;
using System.Collections.Generic;

namespace BoggleCracker
{
	public class TrieNode
	{
		bool ContainsWord { get; set; }

		Dictionary<char, TrieNode> children { get; set; } 

		public TrieNode(bool containsWord)
		{
			children = new Dictionary<char, TrieNode>();
			this.ContainsWord = containsWord;
		}

		public TrieNode GetOrInsertChild(char childsCharacter) {
			if(children.ContainsKey(childsCharacter)) {
				return children[childsCharacter];
			}

			var ret = new TrieNode(false);
			children.Add(childsCharacter, ret);
			return ret;
		}

		public void InsertWord(string word) {
			var curNode = this;
			foreach (var w in word) {
				curNode = curNode.GetOrInsertChild(w);	
			}
			curNode.ContainsWord = true;
		}

		public void Print() {
			Print(0);
		}

		private void Print(int level) {
			var indent = new String('-', level);
			foreach (var kv in children) {
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

