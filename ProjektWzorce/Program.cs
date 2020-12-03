using System;

namespace ProjektWzorce {
	class Program {
		static void Main(string[] args) {
			var game = new Board(6, 10, 15);
			game.Start();
		}
	}
}
