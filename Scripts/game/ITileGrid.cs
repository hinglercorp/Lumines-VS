using LuminesVS.game.tile;

namespace LuminesVS.game;

public interface ITileGrid {
  int Width { get; }
  int Height { get; }

  // returns contents of a tile, as an int
  // 0 -> empty
  // 1, 2, ... -> context dependent coloring
  // 
  Tile GetContents(int x, int y);
}