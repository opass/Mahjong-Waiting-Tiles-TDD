using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using MahjongReadyHand2;

internal static class PossibleWaitingTilesGenerator
{
    public static IEnumerable<Tile> PossibleWaitingTiles(IEnumerable<Tile> tiles)
    {
        var enumerable = tiles.ToList();
        var quadrupletTiles = enumerable.GroupBy(tile => tile).Where(grp => grp.Count() == 4).Select(grp => grp.Key);

        return enumerable.Distinct().SelectMany(tile =>
        {
            var tilesAndSibling = new List<Tile> {tile};

            if (tile.IsWind() || tile.IsDragon()) return tilesAndSibling;
            if (tile.Rank != 1)
            {
                tilesAndSibling.Add(tile.PreviousRankTile());
            }

            if (tile.Rank != 9)
            {
                tilesAndSibling.Add(tile.NextRankTile());
            }

            return tilesAndSibling;
        }).Except(quadrupletTiles);
    }
}