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

        [TestMethod]
        public void hand_type_D1114_is_waiting_for_D4()
        {
            GivenHand("D1,D1,D1,D4");
            WaitingTilesShouldBe("D4");
        }

        [TestMethod]
        public void hand_type_D1239_is_waiting_for_D9()
        {
            GivenHand("D1,D2,D3,D9");
            WaitingTilesShouldBe("D9");
        }

        [TestMethod]
        public void hand_type_D2233_is_waiting_for_D23()
        {
            GivenHand("D2,D2,D3,D3");
            WaitingTilesShouldBe("D2,D3");
        }

        [TestMethod]
        public void hand_type_D4677_is_waiting_for_D5()
        {
            GivenHand("D4,D6,D7,D7");
            WaitingTilesShouldBe("D5");
        }

        [TestMethod]
        public void hand_type_D1444789_is_waiting_for_D1()
        {
            GivenHand("D1,D4,D4,D4,D7,D8,D9");
            WaitingTilesShouldBe("D1");
        }

        [TestMethod]
        public void hand_type_D1236669_is_waiting_for_D9()
        {
            GivenHand("D1,D2,D3,D6,D6,D6,D9");
            WaitingTilesShouldBe("D9");
        }

        [TestMethod]
        public void hand_type_D3333666_is_waiting_for_no_tile()
        {
            GivenHand("D3,D3,D3,D3,D6,D6,D6");
            WaitingTilesShouldBe("");
        }

        [TestMethod]
        public void hand_type_D1233344559_is_waiting_for_D9()
        {
            GivenHand("D1,D2,D3,D3,D3,D4,D4,D5,D5,D9");
            WaitingTilesShouldBe("D9");
        }

        [TestMethod]
        public void hand_type_D3334455669_is_waiting_for_D9()
        {
            GivenHand("D3,D3,D3,D4,D4,D5,D5,D6,D6,D9");
            WaitingTilesShouldBe("D9");
        }

        [TestMethod]
        public void hand_type_B1114_is_waiting_for_D4()
        {
            GivenHand("B1,B1,B1,B4");
            WaitingTilesShouldBe("B4");
        }

        [TestMethod]
        public void hand_type_D111B4_is_waiting_for_B4()
        {
            GivenHand("D1,D1,D1,B4");
            WaitingTilesShouldBe("B4");
        }

        [TestMethod]
        public void hand_type_D135B2469_is_waiting_for_nothing()
        {
            GivenHand("D1,D3,D5,B2,B4,B6,B9");
            WaitingTilesShouldBe("");
        }

        [TestMethod]
        public void hand_type_D111B4569_is_waiting_for_B9()
        {
            GivenHand("D1,D1,D1,B4,B5,B6,B9");
            WaitingTilesShouldBe("B9");
        }

        [TestMethod]
        public void hand_type_D111B2469_is_waiting_for_nothing()
        {
            GivenHand("D1,D1,D1,B2,B4,B6,B9");
            WaitingTilesShouldBe("");
        }

        [TestMethod]
        public void hand_type_D1112345678999_is_waiting_for_all()
        {
            GivenHand("D1,D1,D1,D2,D3,D4,D5,D6,D7,D8,D9,D9,D9");
            WaitingTilesShouldBe("D1,D2,D3,D4,D5,D6,D7,D8,D9");
        }

        [TestMethod]
        public void hand_type_C111D111B1119_is_waiting_for_B9()
        {
            GivenHand("C1,C1,C1,D1,D1,D1,B1,B1,B1,B9");
            WaitingTilesShouldBe("B9");
        }

        [TestMethod]
        public void hand_type_D1NNN_is_waiting_for_D1()
        {
            GivenHand("D1,N,N,N");
            WaitingTilesShouldBe("D1");
        }

        [TestMethod]
        public void hand_type_D11NN_is_waiting_for_D1N()
        {
            GivenHand("D1,D1,N,N");
            WaitingTilesShouldBe("D1,N");
        }

        [TestMethod]
        public void hand_type_D111NEEE_is_waiting_for_N()
        {
            GivenHand("D1,D1,D1,N,E,E,E");
            WaitingTilesShouldBe("N");
        }

        [TestMethod]
        public void hand_type_RRRG_is_waiting_for_G()
        {
            GivenHand("R,R,R,G");
            WaitingTilesShouldBe("G");
        }

        [TestMethod]
        public void hand_type_to_string_is_following_convention_order()
        {
            GivenHand("N,E,W,S,R,G,Z,B9,B3,B1,C2,C3,D6");
            _hand.ToString().Should().Be("C2,C3,D6,B1,B3,B9,E,S,W,N,R,G,Z");
        }


        private void WaitingTilesShouldBe(string tilesString)
        {
            var waitingTiles = _hand.GetWaitingTiles();
            var expectedTiles = TileFactory.CreateTiles(tilesString);
            waitingTiles.Should().BeEquivalentTo(expectedTiles);
        }

        private void GivenHand(string tilesString)
        {
            _hand = new Hand(tilesString);
        }
    }
}