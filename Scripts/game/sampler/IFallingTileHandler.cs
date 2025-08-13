using System.Collections.Generic;
using LuminesVS.game.tile;
using LuminesVS.tile;

namespace LuminesVS.game.sampler;

public interface IFallingTileHandler : ITileGridReadOnly {
  // returns a list of all falling tiles
  public ICollection<FallingTile> GetFallingTiles();

  public void AddFallingTile(TileRecord r) => AddFallingTile(r.tile, r.X, r.Y);
  public void AddFallingTile(Tile t, int x, int y);

  // update falling tiles list
  // returns a list of all tiles which are now "grounded"
  public List<TileRecord> Update(float delta);


  // after "clear" event:
  // - look for all tiles which are above a blank space
  // - remove them from tile grid
  // - add them to falling tile handler
}