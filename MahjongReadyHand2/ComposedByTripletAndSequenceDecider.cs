using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;

namespace MahjongReadyHand2
{
    public class ComposedByTripletAndSequenceDecider
    {
        private readonly IEnumerable<Tile> _tiles;
        private Dictionary<Tile, int> _tileCounter;

        public ComposedByTripletAndSequenceDecider(IEnumerable<Tile> tiles)
        {
            _tiles = tiles;
        }

        public bool Check()
        {
            CalculateTileCounter();

            while (TryRemoveTriplet())
            {
                // empty
            }

            while (TryRemoveSequence())
            {
                // empty
            }

            return !_tileCounter.Any();
        }

        private bool TryRemoveSequence()
        {
            (Tile first, Tile second, Tile third) sequenceTiles;
            try
            {
                sequenceTiles = _tileCounter.Where(kvp => kvp.Key.Rank <= 7).Select(kvp =>
                {
                    var firstTile = kvp.Key;
                    var secondTile = firstTile.NextRankTile();
                    var thirdTile = secondTile.NextRankTile();
                    return (first: firstTile, second: secondTile, third: thirdTile);
                }).First(tuple => _tileCounter.ContainsKey(tuple.second) && _tileCounter.ContainsKey(tuple.third));
            }
            catch (InvalidOperationException)
            {
                return false;
            }

            RemoveExistingTileWithTimes(sequenceTiles.first, 1);
            RemoveExistingTileWithTimes(sequenceTiles.second, 1);
            RemoveExistingTileWithTimes(sequenceTiles.third, 1);

            return true;
        }

        private void RemoveExistingTile(Tile target)
        {
            if ((_tileCounter[target] -= 1) == 0)
            {
                _tileCounter.Remove(target);
            }
        }

        private bool TryRemoveTriplet()
        {
            KeyValuePair<Tile, int> tripletKVP;
            try
            {
                tripletKVP = _tileCounter.First(kvp => kvp.Value >= 3);
            }
            catch (InvalidOperationException)
            {
                return false;
            }

            var tile = tripletKVP.Key;

            RemoveExistingTileWithTimes(tile, 3);

            return true;
        }

        private void RemoveExistingTileWithTimes(Tile tile, int times)
        {
            for (var i = 0; i < times; i++)
            {
                RemoveExistingTile(tile);
            }
        }

        private void CalculateTileCounter()
        {
            _tileCounter = _tiles.GroupBy(tile => tile).ToDictionary(grp => grp.Key, grp => grp.Count());
        }
    }
}