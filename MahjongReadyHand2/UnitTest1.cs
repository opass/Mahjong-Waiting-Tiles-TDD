using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class HandTest
    {
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
            var hand = new Hand("D1");
            var waitingTiles = hand.GetWaitingTiles();
            waitingTiles.Should().Equals(new Tile("D1"));
        }
    }
}