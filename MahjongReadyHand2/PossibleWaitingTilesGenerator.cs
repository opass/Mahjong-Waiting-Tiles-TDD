using System.Collections.Generic;
using System.Linq;
using MahjongReadyHand2;

static internal class PossibleWaitingTilesGenerator
{
    public static IEnumerable<Tile> PossibleWaitingTiles(IEnumerable<Tile> tiles)
    {
        return tiles.Distinct();
    }
}