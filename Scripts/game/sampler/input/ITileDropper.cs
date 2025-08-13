namespace LuminesVS.game.sampler.input;

// how do we want to contain a block?
public interface ITileDropper : ITileGridReadOnly {

  // idea:
  // - pull from the tile queue
  // return true if move performed successfully
  public bool Move(int input);

  // drops down one row
  // return true if the drop performed successfully
  public bool Drop();

  public void RotateCW();
  public void RotateCCW();

  // places the block where it currently sits
  // returns a tile grid containing the block's data (probably: 1 - src alpha)
  // resets state and pulls the next block
  public ITileGridReadOnly PopBlock();
}