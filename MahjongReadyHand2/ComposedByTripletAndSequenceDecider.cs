using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;

namespace MahjongReadyHand2
{
    public class ComposedByTripletAndSequenceDecider
    {
        private readonly IEnumerable<Tile> _tiles;
        private SortedDictionary<Tile, int> _tileCounter;

        public ComposedByTripletAndSequenceDecider(IEnumerable<Tile> tiles)
        {
            _tiles = tiles;
        }

        public bool Check()
        {
            CalculateTileCounter();


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
            var allExist = tiles.GroupBy(tile => tile).All(grp =>
            {
                var tile = grp.Key;
                var count = grp.Count();
                return _tileCounter.ContainsKey(tile) && _tileCounter[tile] >= count;
            });

            if (!allExist) return false;

            foreach (var tile in tiles)
            {
                RemoveExistingTile(tile);
            }

            return true;
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

        private void CalculateTileCounter()
        {
            _tileCounter =
                new SortedDictionary<Tile, int>(
                    _tiles.GroupBy(tile => tile).ToDictionary(grp => grp.Key, grp => grp.Count()),
                    new TileRankComparer());
        }
    }
}