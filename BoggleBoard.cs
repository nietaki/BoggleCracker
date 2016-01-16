using System;

namespace BoggleCracker
{
	public class BoggleBoard
	{
		private string letters;
		
		public BoggleBoard(string rows)
		{
			if (rows.Length != 4 * 4) {
				throw new ArgumentException("boggle board consists of 16 characters", rows);
			}
			this.letters = rows.ToLower();
		}

		public void PrintRepresentation() {
			for (int i = 0; i < 4; i++) {
				Console.WriteLine(letters.Substring(i * 4, 4));
			}
		}
	}
}

