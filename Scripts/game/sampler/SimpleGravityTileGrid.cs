using LuminesVS.game.stub;
using LuminesVS.game.tile;

namespace LuminesVS.game.sampler;

// tile grid, blocks fall INSTANTLY.
public class SimpleGravityTileGrid : ITileGrid {
  public int Width { get; }
  public int Height { get; }

  private readonly TileGridStub grid_data;

  bool dirty = false;

  public SimpleGravityTileGrid(int width, int height) {
    Width = width;
    Height = height;
    grid_data = new(Width, Height);
  }

  public Tile GetContents(int x, int y) {
    if (dirty) {
      HandleGravity();
      dirty = false;
    }

    return grid_data.GetContents(x, y);
  }

  public void SetContents(int x, int y, Tile t) {
    dirty = true;
    grid_data.SetContents(x, y, t);
  }

  private void HandleGravity() {
    for (int col = 0; col < Width; col++) {
      int fall_dist = 0;
      for (int row = 0; row < Height; row++) {
        Tile t = grid_data.GetContents(col, row);
        if (!t.Occupied()) {
          // empty cell found
          fall_dist++;
        }
        else if (fall_dist != 0) {
          // effectively: move 't' under the fall dist, let empty space bubble up
          grid_data.SetContents(col, row, 0);
          grid_data.SetContents(col, row - fall_dist, t);
        }
      }
    }
  }
}