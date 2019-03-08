using System.Collections.Generic;
using System.Linq;

namespace MahjongReadyHand2
{
    internal class PossibleWaitingTilesGenerator
    {
        public IEnumerable<Tile> GetAll(IEnumerable<Tile> tiles)
        {
            var enumerable = tiles.ToList();
            var quadrupletTiles = enumerable.GroupBy(tile => tile).Where(grp => grp.Count() == 4).Select(grp => grp.Key);

            return enumerable.Distinct().SelectMany(CreateSelfAndSiblingTiles ).Except(quadrupletTiles);
        }

        private static IEnumerable<Tile> CreateSelfAndSiblingTiles(Tile self)
        {
            var tilesAndSibling = new List<Tile> {self};

            if (self.IsWind() || self.IsDragon()) return tilesAndSibling;
            if (self.Rank != 1)
            {
                tilesAndSibling.Add(self.PreviousRankTile());
            }

            if (self.Rank != 9)
            {
                tilesAndSibling.Add(self.NextRankTile());
            }

            return tilesAndSibling;
        }
    }
}