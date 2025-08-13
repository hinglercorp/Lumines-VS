using System.Diagnostics.CodeAnalysis;

namespace LuminesVS.game.tile;

public readonly struct Tile {
  private readonly ushort tile_value;

  private static readonly ushort FLAG_BOMB = (ushort)32768u;

  public static readonly Tile EMPTY = new(0);
  // empty w bomb would be invalid, so ignore it
  public static readonly Tile INVALID = new(FLAG_BOMB);

  public Tile(ushort index, bool is_bomb) {
    tile_value = index;
    if (is_bomb) {
      tile_value |= FLAG_BOMB;
    }
  }

  public Tile(ushort val) {
    tile_value = val;
  }

  public static implicit operator Tile(ushort t) {
    return new Tile(t);
  }

  public static explicit operator ushort(Tile t) {
    return t.tile_value;
  }

  public readonly int GetColor() => tile_value & (~FLAG_BOMB);
  public readonly bool IsBomb() => (tile_value & FLAG_BOMB) != 0;

  // non-zero (includes invalids)
  public readonly bool Occupied() => tile_value != 0;

  // not invalid
  public readonly bool Valid() => tile_value != INVALID.tile_value;
  public readonly bool Empty() => !Occupied();

  public override bool Equals([NotNullWhen(true)] object obj) {
    if (obj == null) {
      return false;
    }

    if (obj is Tile t) {
      return tile_value == t.tile_value;
    }

    return false;
  }

  public static bool operator ==(Tile left, Tile right) {
    return left.Equals(right);
  }

  public static bool operator !=(Tile left, Tile right) {
    return !(left == right);
  }

  public override int GetHashCode() {
    return tile_value.GetHashCode();
  }
}