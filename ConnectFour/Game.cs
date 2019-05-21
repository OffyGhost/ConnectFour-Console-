using System;

using System.Collections.Generic;

namespace ConnectFour
{

	class Game
	{
		public List<Player> players = new List<Player>();
		public Board board = new Board();
		
		public void StartGameMenu()
		{
			while (players.Count < 2) {
				Console.WriteLine("Enter nicknames of two players: ");
				Player tmpPlayer = new Player();
				string stringRaw = default(string);
				do {
					stringRaw = Console.ReadLine();
				} while (stringRaw.Length == 0) ;
				tmpPlayer.Name = stringRaw;
				
				players.Add(tmpPlayer);			
			}
			players[0].IsMovingNow = true;
			board.PrepareTheBoard();
			
		}
		
		public void GameLoop()
		{	
		
			foreach (var player in players) {
				
				if (player.IsMovingNow) {
					
					board.PrintOutBoard(players);
					if (board.CheckWin())
						break;
					
					Console.WriteLine("\nCurrent move: " + player.Name);
					Console.WriteLine("Chose row from 1 to 7 incluedietly, which drop the mark: ");
					//Console.WriteLine("[q] Quit from game ");
					
					try {
						int selectRow = Convert.ToInt32(Console.ReadLine());
											
						
						if (selectRow > 0 && selectRow <= 7) {
							// Console.WriteLine("Selected: " + selectRow);
							
							if (board.DropTheMark(selectRow - 1, player.Mark(players))) {
								Player.NextPlater(players);
								
							} else {
								Console.WriteLine("This row is full!");
							}
						}
	
						
					} catch (FormatException) {
						
						//pass
					} catch (IndexOutOfRangeException) {
						//pass
					}
					

				}
			}
		}
	}
	
}
