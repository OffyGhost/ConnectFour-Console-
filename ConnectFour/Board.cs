using System;

using System.Collections.Generic;

namespace ConnectFour
{
	class Board
	{
		// Board size is 6 x 7 cells
		public char[,] rows = new char [6, 7];
		// Initial win-counter
		public bool isGameOver = default(bool);
		public int k_o = default(int), k_x = default(int);
		
		public void PrepareTheBoard()
		{
			for (int i = 0; i < 6; i++) {
				for (int y = 0; y < 7; y++) {
					this.rows[i, y] = '.';
				}
			}
		}
		
		public void PrintOutBoard(List<Player> players)
		{
			Console.Clear();
			foreach (var element in players) {
				if (element.IsMovingNow) {
					Console.WriteLine("Current move by  " + element.Name+ "\n");
				}
			}
			for (int i = 5; i >= 0; i--) {
				for (int y = 0; y < 7; y++) {
					Console.Write(this.rows[i, y]);
					Console.Write(" ");
				}
				Console.WriteLine();
			}
		}
		
		public bool DropTheMark(int y, char mark)
		{
			bool isResulted = false;
			for (int i = 0; i < 6; i++) {
				if (rows[i, y] == '.') {
					rows[i, y] = mark;
					isResulted = true;
					break;
				}
			}
			return isResulted;
		}
		
		public bool  MicroCheckWhoIsWin(ref int k_x, ref int k_o)
		{
			if (k_x >= 4 || k_o >= 4) {
				Console.WriteLine("Game Over");
				isGameOver = true;
				
			}
			return isGameOver;
		}
		
		
		public bool CheckWin()
		{

			k_o = k_x = 1;
			
			
			// Check from vertical
			for (int j = 0; j < 7; j++) {
				k_o = k_x = 1;
				for (int i = 0; i < 6; i++) {
					try {
						if (rows[i, j] == 'O' && rows[i, j] == rows[i + 1, j]) {
							k_o++;
						}
					
						if (rows[i, j] == 'X' && rows[i, j] == rows[i + 1, j]) {
							k_x++;
						}
					} catch (IndexOutOfRangeException) {
						// ignore
					}

				}
				// Console.WriteLine("Vertical check, in column: " + j + "; 'O' = " + k_o + " 'X' = " + k_x);
				if (MicroCheckWhoIsWin(ref k_x, ref k_o)) return isGameOver;

			}
			
			// Check from horizontal
			for (int i = 0; i < 6; i++) {
				k_o = k_x = 1;
				for (int j = 0; j < 7; j++) {
					try {
						if (rows[i, j] == 'O' && rows[i, j] == rows[i, j + 1]) {
							k_o++;
						}
					
						if (rows[i, j] == 'X' && rows[i, j] == rows[i, j + 1]) {
							k_x++;
						}
					} catch (IndexOutOfRangeException) {
						// ignore
						
					}
				}
				//Console.WriteLine("Horizontal check, in line:: " + i + "; 'O' = " + k_o + " 'X' = " + k_x);
				if (MicroCheckWhoIsWin(ref k_x, ref k_o)) return isGameOver;
			}
			
			
			// Check diagonal asc
			for (int i = 0; i < 6; i++) {
				k_o = k_x = 1;
				for (int j = 0; j < 7; j++) {
					try {
						if (rows[i, j] == 'O' && rows[i, j] == rows[i + 1, j + 1]) {
							k_o++;
						
						}
					
						if (rows[i, j] == 'X' && rows[i, j] == rows[i + 1, j + 1]) {
							k_x++;
						}
						
					} catch (IndexOutOfRangeException) {
						
						// ignore
					}
					
					
				}
				// Console.WriteLine("Diagonal check inc. 'O' = " + k_o + " 'X' = " + k_x);
				if (MicroCheckWhoIsWin(ref k_x, ref k_o)) return isGameOver;
			}
			
			// Check diagonal dsc
			for (int i = 0; i < 6; i++) {
				k_o = k_x = 1;
				for (int j = 0; j < 7; j++) {
					try {
						
						if (rows[i, j] == 'O' && rows[i, j] == rows[i + 1, j - 1]) {
							k_o++;
						
						}
					
						if (rows[i, j] == 'X' && rows[i, j] == rows[i + 1, j - 1]) {
							k_x++;
						}
					} catch (IndexOutOfRangeException) {
						
						// ignore
					}
					
					
				}
				// Console.WriteLine("Diagonal check desc. 'O' = " + k_o + " 'X' = " + k_x);
				
				if (MicroCheckWhoIsWin(ref k_x, ref k_o)) return isGameOver;
			}
			
			return isGameOver;
		}
		
	}
	
}
