using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektWzorce {
	class Tile {

		public TileType Type;

		public Tile () {
			// when new tile is created type gets randomized
			this.Type = (TileType)this.GetRandomTileType();
		}

		public Tile (TileType type) {
			this.Type = type;
		}

		private int GetRandomTileType() {
			Random r = new Random();
			return r.Next(0, Enum.GetNames(typeof(TileType)).Length);
		}

		public new string ToString() {
			switch(this.Type) {
				case TileType.GemRed:
					return "1";
				case TileType.GemGreen:
					return "2";
				case TileType.GemBlue:
					return "3";
				case TileType.GemPurple:
					return "4";
				default:
					return "";
			}
		}

	}
}
