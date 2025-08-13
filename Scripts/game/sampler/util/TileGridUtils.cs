using LuminesVS.game.tile;

namespace LuminesVS.game.sampler.util;

public static class TileGridUtils {
  public static void Overwrite(this ITileGrid dest, ITileGridReadOnly src) {
    for (int y = 0; y < dest.Height; y++) {
      for (int x = 0; x < dest.Width; x++) {
        Tile t = src.GetContents(x, y);
        if (t.Occupied()) {
          dest.SetContents(x, y, t);
        }
      }
    }
  }
}