using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class HandTest
    {
        private Hand _hand;

        [TestMethod]
        public void no_tiles_hand_is_waiting_for_no_tiles()
        {
            var hand = new Hand();
            var waitingTiles = hand.GetWaitingTiles();
            waitingTiles.Should().BeEmpty();
        }

        [TestMethod]
        public void one_tiles_hand_is_waiting_for_that_tile_D1()
        {
            GivenHand("D1");
            var waitingTiles = _hand.GetWaitingTiles();
            waitingTiles.Should().Equals(new Tile("D1"));
        }

        private void GivenHand(string tilesString)
        {
            _hand = new Hand(tilesString);
        }

        [TestMethod]
        public void one_tiles_hand_is_waiting_for_that_tile_D2()
        {
            GivenHand("D2");
            var waitingTiles = _hand.GetWaitingTiles();
            waitingTiles.Should().Equals(new Tile("D2"));
        }
    }
}