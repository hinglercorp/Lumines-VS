using LuminesVS.game.tile;

namespace LuminesVS.game.sampler.input;

public class SimpleTileDropper : ITileDropper {
  private readonly ITileGridReadOnly collide_grid;
  private readonly IBlockQueue queue;

  private readonly int init_x;
  private readonly int init_y;

  private int current_x;
  private int current_y;
  private Block current_block;

  public int Width => collide_grid.Width;
  public int Height => collide_grid.Height;

  public SimpleTileDropper(
    ITileGridReadOnly collide_grid,
    IBlockQueue block_queue
  ) {
    this.collide_grid = collide_grid;
    queue = block_queue;

    // index to bottom left of block
    init_x = this.collide_grid.Width / 2 - 1;
    init_y = this.collide_grid.Height - 2;

    current_x = init_x;
    current_y = init_y;
    current_block = block_queue.DequeueBlock();
  }

  public Tile GetContents(int x, int y) {
    return new BlockTileGrid(current_x, current_y, current_block).GetContents(x, y);
  }

  public ITileGridReadOnly PopBlock() {
    int block_x = current_x;
    int block_y = current_y;
    Block block = current_block;

    ResetAndPop();

    return new BlockTileGrid(block_x, block_y, block);
  }

  public bool Move(int input) {
    int dest_x = current_x + input;
    bool is_move_valid = IsBlockEmpty(dest_x, current_y);
    if (is_move_valid) {
      current_x = dest_x;
    }

    return is_move_valid;
  }

  public bool Drop() {
    int dest_y = current_y - 1;
    bool is_move_valid = IsBlockEmpty(current_x, dest_y);
    if (is_move_valid) {
      current_y = dest_y;
    }

    return is_move_valid;
  }

  public void RotateCW() {
    current_block = current_block.RotateCW();
  }

  public void RotateCCW() {
    current_block = current_block.RotateCCW();
  }

  // resets dropper state and fetches next block
  private void ResetAndPop() {
    current_x = init_x;
    current_y = init_y;
    current_block = queue.DequeueBlock();
  }

  // true if the block originating at (x, y) is empty
  private bool IsBlockEmpty(int x, int y) {
    // (all four cells are empty)
    return (
      !collide_grid.Test(x, y) &&
      !collide_grid.Test(x + 1, y) &&
      !collide_grid.Test(x, y + 1) &&
      !collide_grid.Test(x + 1, y + 1)
    );
  }
}