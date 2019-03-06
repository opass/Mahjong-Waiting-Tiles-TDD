using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void same_tiles_are_equal()
        {
            var tile1 = new Tile("D1");
            var tile2 = new Tile("D1");

            tile1.Should().Be(tile2, "because they are same tile");
        }
    }
}