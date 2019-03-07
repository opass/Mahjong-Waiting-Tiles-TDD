using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using MahjongReadyHand2;

internal static class PossibleWaitingTilesGenerator
{
    public static IEnumerable<Tile> PossibleWaitingTiles(IEnumerable<Tile> tiles)
    {
        return tiles.Distinct().SelectMany(tile =>
        {
            var tilesAndSibling = new List<Tile>();
            tilesAndSibling.Add(tile);

            if (tile.Rank != 1)
            {
                tilesAndSibling.Add(tile.PreviousRankTile());
            }

            if (tile.Rank != 9)
            {
                tilesAndSibling.Add(tile.NextRankTile());
            }

            return tilesAndSibling;
        }).Distinct();
    }
}