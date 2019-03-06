using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MahjongReadyHand2
{
    public class Hand
    {
        public IEnumerable<Tile> GetWaitingTiles()
        {
            return Enumerable.Empty<Tile>();
        }
    }
}