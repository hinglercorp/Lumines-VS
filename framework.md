# game framework

## model

accumulate game logic into a single "game" interface which we can split up and render
- board state
  - tile data
  - combos about to be created
  - clears
- beat meter
  - flags to control BPM, if desired...
  - ...or, let the implementer control it (since it's theme related)
  - list of square scleared in current "measure"
  - sweep position
- tile queue
  - list of tiles about to drop
- score
  - event listener. watch for squares, clears, drops, combos
  - handle to fetch multiplier??
  - custom implement
- input handle
  - L/R/drop, rotate

### data types

- tile (2 colors - maybe go 8-bit for maximum support?)
  - "bomb" (flag on tile)
- clear
  - tile color
  - 2x2 regions - just include the coord of the bottom left tile
- bomb-regions
  - 5 cases - fill, edge, corner, peninsula, island
  - example impl: simple 3x3 neighbor check, use 1 of 5 "overlays"
  - alt 2: draw overlay lines based on neighbor check

### beat meter implementation

- distinguish the beat meter as a "thing" which sweeps from left to right
- allow it to start, stop, etc. at will - just don't go backwards(?)
- beat meter knows measure length, bpm, etc - all it does is sweep left to right
- on backwards "jump", end sweep (or fire event?)
- game engine will just "listen" to the beat meter
- synchronization with audio? maybe we want to distinguish a timing mechanism to sync btwn beat meter and song
  - nvm - this should be outside game logic

### edge case - how to handle falling blocks?

- opt 1 - mask in board state, return falling tiles as a separate list
  - skip anim if new tiles are dropped
- opt 2 - make the interface take care of it
  - falling blocks are delayed recognition - needs to be handled in engine
  - game engine should round them down to nearest whole when considering layout
  - show on board, but also distinguish in a separate return - we can infer home tile by just rounding

#### block falls - impl
- blocks fall all at once - no separation
- idea: continue falling as long as the "rounded down" offset is unpopulated...
  - ...and does not map to a placed tile.
  - update from bottom to top: falling tiles below will be "secured" before the tiles above them update

- alt: falling tiles -> falling stacks? (ehh later)

#### block falls - placing new tiles
- new tiles should be handled similarly to falling tiles (ie: they're stamped on top)
- validate moves
  - for falling tiles: check the floor AND ceiling tiles, as both of these should be "off limits"


## theming
- theming should be separate from game state
  - background
  - music
  - tile colors

### tile grid impl
- stitch together from multiple layers
  - base board, subtract falling tiles, add 2x2 cursor

### overflow behavior
- thinking: make the board two lines taller, internally
- on drop: wipe tiles above the visible top
- if any tiles appear on the top line (ie indicating we attempted to place a block on a full line) then end game

### falling tile impl
- put all tiles into the falling state once they're placed
- when a tile traverses a whole num boundary, perform a collision check
  - if tile below is full AND not falling, then remove from falling list
  - else, keep falling
  - reit: check from bottom to top
