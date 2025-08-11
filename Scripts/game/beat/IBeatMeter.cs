namespace LuminesVS.game.beat;

public interface IBeatMeter {
  // [0.0, 1.0] - represents progress along play surface
  public float Progress { get; }

  // blocks formed on current play should be handled by board
}