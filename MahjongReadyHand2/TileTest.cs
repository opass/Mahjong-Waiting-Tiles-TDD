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
            GivenTile("N");
            SuitAndRankShouldBe(Suit.North, 0);

            GivenTile("E");
            SuitAndRankShouldBe(Suit.East, 0);
            
            GivenTile("W");
            SuitAndRankShouldBe(Suit.West, 0);
            
            GivenTile("S");
            SuitAndRankShouldBe(Suit.South, 0);
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