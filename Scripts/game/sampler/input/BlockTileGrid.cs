using LuminesVS.game.tile;

namespace LuminesVS.game.sampler.input;

public class BlockTileGrid : ITileGridReadOnly {
  private readonly int block_x;
  private readonly int block_y;
  private readonly Block block;

  public int Width { get; }
  public int Height { get; }

  public BlockTileGrid(
    int block_x,
    int block_y,
    Block block
  ) {
    this.block_x = block_x;
    this.block_y = block_y;
    this.block = block;

    Width = block_x + 1;
    Height = block_y + 1;
  }

  public Tile GetContents(int x, int y) {
    int xo = x - block_x;
    int yo = y - block_y;
    if (xo == 0 && yo == 0) return block.bl;
    if (xo == 1 && yo == 0) return block.br;
    if (xo == 0 && yo == 1) return block.tl;
    if (xo == 1 && yo == 1) return block.tr;

    // no invalids on this grid
    return Tile.EMPTY;
  }
}