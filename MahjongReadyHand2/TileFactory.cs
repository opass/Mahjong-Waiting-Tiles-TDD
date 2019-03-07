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

        public static IEnumerable<Tile> CreateTriplet(Tile tile)
        {
            return Enumerable.Repeat(tile, 3);
        }

        public static bool CanCreateSequence(Tile tile)
        {
            return 1 <= tile.Rank && tile.Rank <= 7;
        }

        public static IEnumerable<Tile> CreateSequence(Tile firstTile)
        {
            return new [] {firstTile, firstTile.NextRankTile(), firstTile.NextRankTile().NextRankTile()};
        }
    }
}