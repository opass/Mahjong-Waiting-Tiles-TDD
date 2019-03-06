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
        var groups = _tiles.GroupBy(tile => tile);
        if (groups.Count() == 1 && groups.Single().Count() == 2)
        {
            return new [] {Enumerable.Empty<Tile>()};
        }

        return Enumerable.Empty<IEnumerable<Tile>>();
    }
}