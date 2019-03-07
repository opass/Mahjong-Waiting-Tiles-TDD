using System.Collections.Generic;
using System.Diagnostics;

namespace MahjongReadyHand2
{
    public class TileRankComparer: IComparer<Tile>
    {
        public int Compare(Tile x, Tile y)
        {
            Debug.Assert(x != null, nameof(x) + " != null");
            Debug.Assert(y != null, nameof(y) + " != null");
            return x.Rank - y.Rank;
        }
    }
}