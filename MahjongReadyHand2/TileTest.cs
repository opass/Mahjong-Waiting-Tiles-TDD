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
        public void different_rank_tiles_are_not_equal()
        {
            var tile1 = CreateTile("D1");
            var tile2 = CreateTile("D2");

            tile1.Should().NotBe(tile2, "because they are different tile");
        }

        [TestMethod]
        public void different_suit_tiles_are_not_equal()
        {
            var tile1 = CreateTile("D1");
            var tile2 = CreateTile("B1");

            tile1.Should().NotBe(tile2, "because they are different tile");
        }

        [TestMethod]
        public void can_create_bamboo_tile()
        {
            var tile1 = CreateTile("B1");

            tile1.Rank.Should().Be(1);
            tile1.Suit.Should().Be(Suit.Bamboo);
        }

        [TestMethod]
        public void can_create_character_tile()
        {
            var tile1 = CreateTile("C1");

            tile1.Rank.Should().Be(1);
            tile1.Suit.Should().Be(Suit.Character);
        }

        [TestMethod]
        public void can_create_wind_tile()
        {
            var northWind = CreateTile("N");
            var eastWind = CreateTile("E");
            var westWind = CreateTile("W");
            var southWind = CreateTile("S");

            northWind.Rank.Should().Be(0);
            eastWind.Rank.Should().Be(0);
            westWind.Rank.Should().Be(0);
            southWind.Rank.Should().Be(0);
            
            northWind.Suit.Should().Be(Suit.North);
            eastWind.Suit.Should().Be(Suit.East);
            westWind.Suit.Should().Be(Suit.West);
            southWind.Suit.Should().Be(Suit.South);
        }

        private static Tile CreateTile(string tileString)
        {
            return new Tile(tileString);
        }
    }
}