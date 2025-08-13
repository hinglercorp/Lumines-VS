using System.Collections.Generic;

namespace LuminesVS.game.tile;

public class SimpleBlockQueue : IBlockQueue {
  private readonly List<Block> blocks;

  public int Count => blocks.Count;

  public SimpleBlockQueue() : this([]) { }

  public SimpleBlockQueue(IEnumerable<Block> blocks) {
    this.blocks = [.. blocks];
  }

  public void EnqueueBlock(Block b) {
    blocks.Add(b);
  }

  public Block DequeueBlock() {
    if (blocks.Count <= 0) {
      return Block.EMPTY;
    }

    Block b = blocks[0];
    if (blocks.Count > 1) {
      // duplicate last block over and over
      blocks.RemoveAt(0);
    }

    return b;
  }

  public Block PeekBlock(int offset) {
    if (blocks.Count <= 0) {
      return Block.EMPTY;
    } else if (blocks.Count < offset) {
      return blocks[^1];
    }

    return blocks[offset];
  } 
}