namespace LuminesVS.game.tile;

public readonly struct Block {
  public readonly Tile tl;
  public readonly Tile tr;
  public readonly Tile bl;
  public readonly Tile br;

  public static readonly Block EMPTY = new();

  public Block() : this(Tile.EMPTY, Tile.EMPTY, Tile.EMPTY, Tile.EMPTY) { }

  public Block(
    Tile tl,
    Tile tr,
    Tile bl,
    Tile br
  ) {
    this.tl = tl;
    this.tr = tr;
    this.bl = bl;
    this.br = br;
  }

  public readonly Block RotateCW() {
    return new Block(bl, tl, br, tr);
  }

  public readonly Block RotateCCW() {
    return new Block(tr, br, tl, bl);
  }

  public readonly bool IsEmpty() {
    // empty iff all four cells are empty
    return !tl.Occupied() && !tr.Occupied() && !bl.Occupied() && !br.Occupied();
  }
}