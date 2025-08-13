namespace LuminesVS.game.tile;

public class RandomBlockQueue : IBlockQueue {
  private readonly SimpleBlockQueue q;
  private readonly SimpleBlockGenerator g;

  public RandomBlockQueue() {
    q = new();
    g = new();
  }

  public Block DequeueBlock() {
    PrepareQueue(2);
    return q.DequeueBlock();
  }

  public Block PeekBlock(int offset) {
    PrepareQueue(offset + 1);
    return q.PeekBlock(offset);
  }

  private void PrepareQueue(int elems) {
    while (q.Count < elems) {
      q.EnqueueBlock(g.GetBlock());
    }
  }
}