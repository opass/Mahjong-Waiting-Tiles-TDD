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
            GivenHand("");
            WaitingTilesShouldBe("");
        }

        [TestMethod]
        public void one_tiles_hand_is_waiting_for_that_tile_D1()
        {
            GivenHand("D1");
            WaitingTilesShouldBe("D1");
        }

        [TestMethod]
        public void one_tiles_hand_is_waiting_for_that_tile_D2()
        {
            GivenHand("D2");
            WaitingTilesShouldBe("D2");
        }

        [TestMethod]
        public void any_two_tiles_is_waiting_for_no_tiles()
        {
            GivenHand("D1,D5");
            WaitingTilesShouldBe("");
        }

        [Ignore]
        [TestMethod]
        public void hand_type_D1114_is_waiting_for_D4()
        {
            GivenHand("D1,D1,D1,D4");
            WaitingTilesShouldBe("D4");
        }

        private void WaitingTilesShouldBe(string tilesString)
        {
            var waitingTiles = _hand.GetWaitingTiles();
            if (tilesString == "")
            {
                waitingTiles.Should().BeEmpty();
            }
            else
            {
                waitingTiles.Should().Equal(new Tile(tilesString));
            }
        }

        private void GivenHand(string tilesString)
        {
            _hand = new Hand(tilesString);
        }
    }
}