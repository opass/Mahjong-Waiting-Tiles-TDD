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
    }
}