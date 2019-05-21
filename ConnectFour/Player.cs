using System;
using System.Collections.Generic;

namespace ConnectFour
{
	public class Player
	{
		bool isMovingNow = default(bool);
		public string Name { get; set; }
		
		public bool IsMovingNow {
			get {
				return isMovingNow;
			}
			set {
				isMovingNow = value;
			}
		}
		
		public char Mark(List<Player> players)
		{
			return players[0].isMovingNow ? 'X' : 'O';
		}
				
		public static void NextPlater(List<Player> players)
		{
			foreach (var element in players) {
				element.IsMovingNow = !element.isMovingNow;
			}
		}
	}
}
