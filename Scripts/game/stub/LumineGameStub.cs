using LuminesVS.game.beat;

namespace LuminesVS.game.stub;

public class LumineGameStub {
  private ITileGridReadOnly grid;
  private IBeatMeter meter;

  public LumineGameStub(ITileGridReadOnly grid, IBeatMeter meter) {
    this.grid = grid;
    this.meter = meter;
  }

  public ITileGridReadOnly GetTileGrid() => grid;
  public IBeatMeter GetBeatMeter() => meter;
}