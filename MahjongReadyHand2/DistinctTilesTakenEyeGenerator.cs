using System;
using System.Collections.Generic;
using System.Linq;
using MahjongReadyHand2;

internal class DistinctTilesTakenEyeGenerator
{
    private readonly IEnumerable<Tile> _tiles;

    public DistinctTilesTakenEyeGenerator(IEnumerable<Tile> tiles)
    {
        _tiles = tiles;
    }

    public IEnumerable<IEnumerable<Tile>> GetAll()
    {
        var eyeTiles = _tiles.GroupBy(tile => tile).Where(grp => grp.Count() >= 2).Select(grp => grp.Key);

        return eyeTiles.Select(eyeTile =>
        {
            var tileList = _tiles.ToList();
            tileList.Remove(eyeTile);
            tileList.Remove(eyeTile);
            return tileList;
        });
    }
}