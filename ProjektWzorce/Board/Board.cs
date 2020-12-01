using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjektWzorce {
	class Board {

		int BoardSize;
		Tile[,] TileBoard;
		bool gameOver;


		public Board(int boardSize) {
			this.BoardSize = boardSize;
			this.TileBoard = new Tile[boardSize, boardSize];
			for (int i = 0; i < boardSize; i++) {
				for (int j = 0; j < boardSize; j++) {
					this.TileBoard[i, j] = new Tile(i, j);
				}
			}
			this.gameOver = false;
		}

		private void DrawBoard() {
			Console.Clear();
			for (int j = 0; j < this.BoardSize; j++) {
				Console.Write("	-	");
			}
			Console.WriteLine();
			for (int i = 0; i < this.BoardSize; i++) {
				Console.Write("|	");
				for (int j = 0; j < this.BoardSize; j++) {
					Console.Write(TileBoard[i, j].ToString() + "	|	");
				}
				Console.WriteLine();
				for (int j = 0; j < this.BoardSize; j++) {
					Console.Write("	-	");
				}
				Console.WriteLine();
			}
		}

		public void Start() {
			while(!gameOver) {
				this.DrawBoard();
				this.AskForNextMove();
			}
		}

		private void AskForNextMove() {
			Console.WriteLine("Podaj x:");
			int moveX = int.Parse(Console.ReadLine());
			Console.WriteLine("Podaj y:");
			int moveY = int.Parse(Console.ReadLine());
			Console.WriteLine("Rusz gdzie (t, b, l, r):");
			char moveDirection = Char.Parse(Console.ReadLine());
		}

		private void MoveTile() {

		}

	}
}
