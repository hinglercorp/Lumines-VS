namespace LuminesVS.game.tile;

public struct Tile {
  private ushort tile_value;

  private static readonly ushort FLAG_BOMB = (ushort)32768u;

  public Tile(ushort color, bool is_bomb) {
    tile_value = color;
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
}