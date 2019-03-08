using System.Collections.Generic;
using System.Linq;

namespace MahjongReadyHand2
{
    public class WinningDecider
    {
        public bool Check(IEnumerable<Tile> tiles)
        {
            return new DistinctTilesTakenEyeGenerator(tiles).GetAll()
                .Select(tiles1 => new ComposedByTripletAndSequenceDecider().Check(tiles1))
                .Any(result => result);
        }
    }
}