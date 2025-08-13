using LuminesVS.game.tile;

namespace LuminesVS.game.sampler.util;

public static class TileGridUtils {
  // equivalent to laying one tileset over the other
  // invalids ignored
  public static void Overlay(this ITileGrid dest, ITileGridReadOnly src) {
    for (int y = 0; y < dest.Height; y++) {
      for (int x = 0; x < dest.Width; x++) {
        Tile t = src.GetContents(x, y);
        if (t.Occupied() || t == Tile.INVALID) {
          dest.SetContents(x, y, t);
        }
      }
    }
  }

  // write source's contents over the dest
  // invalids ignored
  public static void Overwrite(this ITileGrid dest, ITileGridReadOnly src) {
    for (int y = 0; y < dest.Height; y++) {
      for (int x = 0; x < dest.Width; x++) {
        Tile t = src.GetContents(x, y);

        // overwrites all "valid" entries
        if (t.Valid()) {
          dest.SetContents(x, y, t);
        }
      }
    }
  }
}