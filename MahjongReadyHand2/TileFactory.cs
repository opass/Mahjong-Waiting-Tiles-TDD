using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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

        public static bool TryCreateSequence(Tile firstTile, out IEnumerable<Tile> tiles)
        {
            try
            {
                tiles = new[] {firstTile, firstTile.NextRankTile(), firstTile.NextRankTile().NextRankTile()};
                return true;
            }
            catch
            {
                tiles = default(IEnumerable<Tile>);
                return false;
            }
        }
        
    }
}