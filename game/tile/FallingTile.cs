namespace LuminesVS.tile;

public struct FallingTile {
  public byte tile_index;
  public byte column;

  // y offset of tile
  // round to get mask for tile on grid
  public float y_offset;
}