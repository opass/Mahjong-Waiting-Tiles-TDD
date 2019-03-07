using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;

namespace MahjongReadyHand2
{
    public class ComposedByTripletAndSequenceDecider
    {
        private readonly IEnumerable<Tile> _tiles;

        public ComposedByTripletAndSequenceDecider(IEnumerable<Tile> tiles)
        {
            _tiles = tiles;
        }

        public bool Check()
        {
            if (!_tiles.Any())
            {
                return true;
            }

            if (_tiles.GroupBy(tile => tile).All(grp => grp.Count() == 3))
            {
                return true;
            }

            var smallestTile = GetSmallestTile();
            var secondTile = smallestTile.Next();
            var thirdTile = secondTile.Next();

            if (_tiles.Intersect(new [] {smallestTile, secondTile, thirdTile}).Count() == 3)
            {
                return true;
            }

            return false;
        }

        private Tile GetSmallestTile()
        {
            return _tiles.OrderBy(tile => tile, new TileRankComparer()).First();
        }
    }
}