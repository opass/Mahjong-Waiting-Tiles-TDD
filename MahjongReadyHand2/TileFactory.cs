using System;
using System.Collections.Generic;
using System.Linq;

namespace MahjongReadyHand2
{
    internal static class TileFactory
    {
        public static IEnumerable<Tile> CreateTiles(string tilesString)
        {
            return tilesString.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(tileString => new Tile(tilesString));
        }
    }
}