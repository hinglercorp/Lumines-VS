namespace LuminesVS.game.tile;

public interface IBlockQueue {
  // pops the next block in the queue
  Block PopBlock();

  // peeks the next block in the queue
  Block PeekBlock();
  // peeks a specified block in the queue (0 = next block to pop)
  Block PeekBlock(int offset);
}