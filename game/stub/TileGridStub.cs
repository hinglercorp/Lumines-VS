using System.Collections.Generic;
using LuminesVS.game.tile;

namespace LuminesVS.game.stub;

public class TileGridStub : ITileGrid {
  public int Width { get; }
  public int Height { get; }

  private readonly List<Tile> data;
  public TileGridStub(int width, int height) {
    Width = width;
    Height = height;

    data = new(width * height);
    for (int i = 0; i < width * height; i++) {
      data[i] = 0;
    }
  }

  public void SetContents(int x, int y, Tile t) {
    data[y * Width + x] = t;
  }

  public Tile GetContents(int x, int y) {
    if (x < 0 || x >= Width || y < 0 || y >= Height) {
      return 0;
    }

    return data[y * Width + x];
  }
}