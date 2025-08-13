using System;
using System.Collections.Generic;

namespace LuminesVS.game.util;

public class RandomBitGenerator {
  private readonly Random rand;
  private int acc = 0;
  private int off = 0;

  // rand.next returns non negative, so ignore sign bit
  private static readonly int INT_WIDTH = 31;

  public RandomBitGenerator() {
    rand = new();
  }


  public byte[] GetBits(int count) {
    byte[] res = new byte[count];
    int bit_count = count;
    for (int i = 0; i < count; i++) {
      res[i] = ReadBit();
    }

    return res;
  }

  private byte ReadBit() {
    ReadBits(1, out int res);
    return (byte)res;
  }

  private int ReadBits(int bit_count, out int res) {
    if (off >= INT_WIDTH) {
      acc = rand.Next();
      off = 0;
    }

    int max_bits = INT_WIDTH - off;
    int fetch_bits = Math.Min(max_bits, bit_count);

    int mask = (1 << fetch_bits) - 1;
    res = acc & mask;

    off += fetch_bits;
    acc >>= fetch_bits;

    return fetch_bits;
  }
}