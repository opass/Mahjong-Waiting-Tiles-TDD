using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class TileRankComparerTest
    {
        [TestMethod]
        public void D1_tiles_is_smaller_than_D2()
        {
            var tile1 = new Tile("D1");
            var tile2 = new Tile("D2");

            new TileRankComparer().Compare(tile1, tile2).Should().BeLessThan(0);
        }

    }
}