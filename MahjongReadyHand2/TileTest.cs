using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class TileTest
    {
        private Tile _tile;

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
            GivenTile("D1");
            SuitAndRankShouldBe(Suit.Dot, 1);
        }

        [TestMethod]
        public void can_create_bamboo_tile()
        {
            GivenTile("B1");
            SuitAndRankShouldBe(Suit.Bamboo, 1);
        }

        [TestMethod]
        public void can_create_character_tile()
        {
            GivenTile("C1");
            SuitAndRankShouldBe(Suit.Character, 1);
        }

        [TestMethod]
        public void can_create_wind_tile()
        {
            GivenTile("N");
            SuitAndRankShouldBe(Suit.North, 0);

            GivenTile("E");
            SuitAndRankShouldBe(Suit.East, 0);

            GivenTile("W");
            SuitAndRankShouldBe(Suit.West, 0);

            GivenTile("S");
            SuitAndRankShouldBe(Suit.South, 0);
        }

        [TestMethod]
        public void can_create_red_dragon_tile()
        {
            GivenTile("R");
            SuitAndRankShouldBe(Suit.RedDragon, 0);
        }

        [TestMethod]
        public void can_create_green_dragon_tile()
        {
            GivenTile("G");
            SuitAndRankShouldBe(Suit.GreenDragon, 0);
        }

        [TestMethod]
        public void can_create_white_dragon_tile()
        {
            GivenTile("Z"); // choose Z Because W already been represented by West Wind
            SuitAndRankShouldBe(Suit.WhiteDragon, 0);
        }

        [TestMethod]
        public void to_string()
        {
            GivenTile("D1");
            _tile.ToString().Should().Be("D1");
        }

        private void SuitAndRankShouldBe(Suit expectedSuit, int expectedRank)
        {
            _tile.Suit.Should().Be(expectedSuit);
            _tile.Rank.Should().Be(expectedRank);
        }

        private void GivenTile(string tile)
        {
            _tile = CreateTile(tile);
        }

        private static Tile CreateTile(string tileString)
        {
            return new Tile(tileString);
        }
    }
}