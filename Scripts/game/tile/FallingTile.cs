using LuminesVS.game.tile;

namespace LuminesVS.tile;

public struct FallingTile {
  public Tile tile;
  public byte column;

  // y offset of tile
  // round to get mask for tile on grid
  public float y_offset;
}