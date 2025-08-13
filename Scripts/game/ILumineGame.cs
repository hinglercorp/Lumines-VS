using LuminesVS.game.beat;

namespace LuminesVS.game;

// game instance.
// board state, falling tiles, score, etc.
public interface ILumineGame {
  ITileGridReadOnly GetTileGrid();
  IBeatMeter GetBeatMeter();
}

// game logic
// grid of tiles
// atop that: find squares
// atop that: handle tiles that need to fall ( gt 1 blank space below to fall into)

// current active 2x2 should be integrated into tile grid