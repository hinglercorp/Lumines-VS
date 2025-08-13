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


// simple game demo
// - return dropper
// - return tile grid
// - return queue

// impl
// - grid, dropper, and queue
// - use l/r/d to drop new blocks
// - once drop fails:
//   - pop
//   - overlay onto fall grid (atm: just the gravity grid)
//   

// will write glue code later :3