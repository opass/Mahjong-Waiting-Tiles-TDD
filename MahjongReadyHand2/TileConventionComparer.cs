using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MahjongReadyHand2
{
    public class TileConventionComparer: IComparer<Tile>
    {
        private static readonly Dictionary<Suit, int> SuitOrder = new Dictionary<Suit, int>
        {
            {Suit.Dot, 0},
            {Suit.Bamboo, 1}
        };

        public int Compare(Tile x, Tile y)
        {
            Debug.Assert(x != null, nameof(x) + " != null");
            Debug.Assert(y != null, nameof(y) + " != null");

            var suitResult = CompareSuit(x, y);
            return suitResult != 0 ? suitResult : CompareRank(x, y);
        }

        private int CompareSuit(Tile x, Tile y)
        {
            return SuitOrder[x.Suit] - SuitOrder[y.Suit];
        }

        private static int CompareRank(Tile x, Tile y)
        {
            return x.Rank - y.Rank;
        }
    }
}