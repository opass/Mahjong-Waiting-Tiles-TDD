using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MahjongReadyHand2
{
    public class Hand
    {
        private IEnumerable<Tile> _tiles;

        public Hand(string tilesString)
        {
            _tiles = tilesString.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(tileString => new Tile(tilesString));
        }

        public IEnumerable<Tile> GetWaitingTiles()
        {
            if (_tiles.Count() == 2)
            {
                return Enumerable.Empty<Tile>();
            }
            return _tiles;
        }
    }
}