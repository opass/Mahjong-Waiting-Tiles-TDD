using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace MahjongReadyHand2
{
    public class ComposedByTripletAndSequenceDecider
    {
        private SortedDictionary<Tile, int> _tileCounter;

        public bool Check(IEnumerable<Tile> tiles)
        {
            InitializeTileCounter(tiles);


            var tryAgain = true;
            while (TryGetSmallestRankTile(out var tile1) && tryAgain)
            {
                var tripletRemoved = TryRemoveAllOrNot(TileFactory.CreateTriplet(tile1));
                tryAgain = tripletRemoved;

                if (!TryGetSmallestRankTile(out var tile2)) break;
                if (!TileFactory.TryCreateSequence(tile2, out var sequence)) continue;
                var sequenceRemoved = TryRemoveAllOrNot(sequence);
                tryAgain = tripletRemoved || sequenceRemoved;
            }

            return IsEmpty();
        }

        private bool TryGetSmallestRankTile(out Tile tile)
        {
            try
            {
                tile = _tileCounter.First().Key;
                return true;
            }
            catch
            {
                tile = default(Tile);
                return false;
            }
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
            return tiles.GroupBy(tile => tile).All(grp =>
            {
                var tile = grp.Key;
                var count = grp.Count();
                return _tileCounter.ContainsKey(tile) && _tileCounter[tile] >= count;
            });
        }

        private bool IsEmpty()
        {
            return !_tileCounter.Any();
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