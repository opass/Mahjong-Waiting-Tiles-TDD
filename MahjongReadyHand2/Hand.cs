using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MahjongReadyHand2
{
    public class Hand
    {
        private readonly string _tilesString;

        public Hand(string tilesString)
        {
            _tilesString = tilesString;
        }

        public IEnumerable<Tile> GetWaitingTiles()
        {
            if (_tilesString != "")
            {
                return new[] {new Tile(_tilesString)};
            }
            
            return Enumerable.Empty<Tile>();
        }
    }
}