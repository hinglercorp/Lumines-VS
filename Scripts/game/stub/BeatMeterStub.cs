using LuminesVS.game.beat;

namespace LuminesVS.game.stub;

public class BeatMeterStub : IBeatMeter {
  public float Progress { get; set; } = 0.5f;
}