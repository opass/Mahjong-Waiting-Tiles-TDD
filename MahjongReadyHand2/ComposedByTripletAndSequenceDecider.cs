using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;

namespace MahjongReadyHand2
{
    public class ComposedByTripletAndSequenceDecider
    {
        private SortedDictionary<Tile, int> _tileCounter;

        public bool Check(IEnumerable<Tile> tiles)
        {
            InitializeTileCounter(tiles);


            bool keepTry = true;
            while (!IsEmpty() && keepTry)
            {
                var smallestTile = GetSmallestRankTile();
                var triplet = TileFactory.CreateTriplet(smallestTile);
                keepTry = TryRemoveAllOrNot(triplet);

                if (IsEmpty()) break;
                
                smallestTile = GetSmallestRankTile();
                if (TileFactory.CanCreateSequence(smallestTile))
                {
                    var sequence = TileFactory.CreateSequence(smallestTile);
                    keepTry = keepTry || TryRemoveAllOrNot(sequence);
                }
            }

            return IsEmpty();
        }


        private bool TryRemoveAllOrNot(IEnumerable<Tile> tiles)
        {
            var tileList = tiles.ToList();

            if (!AllTilesExist(tileList)) return false;
            RemoveExistingTiles(tileList);
            return true;

        }

        private void RemoveExistingTiles(IEnumerable<Tile> tileList)
        {
            foreach (var tile in tileList)
            {
                RemoveExistingTile(tile);
            }
        }

        private bool AllTilesExist(IEnumerable<Tile> tiles)
        {
            var allExist = tiles.GroupBy(tile => tile).All(grp =>
            {
                var tile = grp.Key;
                var count = grp.Count();
                return _tileCounter.ContainsKey(tile) && _tileCounter[tile] >= count;
            });
            return allExist;
        }

        private bool IsEmpty()
        {
            return !_tileCounter.Any();
        }

        private Tile GetSmallestRankTile()
        {
            return _tileCounter.First().Key;
        }

        private void RemoveExistingTile(Tile target)
        {
            if ((_tileCounter[target] -= 1) == 0)
            {
                _tileCounter.Remove(target);
            }
        }

        private void InitializeTileCounter(IEnumerable<Tile> tiles)
        {
            _tileCounter =
                new SortedDictionary<Tile, int>(
                    tiles.GroupBy(tile => tile).ToDictionary(grp => grp.Key, grp => grp.Count()),
                    new TileRankComparer());
        }
    }
}