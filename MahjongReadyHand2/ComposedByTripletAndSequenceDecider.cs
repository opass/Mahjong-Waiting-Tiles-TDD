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
            if (!_tiles.Any())
            {
                return true;
            }

            CalculateTileCounter();

            while (TryRemoveTriplet())
            {
                // empty
            }

            while (TryRemoveSequence())
            {
                // empty
            }

            if (!_tileCounter.Any())
            {
                return true;
            }

            return false;
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

            if ((_tileCounter[sequenceTiles.first] -= 1) == 0)
            {
                _tileCounter.Remove(sequenceTiles.first);
            }
            if ((_tileCounter[sequenceTiles.second] -= 1) == 0)
            {
                _tileCounter.Remove(sequenceTiles.second);
            }
            if ((_tileCounter[sequenceTiles.third] -= 1) == 0)
            {
                _tileCounter.Remove(sequenceTiles.third);
            }

            return true;
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

            if ((_tileCounter[tile] -= 3) == 0)
            {
                _tileCounter.Remove(tile);
            }

            return true;
        }

        private void CalculateTileCounter()
        {
            _tileCounter = _tiles.GroupBy(tile => tile).ToDictionary(grp => grp.Key, grp => grp.Count());
        }
    }
}