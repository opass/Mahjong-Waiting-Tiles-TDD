using System;
using System.Collections.Generic;
using System.Linq;

namespace MahjongReadyHand2
{
    internal static class TileFactory
    {
        public static IEnumerable<Tile> CreateTiles(string tiles)
        {
            return tiles.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(tile => new Tile(tile));
        }
    }
}