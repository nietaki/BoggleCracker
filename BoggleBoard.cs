using System;
using System.Collections.Generic;
using System.Linq;

namespace BoggleCracker
{
	public class BoggleBoard
	{
		private static readonly List<int>[] neigborsMemo = new List<int>[16];

		private string letters;
		private bool[] isUsed;

		public BoggleBoard(string rows)
		{
			if (rows.Length != 4 * 4) {
				throw new ArgumentException("boggle board consists of 16 characters", rows);
			}
			this.letters = rows.ToLower(Utils.CurrentCultureInfo);
			this.isUsed = new bool[16];
		}

		public char GetCharacter(int idx) {
			return letters[idx];
		}

		public void PrintRepresentation() {
			Console.WriteLine();
			for (int i = 0; i < 4; i++) {
				Console.WriteLine(letters.Substring(i * 4, 4).ToUpper(Utils.CurrentCultureInfo));
			}
			Console.WriteLine();
		}

		private void SetUsageState(int idx, bool usageState) {
			if (this.isUsed[idx] == usageState) {
				throw new ArgumentException("trying to use/unuse an already used/unused field");
			}
			this.isUsed[idx] = usageState;
		}

		public void Use(int idx) {
			this.SetUsageState(idx, true);
		}

		public void Unuse(int idx) {
			this.SetUsageState(idx, false);
		}

		public static IEnumerable<int> GetNeighbors(int idx) {
			if (neigborsMemo[idx] != null) {
				return neigborsMemo[idx];
			}

			List<int> indices = new List<int>();	
			indices.Add(idx - 4);
			indices.Add(idx + 4);

			if (!IsOnLeftWall(idx)) {
				indices.Add(idx - 5);
				indices.Add(idx - 1);
				indices.Add(idx + 3);
			}

			if (!IsOnRightWall(idx)) {
				indices.Add(idx - 3);
				indices.Add(idx + 1);
				indices.Add(idx + 5);
			}

			var ret = indices.Where(IsWithinBoard).ToList();
			neigborsMemo[idx] = ret;
			return ret;
		}

		public IEnumerable<int> GetUnusedNeighbors(int idx) {
			return GetNeighbors(idx).Where(this.IsUnusedAndWithinBoard);
		}

		private static bool IsOnLeftWall(int idx) {
			return (idx % 4) == 0;
		}

		private static bool IsOnRightWall(int idx) {
			return (idx % 4) == 3;
		}

		public static bool IsWithinBoard(int idx) {
			return (idx >= 0) && (idx < 4 * 4);
		}	

		public bool IsUnusedAndWithinBoard(int idx) {
			return IsWithinBoard(idx) && !this.isUsed[idx];
		}
	}
}

