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
            var tile1 = CreateTile("D1");
            var tile2 = CreateTile("D1");

            tile1.Should().Be(tile2, "because they are same tile");
        }

        [TestMethod]
        public void different_tiles_are_not_equal()
        {
            var tile1 = CreateTile("D1");
            var tile2 = CreateTile("D2");

            tile1.Should().NotBe(tile2, "because they are different tile");
        }

        private static Tile CreateTile(string tileString)
        {
            return new Tile(tileString);
        }
    }
}