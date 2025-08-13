namespace LuminesVS.game.tile;

public interface IBlockQueue {
  // pops the next block in the queue
  Block DequeueBlock();

  // peeks the next block in the queue
  Block PeekBlock() => PeekBlock(0);
  // peeks a specified block in the queue (0 = next block to pop)
  Block PeekBlock(int offset);
}