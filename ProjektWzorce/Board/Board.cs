using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjektWzorce {
	class Board {

		int BoardSize;
		Tile[,] TileBoard;
		bool GameOver;
		bool Win;
		int Points;
		int PointToWin;
		int MovesRemaining;

		public Board(int boardSize, int startingMoves, int pointsToWin) {
			this.BoardSize = boardSize;
			this.Points = 0;
			this.MovesRemaining = startingMoves;
			this.PointToWin = pointsToWin;
			this.TileBoard = new Tile[boardSize, boardSize];
			for (int i = 0; i < boardSize; i++) {
				for (int j = 0; j < boardSize; j++) {
					this.TileBoard[i, j] = new Tile();
				}
			}
			this.CheckBoard();
			this.Points = 0;
			this.GameOver = false;
			this.Win = false;
		}

		private void DrawBoard() {
			Console.Clear();
			Console.WriteLine("Super Diamenty 1.0");
			Console.WriteLine("by KG&MO");
			Console.WriteLine();
			Console.WriteLine();
			Console.Write("   ");
			for (int j = 0; j < this.BoardSize; j++)
			{
				Console.Write($" x{j} ");
			}
			Console.WriteLine();
			Console.Write("   ");
			for (int j = 0; j < this.BoardSize; j++) {
				Console.Write(" -- ");
			}
			Console.WriteLine();
			for (int i = 0; i < this.BoardSize; i++) {
				Console.Write($"y{i} | ");
				for (int j = 0; j < this.BoardSize; j++) {
					Console.Write(TileBoard[i, j].ToString() + " | ");
				}
				Console.WriteLine();
				Console.Write("   ");
				for (int j = 0; j < this.BoardSize; j++) {
					Console.Write(" -- ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.WriteLine($"Wynik: {Points}");
			Console.WriteLine($"Wynik do osiagniecia: {PointToWin}");
			Console.WriteLine($"Pozostale ruchy: {MovesRemaining}");
			Console.WriteLine();
		}

		private void DrawGameOver() {
			Console.Clear();
			Console.WriteLine("Super Diamenty 1.0");
			Console.WriteLine("by KG&MO");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("GAME OVER!");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"Wynik: {Points}");
			Console.WriteLine($"Wynik do osiagniecia: {Points}");
			Console.WriteLine($"Pozostale ruchy: {MovesRemaining}");
		}
		private void DrawGameWin() {
			Console.Clear();
			Console.WriteLine("Super Diamenty 1.0");
			Console.WriteLine("by KG&MO");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("YOU WON!");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"Wynik: {Points}");
			Console.WriteLine($"Wynik do osiagniecia: {PointToWin}");
			Console.WriteLine($"Pozostale ruchy: {MovesRemaining}");
		}

		public void Start() {
			while(!GameOver && !Win) {
				this.DrawBoard();
				this.AskForNextMove();
				this.CheckBoard();
			}
			if (Win) {
				this.DrawGameWin();
			} else {
				this.DrawGameOver();
			}
		}

		private void CheckBoard() {
			for (int i = 0; i < this.BoardSize; i++) {
				TileType lastChecked = this.TileBoard[i, 0].Type;
				int sameAmount = 1;
				for (int j = 1; j < this.BoardSize; j++) {
					if (this.TileBoard[i, j].Type == lastChecked) {
						sameAmount++;
						if (sameAmount == 3) {
							this.TileBoard[i, j] = new Tile();
							this.TileBoard[i, j - 1] = new Tile();
							this.TileBoard[i, j - 2] = new Tile();
							this.CheckBoard();
							sameAmount = 1;
							this.Points++;
						}
					} else {
						lastChecked = this.TileBoard[i, j].Type;
						sameAmount = 1;
					}
				}
				if (Points >= PointToWin) Win = true;
			}

			for (int j = 0; j < this.BoardSize; j++)
			{
				TileType lastChecked = this.TileBoard[0, j].Type;
				int sameAmount = 1;
				for (int i = 1; i < this.BoardSize; i++)
				{
					if (this.TileBoard[i, j].Type == lastChecked)
					{
						sameAmount++;
						if (sameAmount == 3)
						{
							this.TileBoard[i, j] = new Tile();
							this.TileBoard[i - 1, j] = new Tile();
							this.TileBoard[i - 2, j] = new Tile();
							this.CheckBoard();
							sameAmount = 1;
							this.Points++;
						}
					}
					else
					{
						lastChecked = this.TileBoard[i, j].Type;
						sameAmount = 1;
					}
				}
			}
		}

		private void AskForNextMove() {
			if (MovesRemaining == 1) {
				GameOver = true;
			}
			this.CheckBoard();
			try {
				Console.WriteLine("Podaj x:");
				int moveX = int.Parse(Console.ReadLine());
				Console.WriteLine("Podaj y:");
				int moveY = int.Parse(Console.ReadLine());
				Console.WriteLine("Rusz gdzie (t, b, l, r):");
				char moveDirection = Char.Parse(Console.ReadLine());
				MoveTile(moveY, moveX, moveDirection);
				MovesRemaining--;
				this.CheckBoard();
			} catch { }
		}

		private void MoveTile(int tileX, int tileY, char direction) {
			try {
				var movedTile = TileBoard[tileX, tileY];
				var t = TileBoard[tileX, tileY].Type;
				switch (direction) {
					case 't':
						movedTile.Type = TileBoard[tileX - 1, tileY].Type;
						TileBoard[tileX - 1, tileY].Type = t;
						break;
					case 'b':
						movedTile.Type = TileBoard[tileX + 1, tileY].Type;
						TileBoard[tileX + 1, tileY].Type = t;
						break;
					case 'l':
						movedTile.Type = TileBoard[tileX, tileY - 1].Type;
						TileBoard[tileX, tileY - 1].Type = t;
						break;
					case 'r':
						movedTile.Type = TileBoard[tileX, tileY + 1].Type;
						TileBoard[tileX, tileY + 1].Type = t;
						break;
					default:
						break;
				}
			}
			catch { }
		}

	}
}
