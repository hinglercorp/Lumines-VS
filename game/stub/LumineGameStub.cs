using LuminesVS.game.beat;

namespace LuminesVS.game.stub;

public class LumineGameStub {
  private ITileGrid grid;
  private IBeatMeter meter;

  public LumineGameStub(ITileGrid grid, IBeatMeter meter) {
    this.grid = grid;
    this.meter = meter;
  }

  public ITileGrid GetTileGrid() => grid;
  public IBeatMeter GetBeatMeter() => meter;
}