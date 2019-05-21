using System;
using System.Collections.Generic;

namespace ConnectFour
{
	
	public class Program
	{
		public static void Main(string[] args)
		{

			char quitGameCheck = default(char);
			bool exit = default(bool);
			
			
			do {
				Console.Clear();
				Console.WriteLine("Connect Four. Another one useless game on C#.");
				Game thisGame = new Game();
			
				// Adding players
				thisGame.StartGameMenu();
			
				// Game loop
				while (!thisGame.board.isGameOver) {
					thisGame.GameLoop();
				}
			
				// Game results
				// Console.WriteLine("k_o = " + thisGame.board.k_o);
				// Console.WriteLine("k_x = " + thisGame.board.k_x);
			
				if (thisGame.board.k_x > thisGame.board.k_o) {
					Console.WriteLine("Player one WIN.");
				} else if (thisGame.board.k_x < thisGame.board.k_o) {
					Console.WriteLine("Player two WIN.");
				}
		
				
				Console.WriteLine("[A] for play again\n[Q] for exit");
				
				do {
					quitGameCheck = (char)Console.Read();

					if (quitGameCheck == 'A' || quitGameCheck == 'a') {
						break;
					}
					if (quitGameCheck == 'Q' || quitGameCheck == 'q') {
						exit = true;
						break;
					}
				} while(true);
				
			} while(!exit);
			
		}
	}
	

}