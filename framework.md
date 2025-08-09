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

## theming
- theming should be separate from game state
  - background
  - music
  - tile colors