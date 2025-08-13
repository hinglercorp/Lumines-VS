namespace LuminesVS.game.tile;

// records the location of a single tile, irrespective of a tile grid
public readonly struct TileRecord {
  public readonly Tile tile;
  public readonly int X;
  public readonly int Y;
}