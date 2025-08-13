using System;
using LuminesVS.game.util;

namespace LuminesVS.game.tile;

public class SimpleBlockGenerator {
  private readonly Random r;
  public SimpleBlockGenerator() {
    r = new();
  }

  public Block GetBlock() {
    byte[] tiles = new byte[4];
    for (int i = 0; i < 4; i++) {
      int rand = r.Next() % 2;
      tiles[i] = (byte)(rand + 1);
    }

    return new Block(
      tiles[0], tiles[1], tiles[2], tiles[3]
    );
  }
}