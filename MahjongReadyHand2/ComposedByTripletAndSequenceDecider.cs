using System.Collections.Generic;
using System.Linq;

namespace MahjongReadyHand2
{
    public class ComposedByTripletAndSequenceDecider
    {
        private readonly IEnumerable<Tile> _tiles;

        public ComposedByTripletAndSequenceDecider(IEnumerable<Tile> tiles)
        {
            _tiles = tiles;
        }

        public bool Check()
        {
            return !_tiles.Any() || _tiles.GroupBy(tile => tile).All(grp => grp.Count() == 3);
        }
    }
}